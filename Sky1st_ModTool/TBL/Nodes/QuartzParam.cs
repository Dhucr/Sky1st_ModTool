using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class QuartzParam : TblNodeData
    {
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Flag;

        [FieldOrder(2)]
        public ushort Ushort1;

        [FieldOrder(3)]
        public ushort Ushort2;

        [FieldOrder(4)]
        public ushort Ushort3;

        [FieldOrder(5)]
        public ushort Ushort4;

        [FieldOrder(6)]
        public ushort Ushort5;

        [FieldOrder(7)]
        public ushort Ushort6;

        [FieldOrder(8)]
        public ushort Ushort7;

        [FieldOrder(9)]
        public ushort Ushort8;

        [FieldOrder(10)]
        public ushort Ushort9;

        [FieldOrder(11)]
        public ushort Ushort10;

        [FieldOrder(12)]
        public ushort Ushort11;

        [FieldOrder(13)]
        public ushort Ushort12;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}