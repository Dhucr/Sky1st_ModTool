using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class QuestText : TblNodeData
    {
        [FieldOrder(0)]
        public ushort QuestId;

        [FieldOrder(1)]
        public int TxtId;

        [FieldOrder(2)]
        public short Empty1;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? QuestDescription;

        [FieldOrder(4)]
        public long Long1;

        [FieldOrder(5)]
        [FieldOffset(FieldType.String)]
        public string? UnkTxt;

        [JsonIgnore]
        public override string? DisplayName => QuestId.ToString();
    }
}