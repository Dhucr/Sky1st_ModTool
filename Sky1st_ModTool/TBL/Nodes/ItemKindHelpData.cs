using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ItemKindHelpData : TblNodeData
    {
        [FieldOrder(0)]
        public ushort Id;

        [FieldOrder(1)]
        public ushort SubId1;

        [FieldOrder(2)]
        public uint SubId2;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? Description;

        [FieldOrder(4)]
        public long TextShowType;

        [FieldOrder(5)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}