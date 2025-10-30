using Sky1st_ModTool.Core.Models;
using Sky1st_ModTool.PACProcessor.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sky1st_ModTool.Core.Services
{
    public interface IPACProcessor
    {
        Task<PACFile> LoadAsync(string filePath);

        Task SaveAsync(PACFile pacFile, string outputPath);

        IReadOnlyList<PACEntry> GetEntries(PACFile pacFile);

        PACEntry? FindEntry(PACFile pacFile, string filename);

        Task<byte[]> GetFileDataAsync(PACFile pacFile, PACEntry entry);

        Task<byte[]> GetFileDataAsync(PACFile pacFile, string filename);

        Task<string> ExportFileAsync(PACFile pacFile, PACEntry entry, string outputDirectory, bool preserveDirectoryStructure = true);

        Task<string> ExportFileAsync(PACFile pacFile, string filename, string outputDirectory, bool preserveDirectoryStructure = true);

        Task<List<string>> ExportAllFilesAsync(PACFile pacFile, string outputDirectory, bool preserveDirectoryStructure = true, IProgress<ExportProgress>? progress = null);
    }
}