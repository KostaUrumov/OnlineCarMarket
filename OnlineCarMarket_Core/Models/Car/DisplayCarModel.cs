namespace OnlineCarMarket_Core.Models.Car
{
    public class DisplayCarModel
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public string Manifacturer { get; set; } = null!;
        public string FirstRegistration { get; set; } = null!;
        public int EngineVolume { get; set; }
        public int EnginePower { get; set; }
        public string Price { get; set; } = null!;

        public bool isObserved { get; set; } = false;
    }
}
