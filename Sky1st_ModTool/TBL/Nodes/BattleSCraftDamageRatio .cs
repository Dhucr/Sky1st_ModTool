using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class BattleSCraftDamageRatio : TblNodeData
    {
        [FieldOrder(0)]
        public short Ratio1;

        [FieldOrder(1)]
        public short Ratio2;

        public override string? DisplayName => "Item";
    }
}