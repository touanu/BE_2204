using BE2024.DataAccess.Implementations.Buoi10;
using BE2024.DataAccess.Objects;
using BE2024.DataAccess.Objects.Buoi10;

namespace BE2024.DataAccess.Layers.Buoi10
{
    internal interface IBookingManagement
    {
        ReturnData Add(BookingOrder order, ref RoomManagement roomManager);
        ReturnData Update(BookingOrder order, ref RoomManagement roomManager);
        ReturnData Delete(int orderId);
    }
}
