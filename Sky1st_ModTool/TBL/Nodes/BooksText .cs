using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class BooksText : TblNodeData
    {
        [FieldOrder(0)]
        public short BookId;

        [FieldOrder(1)]
        public int PageId;

        [FieldOrder(2)]
        public short Empty1;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? BookText;

        [FieldOrder(4)]
        [FieldOffset(FieldType.String)]
        public string? Texture;

        [JsonIgnore]
        public override string? DisplayName => BookText;
    }
}