using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ItemTabType : TblNodeData
    {
        [FieldOrder(0)]
        public int ID;

        [FieldOrder(1)]
        public int Unknown2;

        [FieldOrder(2)]
        public int Unknown3;

        [JsonIgnore]
        public override string? DisplayName => ID.ToString();
    }
}