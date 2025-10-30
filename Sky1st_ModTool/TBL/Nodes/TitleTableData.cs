using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class TitleTableData : TblNodeData
    {
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Text1;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Text2;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? Filename1;

        [FieldOrder(4)]
        public int Int1;

        [FieldOrder(5)]
        public float Float1;

        [FieldOrder(6)]
        [FieldOffset(FieldType.String)]
        public string? Filename2;

        [FieldOrder(7)]
        public float Float2;

        [FieldOrder(8)]
        public int Int2;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}