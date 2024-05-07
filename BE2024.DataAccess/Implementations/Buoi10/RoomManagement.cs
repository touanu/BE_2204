using BE2024.DataAccess.Layers.Buoi10;
using BE2024.DataAccess.Objects;
using BE2024.DataAccess.Objects.Buoi10;
using System.Collections.Generic;

namespace BE2024.DataAccess.Implementations.Buoi10
{
    public class RoomManagement : IRoomManagement
    {
        private List<Room> rooms = new List<Room>();

        public ReturnData AddRoom(Room room)
        {
            ReturnData returnData = new ReturnData();
            if (room == null)
            {
                returnData.ErrorCode = (int)ErrorCode.EqualNull;
                returnData.Message = "Phòng không được để trống!";
                return returnData;
            }

            if (room.RoomId < 100)
            {
                returnData.ErrorCode = (int)ErrorCode.Invalid;
                returnData.Message = "Id không hợp lệ!";
                return returnData;
            }

            rooms.Add(room);
            return returnData;
        }

        public ReturnData RemoveRoom(int roomId)
        {
            ReturnData returnData = new ReturnData();
            
            if (roomId < 100)
            {
                returnData.ErrorCode = (int)ErrorCode.Invalid;
                returnData.Message = "Id phòng không hợp lệ!";
                return returnData;
            }

            Room removeRoom = rooms.Find(item => item.RoomId == roomId);

            if (removeRoom == null)
            {
                returnData.ErrorCode = (int)ErrorCode.NotExist;
                returnData.Message = "Id phòng này không tồn tại!";
                return returnData;
            }

            rooms.Remove(removeRoom);
            return returnData;
        }

        public ReturnData UpdateRoom(Room room)
        {
            ReturnData returnData = new ReturnData();

            if (room == null)
            {
                returnData.ErrorCode = (int)ErrorCode.EqualNull;
                returnData.Message = "Thông tin không được để trống!";
                return returnData;
            }

            if (room.RoomId < 100)
            {
                returnData.ErrorCode = (int)ErrorCode.Invalid;
                returnData.Message = "Id phòng không hợp lệ!";
                return returnData;
            }

            int index = rooms.FindIndex(item => item.RoomId == room.RoomId);
            if (index == -1)
            {
                returnData.ErrorCode = (int)ErrorCode.NotExist;
                returnData.Message = "Id phòng này không tồn tại!";
                return returnData;
            }

            rooms[index] = room;
            return returnData;
        }
    
        public bool Contains(int roomId)
        {
            Room room = rooms.Find(item => item.RoomId == roomId);
            return room != null;
        }

        public int GetAvaiableRoomId(int typeOfRoom)
        {
            return rooms.FindIndex(item => item.Type == typeOfRoom && item.IsRented == false);
        }

        public double GetPerNightPrice(int roomId)
        {
            Room room = rooms.Find(item => item.RoomId == roomId);
            return room.Price;
        }

        public ReturnData ChangeRentedStatus(int roomId)
        {
            Room room = rooms.Find(item => item.RoomId == roomId);

            if (room.IsRented == true)
            {
                ReturnData returnData = new ReturnData
                {
                    ErrorCode = (int)ErrorCode.NotAvailable,
                    Message = "Phòng này đã được thuê rồi!"
                };
                return returnData;
            }

            room.IsRented = true;
            return UpdateRoom(room);
        }
    }
}
