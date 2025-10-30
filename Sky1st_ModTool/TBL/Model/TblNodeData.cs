using Newtonsoft.Json;

namespace Sky1st_ModTool.TBL.Model
{
    public abstract class TblNodeData
    {
        [JsonIgnore]
        public abstract string? DisplayName { get; }
    }
}