using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class EventSubGroupData : TblNodeData
    {
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}