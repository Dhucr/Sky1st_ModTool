using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class WeedingTableData : TblNodeData
    {
        [FieldOrder(0)]
        [FieldOffset(FieldType.String)]
        public string? Filename;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? FuncName;

        [FieldOrder(3)]
        public ushort Ushort1;

        [FieldOrder(4)]
        public ushort Ushort2;

        [FieldOrder(5)]
        public ushort Ushort3;

        [FieldOrder(6)]
        public ushort Ushort4;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}