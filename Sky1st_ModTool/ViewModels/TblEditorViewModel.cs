using Avalonia.Controls.Templates;
using Avalonia.Threading;
using AvaloniaEdit;
using AvaloniaEdit.Editing;
using DynamicData;
using Newtonsoft.Json;
using ReactiveUI;
using Sky1st_ModTool.Core.Models;
using Sky1st_ModTool.Core.Services;
using Sky1st_ModTool.TBL.Handler;
using Sky1st_ModTool.TBL.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Sky1st_ModTool.ViewModels
{
    public class TblEditorViewModel() : ViewModelBase
    {
        private static TblEditorViewModel? _instance;
        private readonly ISettingsService? _settingsService;

        private PACFile? _pacFile;
        private PACEntry? _pacEntry;
        private IPACProcessor? _pacProcessor;
        private TblNode? _selectedTblNode;
        private TblNodeData? _selectedNodeData;
        private bool _isLoading;
        private bool _showNodeList;
        private string _searchText = string.Empty;
        private string _textAreaContent = string.Empty;
        private IDataTemplate _currentTemplate;
        private readonly Dictionary<TblNode, IList> _nodeDataMap = [];
        private readonly JsonSerializerSettings _jsonSerializerSettings = CreateJsonSerializerOptions();
        public ObservableCollection<TblNode> TblNodes { get; } = [];
        public ObservableCollection<TblNodeData> CurrentNodeData { get; } = [];

        public TblNode? SelectedTblNode
        {
            get => _selectedTblNode;
            set
            {
                var v = value;
                Dispatcher.UIThread.Post(() => SelectTblNodeCommand!.Execute(v!).Subscribe());
                this.RaiseAndSetIfChanged(ref _selectedTblNode, value);
            }
        }

        public TblNodeData? SelectedNodeData
        {
            get => _selectedNodeData;
            set
            {
                var v = value;
                var old = _selectedNodeData;
                var json = TextAreaContent;
                Dispatcher.UIThread.Post(() => SelectNodeDataCommand!.Execute([v!, old!, json!]).Subscribe());
                this.RaiseAndSetIfChanged(ref _selectedNodeData, value);
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => this.RaiseAndSetIfChanged(ref _isLoading, value);
        }

        public bool ShowNodeList
        {
            get => _showNodeList;
            set => this.RaiseAndSetIfChanged(ref _showNodeList, value);
        }

        public string TextAreaContent
        {
            get => _textAreaContent;
            set => this.RaiseAndSetIfChanged(ref _textAreaContent, value);
        }

        public string SearchText
        {
            get => _searchText;
            set => this.RaiseAndSetIfChanged(ref _searchText, value);
        }

        public IDataTemplate CurrentTemplate
        {
            get => _currentTemplate;
            set => this.RaiseAndSetIfChanged(ref _currentTemplate, value);
        }

        public ReactiveCommand<TblNode, Unit>? SelectTblNodeCommand { get; }
        public ReactiveCommand<object[], Unit>? SelectNodeDataCommand { get; }
        public ReactiveCommand<Unit, Unit>? BackToNodeListCommand { get; }
        public ReactiveCommand<Unit, Unit>? AddDataToNodeCommand { get; }
        public ReactiveCommand<Unit, Unit>? DeleteDataFromNodeCommand { get; }

        public TblEditorViewModel(PACEntry entry, PACFile file, IPACProcessor processor, ISettingsService settingsService)
            : this()
        {
            _settingsService = settingsService;
            InitializeInstance(entry, file, processor);

            SelectTblNodeCommand = ReactiveCommand.CreateFromTask<TblNode>(SelectTblNodeAsync);
            SelectNodeDataCommand = ReactiveCommand.CreateFromTask<object[]>(SelectNodeDataAsync);
            BackToNodeListCommand = ReactiveCommand.Create(BackToNodeList);
            AddDataToNodeCommand = ReactiveCommand.Create(AddDataToNode);
            DeleteDataFromNodeCommand = ReactiveCommand.Create(DeleteDataFromNode);

            // 监听搜索文本变化，延迟300毫秒避免频繁搜索
            this.WhenAnyValue(x => x.SearchText)
                .Throttle(TimeSpan.FromMilliseconds(300))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(SearchItems);
        }

        public static TblEditorViewModel Create(PACEntry entry, PACFile file, IPACProcessor processor, ISettingsService settingsService)
        {
            if (_instance == null)
            {
                _instance = new TblEditorViewModel(entry, file, processor, settingsService);
            }
            else
            {
                _instance.InitializeInstance(entry, file, processor);
            }
            return _instance;
        }

        private void InitializeInstance(PACEntry entry, PACFile file, IPACProcessor processor)
        {
            _pacEntry = entry;
            _pacFile = file;
            _pacProcessor = processor;
            ShowNodeList = false;
            LoadTblData();
        }

        private void LoadTblData()
        {
            var parser = new TblHandler();

            var filePath = GetExportFilePath();

            TblFile? tblFile;
            if (File.Exists(filePath))
            {
                tblFile = parser.ParseFile(filePath);
            }
            else
            {
                var tblData = _pacProcessor?.GetFileDataAsync(_pacFile!, _pacEntry!).GetAwaiter().GetResult();
                if (tblData == null) return;
                tblFile = parser.ParseData(tblData);
            }

            ClearExistingData();
            ProcessTblNodes(tblFile!);
        }

        private string GetExportFilePath()
        {
            var settings = _settingsService!.LoadSettings();
            return Path.Combine(settings.ExportDirectory!, _pacEntry!.Filename);
        }

        private void ClearExistingData()
        {
            TblNodes.Clear();
            _nodeDataMap.Clear();
            CurrentNodeData.Clear();
            TextAreaContent = string.Empty;
        }

        private void ProcessTblNodes(TblFile tblFile)
        {
            var parserFactory = CreateParserFactory();
            foreach (var node in tblFile.Nodes)
            {
                TblNodes.Add(node);
                ParseNodeData(node, tblFile.RawData, parserFactory);
            }
        }

        private static NodeDataParserFactory CreateParserFactory()
        {
            var factory = new NodeDataParserFactory();
            factory.RegisterParser(StructNodeHandler.Instance);
            return factory;
        }

        private void ParseNodeData(TblNode node, byte[] rawData, NodeDataParserFactory parserFactory)
        {
            var nodeParser = parserFactory.GetParser(node.Name);
            if (nodeParser == null) return;
            var parsedData = nodeParser.Parse(node, rawData) as IList;
            if (parsedData != null)
            {
                _nodeDataMap[node] = parsedData;
                Console.WriteLine($"Node: {node.Name}, Data Count: {parsedData.Count}");
            }
        }

        private async Task SelectTblNodeAsync(TblNode node)
        {
            if (node == null) return;
            await LoadNodeDataAsync(node);
            ShowNodeList = true;
        }

        private async Task LoadNodeDataAsync(TblNode node)
        {
            CurrentNodeData.Clear();
            if (_nodeDataMap.TryGetValue(node, out var nodeData))
            {
                var tblNodeData = nodeData.OfType<TblNodeData>();
                foreach (var data in tblNodeData)
                {
                    CurrentNodeData.Add(data);
                }
            }
        }

        private async Task SelectNodeDataAsync(object[] data)
        {
            var now = data[0];
            var old = data[1];
            var json = data[2] as string;
            if (old != null)
                UpdateSelectedNodeData(old, json!);
            if (now is not TblNodeData) return;
            TextAreaContent = JsonConvert.SerializeObject(now, _jsonSerializerSettings);
        }

        private void BackToNodeList()
        {
            if (SelectedNodeData != null)
                UpdateSelectedNodeData();
            ShowNodeList = false;
            CurrentNodeData.Clear();
            TextAreaContent = string.Empty;
            SelectedTblNode = null;
        }

        public override void SaveCommand()
        {
            if (SelectedNodeData is null || SelectedTblNode is null) return;
            Task.Run(() =>
            {
                UpdateSelectedNodeData();
                SerializeAndSaveTblData();
            });
        }

        private void UpdateSelectedNodeData()
        {
            UpdateSelectedNodeData(SelectedNodeData!, TextAreaContent);
        }

        private void UpdateSelectedNodeData(object old, string json)
        {
            if (string.IsNullOrEmpty(TextAreaContent)) return;
            var deserializedData = JsonConvert.DeserializeObject(json, old!.GetType(), _jsonSerializerSettings);
            if (deserializedData is not TblNodeData updatedData) return;
            var index = CurrentNodeData.IndexOf(old);
            if (index < 0) return;
            CurrentNodeData[index] = updatedData;
            _nodeDataMap[SelectedTblNode!][index] = updatedData;
        }

        private void SerializeAndSaveTblData()
        {
            using var dataStream = new MemoryStream();
            using var offsetStream = new MemoryStream();

            using var dataWriter = new BinaryWriter(dataStream);
            using var offsetWriter = new BinaryWriter(offsetStream);
            var tblHandler = new TblHandler();
            tblHandler.SerializeHeader(dataWriter, TblNodes);
            var dataOffset = CalculateDataOffset();
            SerializeAllNodeData(dataWriter, offsetWriter, dataOffset);
            SaveToFile(dataStream, offsetStream);
            Dispatcher.UIThread.Post(() =>
            {
                // Optionally notify the user of successful save
            });
        }

        private int CalculateDataOffset()
        {
            var lastNode = TblNodes.LastOrDefault();
            return lastNode != null
                ? (int)(lastNode.DataOffset + lastNode.DataSize * lastNode.DataCount)
                : 0;
        }

        private void SerializeAllNodeData(BinaryWriter dataWriter, BinaryWriter offsetWriter, int baseOffset)
        {
            var parserFactory = CreateParserFactory();
            foreach (var node in TblNodes)
            {
                var nodeParser = parserFactory.GetParser(node.Name);
                nodeParser?.Serialize(dataWriter, offsetWriter, _nodeDataMap[node], node.Name, baseOffset);
            }
        }

        private void SaveToFile(MemoryStream dataStream, MemoryStream offsetStream)
        {
            var fileData = dataStream.ToArray().Concat(offsetStream.ToArray()).ToArray();
            var filePath = GetExportFilePath();
            EnsureDirectoryExists(filePath);
            File.WriteAllBytes(filePath, fileData);
        }

        private static void EnsureDirectoryExists(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static JsonSerializerSettings CreateJsonSerializerOptions()
        {
            return new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        private void SearchItems(string searchText)
        {
            if (_nodeDataMap is null || SelectedTblNode is null) return;
            CurrentNodeData.Clear();
            IEnumerable<TblNodeData> tblNodeData;
            // 如果搜索文本为空，显示所有项
            if (!_nodeDataMap.TryGetValue(SelectedTblNode!, out var nodeData))
            {
                return;
            }
            tblNodeData = nodeData.OfType<TblNodeData>();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                foreach (var data in tblNodeData)
                {
                    CurrentNodeData.Add(data);
                }
            }
            else
            {
                // 过滤包含搜索文本的项
                var filtered = tblNodeData.Where(item =>
                    item.DisplayName!.Contains(searchText, StringComparison.OrdinalIgnoreCase));

                foreach (var item in filtered)
                {
                    CurrentNodeData.Add(item);
                }
            }

            // 通知界面更新
            //this.RaisePropertyChanged(nameof(CurrentNodeData));
        }

        public void AddDataToNode()
        {
            if (SelectedTblNode is null || SelectedNodeData is null) return;
            AddNodeDataToCurrent(SelectedTblNode, SelectedNodeData);
        }

        private void AddNodeDataToCurrent(TblNode node, TblNodeData nodeData)
        {
            if (_nodeDataMap.TryGetValue(node, out var nodeDatas))
            {
                nodeDatas.Add(nodeData);
                CurrentNodeData.Add(nodeData);
                SelectedNodeData = nodeData;
            }
        }

        public void DeleteDataFromNode()
        {
            if (SelectedTblNode is null || SelectedNodeData is null) return;
            RemoveNodeDataFromCurrent(SelectedTblNode, SelectedNodeData);
            TextAreaContent = string.Empty;
        }

        private void RemoveNodeDataFromCurrent(TblNode node, TblNodeData nodeData)
        {
            if (_nodeDataMap.TryGetValue(node, out var nodeDatas))
            {
                nodeDatas.Remove(nodeData);
                CurrentNodeData.Remove(nodeData);
                SelectedNodeData = null;
            }
        }

        // Text editing commands
        public void CopyMouseCommand(TextArea textArea) =>
            ApplicationCommands.Copy.Execute(null, textArea);

        public void CutMouseCommand(TextArea textArea) =>
            ApplicationCommands.Cut.Execute(null, textArea);

        public void PasteMouseCommand(TextArea textArea) =>
            ApplicationCommands.Paste.Execute(null, textArea);

        public void SelectAllMouseCommand(TextArea textArea) =>
            ApplicationCommands.SelectAll.Execute(null, textArea);

        public void UndoMouseCommand(TextArea textArea) =>
            ApplicationCommands.Undo.Execute(null, textArea);
    }
}