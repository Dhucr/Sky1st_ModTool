using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ItemShopTabType : TblNodeData
    {
        [FieldOrder(0)]
        public int Unknown1;

        [FieldOrder(1)]
        public int Unknown2;

        [JsonIgnore]
        public override string? DisplayName => Unknown1.ToString();
    }
}