using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class NPCParam : TblNodeData
    {
        [FieldOrder(0)]
        public long CharId;

        [FieldOrder(1)]
        [FieldOffset(FieldType.String)]
        public string? Text;

        [FieldOrder(2)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("StartScenaFlagCount")]
        public ushort[]? StartScenaFlag;

        [FieldOrder(3)]
        public long StartScenaFlagCount;

        [FieldOrder(4)]
        [FieldOffset(FieldType.Array)]
        [ArrayLength("EndScenaFlagCount")]
        public ushort[]? EndScenaFlag;

        [FieldOrder(5)]
        public int EndScenaFlagCount;

        [FieldOrder(6)]
        public float X;

        [FieldOrder(7)]
        public float Y;

        [FieldOrder(8)]
        public float Z;

        [FieldOrder(9)]
        public float OrientationAngle;

        [FieldOrder(10)]
        public float RangeInteraction;

        [FieldOrder(11)]
        public uint Int1;

        [FieldOrder(12)]
        public float Flt1;

        [FieldOrder(13)]
        public float Flt2;

        [FieldOrder(14)]
        public float Flt3;

        [FieldOrder(15)]
        public float Flt4;

        [FieldOrder(16)]
        public float Flt5;

        [FieldOrder(17)]
        [FieldOffset(FieldType.String)]
        public string? Text1;

        [FieldOrder(18)]
        [FieldOffset(FieldType.String)]
        public string? TalkSettingFunction;

        [FieldOrder(19)]
        [FieldOffset(FieldType.String)]
        public string? FirstAnimationFunction;

        [FieldOrder(20)]
        public uint Int2;

        [FieldOrder(21)]
        public uint Int3;

        [FieldOrder(22)]
        [FieldOffset(FieldType.String)]
        public string? TalkFunction;

        [FieldOrder(23)]
        [FieldOffset(FieldType.String)]
        public string? Text2;

        [FieldOrder(24)]
        public uint Int4;

        [FieldOrder(25)]
        public uint Int5;

        [FieldOrder(26)]
        [FieldOffset(FieldType.String)]
        public string? Text3;

        [FieldOrder(27)]
        public long Long1;

        [JsonIgnore]
        public override string? DisplayName => CharId.ToString();
    }
}