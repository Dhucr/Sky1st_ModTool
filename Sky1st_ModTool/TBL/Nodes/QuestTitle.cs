using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class QuestTitle : TblNodeData
    {
        [FieldOrder(0)]
        public ushort Id;

        [FieldOrder(1)]
        public int Int1;

        [FieldOrder(2)]
        public short Empty1;

        [FieldOrder(3)]
        [FieldOffset(FieldType.String)]
        public string? QuestName;

        [FieldOrder(4)]
        [FieldOffset(FieldType.String)]
        public string? QuestGiver;

        [FieldOrder(5)]
        public short Short1;

        [FieldOrder(6)]
        public int Int2;

        [FieldOrder(7)]
        public short Empty2;

        [FieldOrder(8)]
        [FieldOffset(FieldType.String)]
        public string? FileName;

        [FieldOrder(9)]
        public int Int3;

        [FieldOrder(10)]
        public int Int4;

        [FieldOrder(11)]
        public byte Byte1;

        [FieldOrder(12)]
        public byte Byte2;

        [FieldOrder(13)]
        public byte Byte3;

        [FieldOrder(14)]
        public byte Byte4;

        [FieldOrder(15)]
        public byte Byte5;

        [FieldOrder(16)]
        public byte Byte6;

        [FieldOrder(17)]
        public byte Byte7;

        [FieldOrder(18)]
        public byte Byte8;

        [FieldOrder(19)]
        public byte Byte9;

        [FieldOrder(20)]
        public byte Byte10;

        [FieldOrder(21)]
        public byte Byte11;

        [FieldOrder(22)]
        public byte Byte12;

        [FieldOrder(23)]
        public byte Byte13;

        [FieldOrder(24)]
        public byte Byte14;

        [FieldOrder(25)]
        public byte Byte15;

        [FieldOrder(26)]
        public byte Byte16;

        [FieldOrder(27)]
        public int Int5;

        [FieldOrder(28)]
        public int Int6;

        [FieldOrder(29)]
        public ushort Short2;

        [FieldOrder(30)]
        public int Int7;

        [FieldOrder(31)]
        public short Empty3;

        [FieldOrder(32)]
        [FieldOffset(FieldType.String)]
        public string? QuestNumber;

        [FieldOrder(33)]
        [FieldOffset(FieldType.String)]
        public string? CompletionComment;

        [FieldOrder(34)]
        public long Empty4;

        [JsonIgnore]
        public override string? DisplayName => QuestName;
    }
}