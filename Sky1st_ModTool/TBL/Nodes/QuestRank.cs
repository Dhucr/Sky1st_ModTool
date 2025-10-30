using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class QuestRank : TblNodeData
    {
        [FieldOrder(0)]
        public ulong Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? RankName;

        [FieldOrder(2)]
        public int Int1;

        [FieldOrder(3)]
        public int Int2;

        [JsonIgnore]
        public override string? DisplayName => RankName;
    }
}