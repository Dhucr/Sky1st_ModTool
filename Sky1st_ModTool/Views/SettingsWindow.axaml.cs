using Avalonia.Controls;
using Sky1st_ModTool.ViewModels;

namespace Sky1st_ModTool.Views
{
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        public SettingsWindow(SettingsWindowViewModel viewModel) : this()
        {
            DataContext = viewModel;
        }
    }
}