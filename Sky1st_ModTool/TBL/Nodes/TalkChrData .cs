using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class TalkChrData : TblNodeData
    {
        [FieldOrder(0)]
        public int Int1;

        [FieldOrder(1)]
        public int Int2;

        [JsonIgnore]
        public override string? DisplayName => Int1.ToString();
    }
}