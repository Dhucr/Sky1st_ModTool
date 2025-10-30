using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ConstantValue : TblNodeData
    {
        [FieldOrder(0)]
        public uint Id;

        [FieldOrder(1)]
        public uint Value1;

        [FieldOrder(2)]
        public uint Value2;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}