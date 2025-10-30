using Avalonia.Controls;
using Avalonia.Platform.Storage;
using ReactiveUI;
using Sky1st_ModTool.Core.Models;
using Sky1st_ModTool.Core.Services;
using Sky1st_ModTool.Utils;
using Sky1st_ModTool.Views;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sky1st_ModTool.ViewModels
{
    public class SettingsWindowViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly IWindowService _windowService;
        private AppSettings _settings;

        public SettingsWindowViewModel(ISettingsService settingsService, IWindowService windowService)
        {
            _settingsService = settingsService;
            _windowService = windowService;
            _settings = settingsService.LoadSettings();

            SelectPACDirectoryCommand = ReactiveCommand.CreateFromTask(SelectPACDirectoryAsync);
            SelectExportDirectoryCommand = ReactiveCommand.CreateFromTask(SelectExportDirectoryAsync);
            SaveCommand = ReactiveCommand.Create(SaveSettings);
            CancelCommand = ReactiveCommand.Create(Cancel);
        }

        public string PACDirectory
        {
            get => _settings.PACDirectory ?? string.Empty;
            set
            {
                _settings.PACDirectory = value;
                this.RaisePropertyChanged();
            }
        }

        public string ExportDirectory
        {
            get => _settings.ExportDirectory ?? string.Empty;
            set
            {
                _settings.ExportDirectory = value;
                this.RaisePropertyChanged();
            }
        }

        public ICommand SelectPACDirectoryCommand { get; }
        public ICommand SelectExportDirectoryCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        private async Task SelectPACDirectoryAsync()
        {
            var result = await ChooseFolder();
            if (!string.IsNullOrEmpty(result))
            {
                PACDirectory = result;
                await _windowService.ShowMessageAsync("设置PAC文件夹", result);
            }
        }

        private async Task SelectExportDirectoryAsync()
        {
            var result = await ChooseFolder();
            if (!string.IsNullOrEmpty(result))
            {
                ExportDirectory = result;
                await _windowService.ShowMessageAsync("设置导出文件夹", result);
            }
        }

        private async Task<string> ChooseFolder()
        {
            var window = UIUtils.GetWindow<SettingsWindow>();
            var topLevel = TopLevel.GetTopLevel(window);
            var dialog = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
            {
                Title = "选择目录",
                AllowMultiple = false // Set to true for multiple file selection
            });
            var result = dialog.Count > 0 ? dialog[0].Path.LocalPath : string.Empty;
            return result;
        }

        private void SaveSettings()
        {
            _settingsService.SaveSettings(_settings);
            CloseWindow();
        }

        private void Cancel()
        {
            CloseWindow();
        }

        private void CloseWindow()
        {
            //this.FindControl<SettingsWindow>("window");
            var window = UIUtils.GetWindow<SettingsWindow>();
            window?.Close();
        }
    }
}