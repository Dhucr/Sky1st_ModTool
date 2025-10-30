using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class TipsTableData : TblNodeData
    {
        [FieldOrder(0)]
        public ushort Id1;

        [FieldOrder(1)]
        public ushort Id2;

        [FieldOrder(2)]
        public uint Int1;

        [FieldOrder(3)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count1")]
        public ushort[]? Arr1;

        [FieldOrder(4)]
        public int Count1;

        [FieldOrder(5)]
        public uint Int2;

        [FieldOrder(6)]
        [FieldOffset(FieldType.String)]
        public string? Tag;

        [FieldOrder(7)]
        public uint TabId;

        [FieldOrder(8)]
        public uint Order;

        [FieldOrder(9)]
        [FieldOffset(FieldType.String)]
        public string? Title;

        [FieldOrder(10)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [JsonIgnore]
        public override string? DisplayName => Title;
    }
}