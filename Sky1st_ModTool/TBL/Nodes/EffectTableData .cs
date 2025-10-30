using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class EffectTableData : TblNodeData
    {
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Filename1;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Filename2;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}