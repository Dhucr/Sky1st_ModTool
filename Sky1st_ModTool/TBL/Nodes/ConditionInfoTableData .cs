using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ConditionInfoTableData : TblNodeData
    {
        [FieldOrder(0)]
        public uint Id;

        [FieldOrder(1)]
        public uint Int1;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? StateName;

        [FieldOrder(3)]
        public uint Int2;

        [FieldOrder(4)]
        public uint Int3;

        [FieldOrder(5)]
        public uint Int4;

        [FieldOrder(6)]
        [ArrayLength(2)]
        public ItemEffect[]? Effects;

        [FieldOrder(7)]
        public float Float1;

        [FieldOrder(8)]
        public int Int5;

        [FieldOrder(9)]
        public int Int6;

        [FieldOrder(10)]
        public int Int7;

        [FieldOrder(11)]
        public int Int8;

        [FieldOrder(12)]
        [FieldOffset(FieldType.String)]
        public string? Flag;

        [JsonIgnore]
        public override string? DisplayName => StateName;
    }
}