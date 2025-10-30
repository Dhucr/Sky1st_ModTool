using System.Collections.Generic;

namespace Sky1st_ModTool.TBL.Model
{
    public class TblFile
    {
        public string Magic { get; set; }  // "23 54 42 4C"
        public uint NodeCount { get; set; }
        public List<TblNode> Nodes { get; set; } = new();
        public byte[] RawData { get; set; }
    }

    public class TblNode
    {
        public string Name { get; set; }
        public uint UnknownField { get; set; }
        public uint DataOffset { get; set; }
        public uint DataSize { get; set; }
        public uint DataCount { get; set; }
        public byte[] NodeData { get; set; }
    }
}