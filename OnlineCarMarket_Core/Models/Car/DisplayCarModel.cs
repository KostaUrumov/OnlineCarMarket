namespace OnlineCarMarket_Core.Models.Car
{
    public class DisplayCarModel
    {
        public string Model { get; set; } = null!;
        public string Manifacturer { get; set; } = null!;
        public string FirstRegistration { get; set; } = null!;
        public int EngineVolume { get; set; }
        public int EnginePower { get; set; }
    }
}
