using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class FaceAnimeData : TblNodeData
    {
        [FieldOrder(0)]
        public long Long1;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Text1;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Text2;

        [JsonIgnore]
        public override string? DisplayName => "Item";
    }
}