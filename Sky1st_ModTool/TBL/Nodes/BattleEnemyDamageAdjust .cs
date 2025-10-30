using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class BattleEnemyDamageAdjust : TblNodeData
    {
        [FieldOrder(0)]
        public int Level;

        [FieldOrder(1)]
        public int Ratio;

        [JsonIgnore]
        public override string? DisplayName => Level.ToString();
    }
}