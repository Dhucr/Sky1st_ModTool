using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ATBonusParam : TblNodeData
    {
        [FieldOrder(0)]
        public byte Id;

        [FieldOrder(1)]
        public byte ReferenceId;

        [FieldOrder(2)]
        public int Int1;

        [FieldOrder(3)]
        public ushort Short1;

        [FieldOrder(4)]
        [FieldOffset(FieldType.String)]
        public string? Flag;

        [FieldOrder(5)]
        public int Int2;

        [FieldOrder(6)]
        public int Int3;

        [FieldOrder(7)]
        public int Int4;

        [FieldOrder(8)]
        public int Int5;

        [FieldOrder(9)]
        [FieldOffset(FieldType.String)]
        public string? AtBonusName;

        [JsonIgnore]
        public override string? DisplayName => AtBonusName;
    }
}