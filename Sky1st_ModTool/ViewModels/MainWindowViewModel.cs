using Avalonia.Threading;
using ReactiveUI;
using Sky1st_ModTool.Core.Models;
using Sky1st_ModTool.Core.Services;
using Sky1st_ModTool.Services;
using Sky1st_ModTool.Utils;
using Sky1st_ModTool.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;

namespace Sky1st_ModTool.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IPACProcessor _pacProcessor;
        private readonly ISettingsService _settingsService;
        private readonly IWindowService _windowService;

        private string _pacDirectory = string.Empty;

        private PACFile? _selectedPACFile;
        private PACEntry? _selectedEntry;
        private bool _isLoading;
        private bool _showFileList = false;
        private object? _currentWorkspace;

        private string _messageText = string.Empty;
        private bool _isMessageVisible = false;

        public MainWindowViewModel(
            IPACProcessor pacProcessor,
            ISettingsService settingsService,
            IWindowService windowService)
        {
            _pacProcessor = pacProcessor;
            _settingsService = settingsService;
            _windowService = windowService;
            if (_windowService is WindowService ws)
            {
                ws.SetMainViewModel(this);
            }

            LoadSettings();
            LoadPACFilesCommand = ReactiveCommand.CreateFromTask(LoadPACFilesAsync);
            SelectPACFileCommand = ReactiveCommand.CreateFromTask<PACFile>(SelectPACFileAsync);
            SelectEntryCommand = ReactiveCommand.Create<PACEntry>(SelectEntry);
            BackToPACListCommand = ReactiveCommand.Create(BackToPACList);
            OpenSettingsCommand = ReactiveCommand.Create(OpenSettings);
            ExportCurrentCommand = ReactiveCommand.CreateFromTask(ExportCurrentAsync);
            ExportAllCommand = ReactiveCommand.CreateFromTask(ExportAllAsync);
            ClearMessageCommand = ReactiveCommand.Create(ClearMessage);
        }

        public string PACDirectory
        {
            get => _pacDirectory;
            set => this.RaiseAndSetIfChanged(ref _pacDirectory, value);
        }

        public ObservableCollection<PACFile> PACFiles { get; } = new();
        public ObservableCollection<PACEntry> CurrentEntries { get; } = new();

        public PACFile? SelectedPACFile
        {
            get => _selectedPACFile;
            set
            {
                var v = value;
                Dispatcher.UIThread.Post(() => SelectPACFileCommand.Execute(v).Subscribe());
                this.RaiseAndSetIfChanged(ref _selectedPACFile, value);
            }
        }

        public PACEntry? SelectedEntry
        {
            get => _selectedEntry;
            set
            {
                var v = value;
                Dispatcher.UIThread.Post(() => SelectEntryCommand.Execute(v).Subscribe());
                this.RaiseAndSetIfChanged(ref _selectedEntry, value);
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => this.RaiseAndSetIfChanged(ref _isLoading, value);
        }

        public bool ShowFileList
        {
            get => _showFileList;
            set => this.RaiseAndSetIfChanged(ref _showFileList, value);
        }

        public object? CurrentWorkspace
        {
            get => _currentWorkspace;
            set => this.RaiseAndSetIfChanged(ref _currentWorkspace, value);
        }

        public string MessageText
        {
            get => _messageText;
            set => this.RaiseAndSetIfChanged(ref _messageText, value);
        }

        public bool IsMessageVisible
        {
            get => _isMessageVisible;
            set => this.RaiseAndSetIfChanged(ref _isMessageVisible, value);
        }

        public ReactiveCommand<Unit, Unit> LoadPACFilesCommand { get; }
        public ReactiveCommand<PACFile, Unit> SelectPACFileCommand { get; }
        public ReactiveCommand<PACEntry, Unit> SelectEntryCommand { get; }
        public ReactiveCommand<Unit, Unit> BackToPACListCommand { get; }
        public ReactiveCommand<Unit, Unit> OpenSettingsCommand { get; }
        public ReactiveCommand<Unit, Unit> ExportCurrentCommand { get; }
        public ReactiveCommand<Unit, Unit> ExportAllCommand { get; }
        public ReactiveCommand<Unit, Unit> ClearMessageCommand { get; }

        private void LoadSettings()
        {
            var settings = _settingsService.LoadSettings();
            PACDirectory = settings.PACDirectory;

            if (!string.IsNullOrEmpty(PACDirectory))
                Dispatcher.UIThread.Post(() => LoadPACFilesCommand.Execute().Subscribe());
        }

        private async Task LoadPACFilesAsync()
        {
            if (string.IsNullOrEmpty(PACDirectory) || !Directory.Exists(PACDirectory))
                return;
            try
            {
                IsLoading = true;
                PACFiles.Clear();
                CurrentEntries.Clear();
                ShowFileList = false;
                CurrentWorkspace = null;
                var pacFiles = Directory.GetFiles(PACDirectory, "*.pac", SearchOption.TopDirectoryOnly)
                    .Concat(Directory.GetFiles(PACDirectory, "*.fpac", SearchOption.TopDirectoryOnly));
                foreach (var filePath in pacFiles)
                {
                    var pacFile = await _pacProcessor.LoadAsync(filePath);
                    PACFiles.Add(pacFile);
                }
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task SelectPACFileAsync(PACFile? pacFile)
        {
            if (pacFile == null) return;
            try
            {
                IsLoading = true;
                CurrentEntries.Clear();
                ShowFileList = true;
                CurrentWorkspace = null;
                //var loadedFile = await _pacProcessor.LoadAsync(pacFile.FilePath);
                //SelectedPACFile = loadedFile;
                var list = new List<PACEntry>(pacFile.Entries);
                list.Sort((a, b) => string.Compare(a.DisplayName, b.DisplayName, StringComparison.OrdinalIgnoreCase));
                foreach (var entry in list)
                {
                    CurrentEntries.Add(entry);
                }
                list.Clear();

                IsLoading = false;
            }
            catch (Exception ex)
            {
                // 处理错误 - 在实际实现中应该使用对话框服务
                await _windowService.ShowMessageAsync("Error", $"loading PAC file: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void SelectEntry(PACEntry entry)
        {
            if (entry == null) return;
            //SelectedEntry = entry;
            // 根据文件类型加载不同的工作区页面
            CurrentWorkspace = CreateWorkspaceForEntry(entry);
        }

        private void BackToPACList()
        {
            ShowFileList = false;
            CurrentEntries.Clear();
            SelectedPACFile = null;
            CurrentWorkspace = null;
        }

        private void OpenSettings()
        {
            var settingsWindow = new SettingsWindow(
                new SettingsWindowViewModel(_settingsService, _windowService));
            settingsWindow.ShowDialog(UIUtils.GetWindow<MainWindow>());
        }

        private async Task ExportCurrentAsync()
        {
            if (SelectedEntry == null || SelectedPACFile == null)
            {
                await _windowService.ShowMessageAsync("提示", "请先选择一个文件");
                return;
            }
            var settings = _settingsService.LoadSettings();
            if (string.IsNullOrEmpty(settings.ExportDirectory))
            {
                await _windowService.ShowMessageAsync("提示", "请先在设置中配置导出目录");
                return;
            }
            try
            {
                IsLoading = true;
                var exportPath = await _pacProcessor.ExportFileAsync(SelectedPACFile, SelectedEntry, settings.ExportDirectory);
                await _windowService.ShowMessageAsync("成功", $"文件已导出到: {exportPath}");
            }
            catch (Exception ex)
            {
                await _windowService.ShowMessageAsync("错误", $"导出文件失败: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task ExportAllAsync()
        {
            if (SelectedPACFile == null)
            {
                await _windowService.ShowMessageAsync("提示", "请先选择一个PAC文件");
                return;
            }
            var settings = _settingsService.LoadSettings();
            if (string.IsNullOrEmpty(settings.ExportDirectory))
            {
                await _windowService.ShowMessageAsync("提示", "请先在设置中配置导出目录");
                return;
            }
            try
            {
                IsLoading = true;
                var exportedFiles = await _pacProcessor.ExportAllFilesAsync(SelectedPACFile, settings.ExportDirectory);
                await _windowService.ShowMessageAsync("成功", $"已导出 {exportedFiles.Count} 个文件");
            }
            catch (Exception ex)
            {
                await _windowService.ShowMessageAsync("错误", $"导出全部文件失败: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private object CreateWorkspaceForEntry(PACEntry entry)
        {
            return TblEditorViewModel.Create(entry, SelectedPACFile!, _pacProcessor, _settingsService);
            // 根据文件扩展名创建不同的工作区视图模型
            /*return entry.Extension switch
            {
                ".lua" or ".txt" => new TextEditorViewModel(entry, _pacProcessor, SelectedPACFile!),
                ".tbl" => new TableEditorViewModel(entry, _pacProcessor, SelectedPACFile!),
                ".dds" or ".png" or ".jpg" => new TextureViewerViewModel(entry, _pacProcessor, SelectedPACFile!),
                ".fbx" or ".obj" => new ModelViewerViewModel(entry, _pacProcessor, SelectedPACFile!),
                ".wav" or ".mp3" => new AudioPlayerViewModel(entry, _pacProcessor, SelectedPACFile!),
                _ => new HexViewerViewModel(entry, _pacProcessor, SelectedPACFile!)
            };*/
        }

        public override void SaveCommand()
        {
            if (CurrentWorkspace is ViewModelBase vm)
            {
                vm.SaveCommand();
            }
        }

        // 显示消息的方法
        public void ShowMessage(string title, string message)
        {
            MessageText = $"[{DateTime.Now:HH:mm:ss}] {title}: {message}";
            IsMessageVisible = true;
        }

        // 清除消息
        private void ClearMessage()
        {
            MessageText = string.Empty;
            IsMessageVisible = false;
        }
    }
}