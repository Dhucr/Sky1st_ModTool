using Avalonia.Threading;
using Sky1st_ModTool.Core.Services;
using Sky1st_ModTool.ViewModels;
using System.Threading.Tasks;

namespace Sky1st_ModTool.Services
{
    public class WindowService : IWindowService
    {
        private MainWindowViewModel? _mainViewModel;

        public void SetMainViewModel(MainWindowViewModel viewModel)
        {
            _mainViewModel = viewModel;
        }

        public Task ShowMessageAsync(string title, string message)
        {
            return Dispatcher.UIThread.InvokeAsync(async () =>
            {
                _mainViewModel?.ShowMessage(title, message);
            });
        }

        public Task<bool> ShowConfirmationAsync(string title, string message)
        {
            return Dispatcher.UIThread.InvokeAsync(async () =>
            {
                // 由于没有确认对话框，这里暂时返回true
                // 在实际应用中，您可能需要实现一个确认对话框
                _mainViewModel?.ShowMessage(title, $"{message} (自动确认)");
                return true;
            });
        }
    }
}