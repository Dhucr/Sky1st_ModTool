using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class CharaSettingInfo : TblNodeData
    {
        [FieldOrder(0)]
        public uint Id;

        [FieldOrder(1)]
        public float Float1;

        [FieldOrder(2)]
        public float Float2;

        [FieldOrder(3)]
        public float Float3;

        [FieldOrder(4)]
        public float Float4;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}