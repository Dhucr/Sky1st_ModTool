using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ItemKindParam2 : TblNodeData
    {
        [FieldOrder(0)]
        public ulong ID;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? KindText;

        [JsonIgnore]
        public override string? DisplayName => KindText;
    }
}