using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class CostumeParam : TblNodeData
    {
        [FieldOrder(0)]
        public short CharacterId;

        [FieldOrder(1)]
        public short Shrt1;

        [FieldOrder(2)]
        public short ItemId;

        [FieldOrder(3)]
        public short Shrt3;

        [FieldOrder(4)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [FieldOrder(5)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [FieldOrder(6)]
        public uint Int3;

        [FieldOrder(7)]
        public uint Int4;

        [FieldOrder(8)]
        [FieldOffset(FieldType.String)]
        public string? AttachName;

        [FieldOrder(9)]
        [FieldOffset(FieldType.String)]
        public string? Text4;

        [FieldOrder(10)]
        [FieldOffset(FieldType.String)]
        public string? Text5;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}