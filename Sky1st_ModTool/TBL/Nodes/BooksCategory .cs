using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class BooksCategory : TblNodeData
    {
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? CategoryName;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Unused;

        [JsonIgnore]
        public override string? DisplayName => CategoryName;
    }
}