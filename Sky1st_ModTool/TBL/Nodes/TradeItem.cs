using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class TradeItem : TblNodeData
    {
        [FieldOrder(0)]
        public uint OfferedItemId;

        [FieldOrder(1)]
        [ArrayLength(6)]
        public ShopEffect[]? Effects;

        [JsonIgnore]
        public override string? DisplayName => OfferedItemId.ToString();
    }
}