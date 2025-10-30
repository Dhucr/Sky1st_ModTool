using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class SkillConnectListData : TblNodeData
    {
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count")]
        public ushort[]? Items;

        [FieldOrder(2)]
        public long Count;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}