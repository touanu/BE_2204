using BE2024.DataAccess.Objects;
using BE2024.DataAccess.Objects.Buoi10;
using CommonLibs;

namespace BE2024.DataAccess.Layers.Buoi10
{
    internal interface IRoomManagement
    {
        ReturnData AddRoom(Room room);
        ReturnData UpdateRoom(Room room);
        ReturnData RemoveRoom(int roomId);
        
    }
}
