using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class BattleEnemyLevelAdjust : TblNodeData
    {
        [FieldOrder(0)]
        [FieldOffset(FieldType.String)]
        public string? Monster;

        [FieldOrder(1)]
        public int Int1;

        [FieldOrder(2)]
        public int Int2;

        [JsonIgnore]
        public override string? DisplayName => Monster;
    }
}