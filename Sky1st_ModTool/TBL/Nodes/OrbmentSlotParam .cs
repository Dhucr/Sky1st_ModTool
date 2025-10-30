using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class OrbmentSlotParam : TblNodeData
    {
        [FieldOrder(0)]
        public ushort Slot1;

        [FieldOrder(1)]
        public ushort Slot2;

        [FieldOrder(2)]
        public ushort Slot3;

        [FieldOrder(3)]
        public ushort Slot4;

        [FieldOrder(4)]
        public ushort Slot5;

        [FieldOrder(5)]
        public ushort Slot6;

        [FieldOrder(6)]
        public ushort Slot7;

        [FieldOrder(7)]
        public ushort Slot8;

        [FieldOrder(8)]
        public ushort Slot9;

        [FieldOrder(9)]
        public ushort Slot10;

        [FieldOrder(10)]
        public ushort Slot11;

        [FieldOrder(11)]
        public ushort Slot12;

        [FieldOrder(12)]
        public ushort Slot13;

        [FieldOrder(13)]
        public ushort Slot14;

        [JsonIgnore]
        public override string? DisplayName => "Item";
    }
}