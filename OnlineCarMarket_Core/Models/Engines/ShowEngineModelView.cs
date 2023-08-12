namespace OnlineCarMarket_Core.Models.Engines
{
    public class ShowEngineModelView
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; } = null!;
        public string FuelType { get; set; } = null!;
        public int HorsePower { get; set; }
        public int Volume { get; set; }
        public double Consumption { get; set; }
    }
}
