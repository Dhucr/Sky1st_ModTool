using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class DLCTableData : TblNodeData
    {
        [FieldOrder(0)]
        public uint Id;

        [FieldOrder(1)]
        public uint Int2;

        [FieldOrder(2)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("ItemIdArrayCount")]
        public uint[]? ItemIdArray;

        [FieldOrder(3)]
        public long ItemIdArrayCount;

        [FieldOrder(4)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("CountArrayCount")]
        public uint[]? CountArray;

        [FieldOrder(5)]
        public long CountArrayCount;

        [FieldOrder(6)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [FieldOrder(7)]
        [FieldOffset(FieldType.String)]
        public string? Description;

        [FieldOrder(8)]
        [FieldOffset(FieldType.String)]
        public string? Text2;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}