using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ChrDataParam : TblNodeData
    {
        [FieldOrder(0)]
        public int Id;

        [FieldOrder(1)]
        public float Float1;

        [FieldOrder(2)]
        public float Float2;

        [FieldOrder(3)]
        public float Float3;

        [FieldOrder(4)]
        public float Float4;

        [FieldOrder(5)]
        public float Float5;

        [FieldOrder(6)]
        public float Float6;

        [FieldOrder(7)]
        public float Float7;

        [FieldOrder(8)]
        public float Float8;

        [FieldOrder(9)]
        public float Float9;

        [FieldOrder(10)]
        public ushort Ushort1;

        [FieldOrder(11)]
        public ushort Ushort2;

        [FieldOrder(12)]
        public int Int1;

        [FieldOrder(13)]
        [FieldOffset(FieldType.String)]
        public string? FuncName;

        [FieldOrder(14)]
        public float Float12;

        [FieldOrder(15)]
        public int Int2;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}