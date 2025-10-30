using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class AniParam : TblNodeData
    {
        [FieldOrder(0)]
        [FieldOffset(FieldType.String)]
        public string? Filename;

        [FieldOrder(1)]
        public int Int1;

        [FieldOrder(2)]
        public float Float1;

        [FieldOrder(3)]
        public float Float2;

        [FieldOrder(4)]
        public float Float3;

        [FieldOrder(5)]
        public float Float4;

        [FieldOrder(6)]
        public float Float5;

        [FieldOrder(7)]
        public float Float6;

        [FieldOrder(8)]
        public float Float7;

        [JsonIgnore]
        public override string? DisplayName => Filename;
    }
}