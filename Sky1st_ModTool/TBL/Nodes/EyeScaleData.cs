using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class EyeScaleData : TblNodeData
    {
        [FieldOrder(0)]
        public short Short1;

        [FieldOrder(1)]
        public short Id;

        [FieldOrder(2)]
        public float Scale;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}