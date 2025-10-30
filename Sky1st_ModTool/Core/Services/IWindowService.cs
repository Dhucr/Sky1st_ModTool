using System.Threading.Tasks;

namespace Sky1st_ModTool.Core.Services
{
    public interface IWindowService
    {
        Task ShowMessageAsync(string title, string message);

        Task<bool> ShowConfirmationAsync(string title, string message);
    }
}