using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ConditionTypeParam : TblNodeData
    {
        [FieldOrder(0)]
        public uint Id;

        [FieldOrder(1)]
        public uint Value;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}