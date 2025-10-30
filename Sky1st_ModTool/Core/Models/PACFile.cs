using System.Collections.ObjectModel;
using System.IO;

namespace Sky1st_ModTool.Core.Models
{
    public class PACFile
    {
        public string FilePath { get; set; } = string.Empty;
        public string FileName => Path.GetFileName(FilePath);
        public PACHeader Header { get; set; } = new();
        public ObservableCollection<PACEntry> Entries { get; } = new();
        public bool IsLoaded { get; set; }
    }

    public class PACHeader
    {
        public string Magic { get; set; } = "FPAC";
        public uint FileCount { get; set; }
        public uint FirstFileAddress { get; set; }
        public uint UnknownMagic { get; set; } = 1;
    }

    public class PACEntry
    {
        public uint FilenameCRC32 { get; set; }
        public uint Padding { get; set; }
        public ulong FilenameStringAddress { get; set; }
        public ulong FileSize { get; set; }
        public ulong FileDataAddress { get; set; }
        public string Filename { get; set; } = string.Empty;

        public string DisplayName => Path.GetFileName(Filename);
        public string Extension => Path.GetExtension(Filename).ToLower();
    }
}