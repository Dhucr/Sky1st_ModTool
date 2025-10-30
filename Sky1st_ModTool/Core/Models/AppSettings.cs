using System.Collections.Generic;

namespace Sky1st_ModTool.Core.Models
{
    public class AppSettings
    {
        public string? PACDirectory { get; set; }
        public string? ExportDirectory { get; set; }
        public List<string> RecentFiles { get; set; } = new();
        public WindowSettings Window { get; set; } = new();
    }

    public class WindowSettings
    {
        public double Width { get; set; } = 1200;
        public double Height { get; set; } = 800;
        public double X { get; set; }
        public double Y { get; set; }
    }
}