using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class CharaArrange : TblNodeData
    {
        [FieldOrder(0)]
        public int ChrId;

        [FieldOrder(1)]
        public int Int1;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Animation;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? Text1;

        [FieldOrder(4)]
        public float Float1;

        [FieldOrder(5)]
        public float Float2;

        [FieldOrder(6)]
        public float Float3;

        [FieldOrder(7)]
        public float Float4;

        [FieldOrder(8)]
        [FieldOffset(FieldType.String)]
        public string? Flag;

        [FieldOrder(9)]
        public int Empty1;

        [FieldOrder(10)]
        public float Float5;

        [FieldOrder(11)]
        public long Empty2;

        [JsonIgnore]
        public override string? DisplayName => ChrId.ToString();
    }
}