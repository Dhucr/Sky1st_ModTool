using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class PortraitDataParam : TblNodeData
    {
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Filename;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [FieldOrder(3)]
        public float Float1;

        [FieldOrder(4)]
        public float Float2;

        [FieldOrder(5)]
        public float Float3;

        [FieldOrder(6)]
        public float Float4;

        [JsonIgnore]
        public override string? DisplayName => Filename;
    }
}