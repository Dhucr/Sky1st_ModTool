using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class BreakObjectTableData : TblNodeData
    {
        [FieldOrder(0)]
        [FieldOffset(FieldType.String)]
        public string? Filename;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Text2;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? Text3;

        [FieldOrder(4)]
        public ushort Ushort1;

        [FieldOrder(5)]
        public ushort Ushort2;

        [FieldOrder(6)]
        public ushort Ushort3;

        [FieldOrder(7)]
        public ushort Ushort4;

        [FieldOrder(8)]
        [FieldOffset(FieldType.String)]
        public string? Text5;

        [FieldOrder(9)]
        [FieldOffset(FieldType.String)]
        public string? Text6;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}