using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class DLCAppIDConvertTableData : TblNodeData
    {
        [FieldOrder(0)]
        public int DlcId;

        [FieldOrder(1)]
        public int ConvertItemId;

        [JsonIgnore]
        public override string? DisplayName => DlcId.ToString();
    }
}