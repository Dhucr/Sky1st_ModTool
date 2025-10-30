using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class QuestChapterRank : TblNodeData
    {
        [FieldOrder(0)]
        public uint Id;

        [FieldOrder(1)]
        public int Int1;

        [FieldOrder(2)]
        public int Int2;

        [FieldOrder(3)]
        public int Int3;

        [FieldOrder(4)]
        public int Int4;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}