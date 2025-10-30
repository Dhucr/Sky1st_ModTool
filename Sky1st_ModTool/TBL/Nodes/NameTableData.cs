using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class NameTableData : TblNodeData
    {
        [FieldOrder(0)]
        public ulong CharacterId;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [FieldOrder(2)]
        [FieldOffset(FieldType.String)]
        public string? Model;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? Face;

        [FieldOrder(4)]
        [FieldOffset(FieldType.String)]
        public string? Script;

        [FieldOrder(5)]
        public ulong Long1;

        [FieldOrder(6)]
        [FieldOffset(FieldType.String)]
        public string? Text1;

        [FieldOrder(7)]
        public long Long2;

        [FieldOrder(8)]
        [FieldOffset(FieldType.String)]
        public string? Text2;

        [FieldOrder(9)]
        public ulong Long3;

        [FieldOrder(10)]
        [FieldOffset(FieldType.String)]
        public string? Text3;

        [FieldOrder(11)]
        [FieldOffset(FieldType.String)]
        public string? FullName;

        [FieldOrder(12)]
        [FieldOffset(FieldType.String)]
        public string? FullNameEn;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}