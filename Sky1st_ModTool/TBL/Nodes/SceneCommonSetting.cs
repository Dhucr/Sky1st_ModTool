using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class SceneCommonSetting : TblNodeData
    {
        [FieldOrder(0)]
        public float Float1;

        [FieldOrder(1)]
        public float Float2;

        [FieldOrder(2)]
        public float Float3;

        [FieldOrder(3)]
        public float Float4;

        [FieldOrder(4)]
        public float Float5;

        [FieldOrder(5)]
        public float Float6;

        [FieldOrder(6)]
        public float Float7;

        [JsonIgnore]
        public override string? DisplayName => "Item";
    }
}