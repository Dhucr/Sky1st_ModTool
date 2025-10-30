using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class SkillGetParam : TblNodeData
    {
        [FieldOrder(0)]
        public ushort CharacterId;

        [FieldOrder(1)]
        public ushort SkillId1;

        [FieldOrder(2)]
        public ushort SkillId2;

        [FieldOrder(3)]
        public ushort SkillId3;

        [FieldOrder(4)]
        public ushort SkillId4;

        [JsonIgnore]
        public override string? DisplayName => CharacterId.ToString();
    }
}