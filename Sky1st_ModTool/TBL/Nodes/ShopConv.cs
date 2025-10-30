using Newtonsoft.Json;
using Sky1st_ModTool.TBL.Model;

namespace Sky1st_ModTool.TBL.Nodes
{
    public class ShopConv : TblNodeData
    {
        [FieldOrder(0)]
        public uint Id;

        [FieldOrder(1)]
        public float EarthSepithExchangeRate;

        [FieldOrder(2)]
        public float WaterSepithExchangeRate;

        [FieldOrder(3)]
        public float FireSepithExchangeRate;

        [FieldOrder(4)]
        public float WindSepithExchangeRate;

        [FieldOrder(5)]
        public float TimeSepithExchangeRate;

        [FieldOrder(6)]
        public float SpaceSepithExchangeRate;

        [FieldOrder(7)]
        public float MirageSepithExchangeRate;

        [FieldOrder(8)]
        public float SepithMassExchangeRate;

        [JsonIgnore]
        public override string? DisplayName => Id.ToString();
    }
}