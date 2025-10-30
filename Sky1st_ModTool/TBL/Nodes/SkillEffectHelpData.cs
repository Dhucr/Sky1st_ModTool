using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class SkillEffectHelpData : TblNodeData
    {
        [FieldOrder(0)]
        public long Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Name;

        [FieldOrder(2)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count")]
        public uint[]? UnknownArr;

        [FieldOrder(3)]
        public long Count;

        [FieldOrder(4)]
        [FieldOffset(FieldType.String)]
        public string? Text1;

        [FieldOrder(5)]
        [FieldOffset(FieldType.String)]
        public string? Text2;

        [FieldOrder(6)]
        [FieldOffset(FieldType.String)]
        public string? Color;

        [FieldOrder(7)]
        [FieldOffset(FieldType.String)]
        public string? Text3;

        [FieldOrder(8)]
        public uint Unknown2;

        [FieldOrder(9)]
        public uint Unknown3;

        [FieldOrder(10)]
        [FieldOffset(FieldType.String)]
        public string? SubName;

        [FieldOrder(11)]
        [FieldOffset(FieldType.String)]
        public string? Text5;

        [JsonIgnore]
        public override string? DisplayName => Name;
    }
}