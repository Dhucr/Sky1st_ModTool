using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class SupportLevelData : TblNodeData
    {
        [FieldOrder(0)]
        public ushort ChrId;

        [FieldOrder(1)]
        public ushort Level;

        [FieldOrder(2)]
        public int ExpRequirement;

        [FieldOrder(3)]
        public int AbilityId;

        [JsonIgnore]
        public override string? DisplayName => AbilityId.ToString();
    }
}