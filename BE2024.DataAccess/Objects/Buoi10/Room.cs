using System;

namespace BE2024.DataAccess.Objects.Buoi10
{
    public abstract class Room
    {
        public int RoomId { get; set; }
        public bool IsRented { get; set; }
        public abstract int Type { get; }
        public abstract double Price { get; }
        public double CalculatePrice(TimeSpan nights)
        {
            double stayedNights = nights.TotalDays;
            return stayedNights * Price;
        }
    }

    public class SingleRoom : Room
    {
        public override int Type => 1;
        public override double Price => 600000;
        
    }

    public class DoubleRoom : Room
    {
        public override int Type => 2;
        public override double Price => 800000;
    }

    public class FamilyRoom : Room
    {
        public override int Type => 3;
        public override double Price => 1000000;
    }

    public enum RoomType
    {
        Single = 1,
        Double = 2,
        Family = 3
    }
}
