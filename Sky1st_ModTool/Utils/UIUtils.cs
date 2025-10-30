using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace Sky1st_ModTool.Utils
{
    public static class UIUtils
    {
        public static Window? GetWindow<T>()
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                foreach (var window in desktop.Windows)
                {
                    if (window is T)
                    {
                        return window;
                    }
                }
            }

            return null;
        }
    }
}