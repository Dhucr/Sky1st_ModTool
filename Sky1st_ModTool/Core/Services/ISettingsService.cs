using Sky1st_ModTool.Core.Models;

namespace Sky1st_ModTool.Core.Services
{
    public interface ISettingsService
    {
        AppSettings LoadSettings();

        void SaveSettings(AppSettings settings);

        string GetDefaultPACDirectory();
    }
}