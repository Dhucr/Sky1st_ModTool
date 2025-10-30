using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class SkillRangeData : TblNodeData
    {
        [FieldOrder(0)]
        public uint RangeId;

        [FieldOrder(1)]
        public float Unknown1;

        [FieldOrder(2)]
        public float Unknown2;

        [FieldOrder(3)]
        public float Unknown3;

        [FieldOrder(4)]
        public float Unknown4;

        [JsonIgnore]
        public override string? DisplayName => RangeId.ToString();
    }
}