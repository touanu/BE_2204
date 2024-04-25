using System;

namespace BE2024.DataAccess.Objects.Buoi10
{
    public class BookingOrder
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int RoomId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public double Price { get; set; }
    }
}
