using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class BooksTitle : TblNodeData
    {
        [FieldOrder(0)]
        public short Id;

        [FieldOrder(1)]
        public int CategoryId;

        [FieldOrder(2)]
        public short Empty1;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? Title;

        [FieldOrder(4)]
        public ushort Short1;

        [FieldOrder(5)]
        public ushort Short2;

        [FieldOrder(6)]
        public int Empty2;

        [JsonIgnore]
        public override string? DisplayName => Title;
    }
}