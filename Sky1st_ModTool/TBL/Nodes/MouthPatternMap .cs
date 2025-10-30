using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class MouthPatternMap : TblNodeData
    {
        [FieldOrder(0)]
        public ushort Ushort1;

        [JsonIgnore]
        public override string? DisplayName => Ushort1.ToString();
    }
}