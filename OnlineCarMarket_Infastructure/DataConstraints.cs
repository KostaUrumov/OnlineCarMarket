using Microsoft.Data.SqlClient.DataClassification;

namespace OnlineCarMarket_Infastructure
{
    public class DataConstraints
    {
        public class Car
        {
            public const int MinModelNameLength = 2;
            public const int MaxModelNameLength = 20;

            public const int MinMilage = 1000;
            public const int MaxMilage = 1000000;

            public const double MinPrice = 0.0;
            public const double MaxPrice = double.MaxValue;

            public const int MinNumberDoors = 1;
            public const int MaximumNumberDoors = 5;
        }

        public class Country
        {
            public const int MinCountryNameLength = 3;
            public const int MaxCountryNameLength = 56;
        }

        public class Engine
        {
            public const int MinHorsePower = 5;
            public const int MaxHorsePower = int.MaxValue;


            public const int MinVolume = 100;
            public const int MaxVolume = int.MaxValue;

            public const double MinConsumption = 0.0;
            public const double MaxConsumption = 80.0;
        }

        public class EngyneType
        {
            public const int MinFuelLength = 2;
            public const int MaxFuelLength = 50;
        }

        public class Manufacturer
        {
            public const int MinManufacturerNameLength = 2;
            public const int MaxManufacturerNameLength = 100;
        }

        public class User
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;
            
        }

    }
}
