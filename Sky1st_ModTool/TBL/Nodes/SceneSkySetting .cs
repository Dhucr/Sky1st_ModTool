using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class SceneSkySetting : TblNodeData
    {
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Text;

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

        [FieldOrder(9)]
        public float Float8;

        [FieldOrder(10)]
        public float Float9;

        [FieldOrder(11)]
        public float Float10;

        [FieldOrder(12)]
        public float Float11;

        [FieldOrder(13)]
        public float Float12;

        [FieldOrder(14)]
        public float Float13;

        [FieldOrder(15)]
        public float Float14;

        [JsonIgnore]
        public override string? DisplayName => Text;
    }
}