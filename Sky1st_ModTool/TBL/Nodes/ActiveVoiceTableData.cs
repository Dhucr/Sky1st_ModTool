using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ActiveVoiceTableData : TblNodeData
    {
        [FieldOrder(0)]
        public ulong Id;

        [FieldOrder(1)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("CharIdCount")]
        public ushort[]? CharIds;

        [FieldOrder(2)]
        public long CharIdCount;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? Filename;

        [FieldOrder(4)]
        public long TypeId;

        [FieldOrder(5)]
        [FieldOffset(FieldType.String)]
        public string? Tag;

        [FieldOrder(6)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count1")]
        public ushort[]? Array1;

        [FieldOrder(7)]
        public long Count1;

        [FieldOrder(8)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count2")]
        public ushort[]? Array2;

        [FieldOrder(9)]
        public long Count2;

        [FieldOrder(10)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("Count3")]
        public ushort[]? Array3;

        [FieldOrder(11)]
        public long Count3;

        [FieldOrder(12)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("VoiceIdCount")]
        public uint[]? VoiceIds;

        [FieldOrder(13)]
        public long VoiceIdCount;

        [FieldOrder(14)]
        [FieldOffset(FieldType.String)]
        public string? Dialogue;

        [FieldOrder(15)]
        public long Unknown;

        [JsonIgnore]
        public override string? DisplayName => Dialogue;
    }
}