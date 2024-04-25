using BE2024.DataAccess.Layers.Buoi10;
using BE2024.DataAccess.Objects;
using BE2024.DataAccess.Objects.Buoi10;
using CommonLibs;
using System;
using System.Collections.Generic;

namespace BE2024.DataAccess.Implementations.Buoi10
{
    public class BookingManagement : IBookingManagement
    {
        private List<BookingOrder> orders = new List<BookingOrder>();

        public ReturnData Add(BookingOrder order, ref RoomManagement roomManager)
        {
            ReturnData returnData = new ReturnData();

            if (order.OrderId < 0)
            {
                returnData.ErrorCode = (int)ErrorCode.Invalid;
                returnData.Message = "Id không hợp lệ!";
                return returnData;
            }

            if (GetOrderById(order.OrderId) != null)
            {
                returnData.ErrorCode = (int)ErrorCode.AlreadyExist;
                returnData.Message = "Mã sản phẩm này đã tồn tại!";
                return returnData;
            }

            if (!Validation.IsName(order.CustomerName))
            {
                returnData.ErrorCode = (int)ErrorCode.Invalid;
                returnData.Message = "Tên khách hàng không hợp lệ!";
                return returnData;
            }

            if (order.RoomId == -1)
            {
                returnData.ErrorCode = (int)ErrorCode.NotAvailable;
                returnData.Message = "Đã hết phòng thuộc loại này!";
                return returnData;
            }

            if (!roomManager.Contains(order.RoomId))
            {
                returnData.ErrorCode = (int)ErrorCode.NotExist;
                returnData.Message = "Không tồn tại mã phòng này!";
                return returnData;
            }

            if (order.Price < 0)
            {
                returnData.ErrorCode = (int)ErrorCode.Invalid;
                returnData.Message = "Giá tiền không hợp lệ!";
                return returnData;
            }

            order.OrderId = orders.Count;
            order.BookingDate = DateTime.Now;

            orders.Add(order);
            return returnData;
        }

        public ReturnData Delete(int orderId)
        {
            ReturnData returnData = new ReturnData();
            BookingOrder order = orders.Find(x => x.OrderId == orderId);

            if (order == null)
            {
                returnData.ErrorCode = (int)ErrorCode.NotExist;
                returnData.Message = "Thông tin đặt phòng này không tồn tại!";
                return returnData;
            }

            orders.Remove(order);
            return returnData;
        }

        public ReturnData Update(BookingOrder order, ref RoomManagement roomManager)
        {
            ReturnData returnData = new ReturnData();
            int index = orders.FindIndex(item => item.OrderId == order.OrderId);
            
            if (index == -1)
            {
                returnData.ErrorCode = (int)ErrorCode.NotExist;
                returnData.Message = "Không tồn tại thông tin này!";
                return returnData;
            }

            if (GetOrderById(order.OrderId) != null)
            {
                returnData.ErrorCode = (int)ErrorCode.AlreadyExist;
                returnData.Message = "Mã sản phẩm này đã tồn tại!";
                return returnData;
            }

            if (!Validation.IsName(order.CustomerName))
            {
                returnData.ErrorCode = (int)ErrorCode.Invalid;
                returnData.Message = "Tên khách hàng không hợp lệ!";
                return returnData;
            }

            if (!roomManager.Contains(order.RoomId))
            {
                returnData.ErrorCode = (int)ErrorCode.NotExist;
                returnData.Message = "Không tồn tại mã phòng này!";
                return returnData;
            }

            if (order.Price < 0)
            {
                returnData.ErrorCode = (int)ErrorCode.Invalid;
                returnData.Message = "Giá tiền không hợp lệ!";
                return returnData;
            }

            orders[index] = order;
            return returnData;
        }

        public BookingOrder GetOrderById(int id)
        {
            return orders.Find(item => item.OrderId == id);
        }
    }
}
