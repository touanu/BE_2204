using BE2024.DataAccess.Implementations.Buoi10;
using BE2024.DataAccess.Objects;
using BE2024.DataAccess.Objects.Buoi10;
using System;

namespace CSharpCoBan.BTVN
{
    internal class Buoi10
    {
        private RoomManagement roomManagement = new RoomManagement();
        private BookingManagement bookingManagement = new BookingManagement();
        internal void BaiTap()
        {
            bool showMenu;
            do
            {
                showMenu = Menu();
            } while (showMenu);
        }
        internal bool Menu()
        {
            Console.Clear();
            Console.Write($@"
                         ------   Quản lý danh sách phòng   ------
                        | 1.  Thêm phòng mới
                        | 2.  Xoá phòng theo ID
                        | 3.  Sửa thông tin phòng
                         ------ Quản lý thông tin đặt phòng ------
                        | 4.  Thêm thông tin đặt phòng
                        | 5.  Xoá thông tin đặt phòng
                        | 7.  Sửa thông tin đặt phòng
                         -----------------------------------------
                        | 8.  Đặt phòng và thanh toán
                        | 9.  Huỷ đặt phòng
                        | 10. Xem lịch sử đặt phòng
                        | 0.  Thoát chương trình
                         -----------------------------------------

                        Lựa chọn: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddNewRoom();
                    return true;
                case "2":
                    DeleteRoom();
                    return true;
                case "3":
                    UpdateRoom();
                    return true;
                case "4":
                    AddOrder();
                    return true;
                case "5":
                    RemoveOrder();
                    return true;
                case "6":
                    UpdateOrder();
                    return true;
                case "7":
                    BookARoom();
                    return true;
                case "8":

                    return true;
                case "9":

                    return true;
                case "10":

                    return true;
                case "11":

                    return true;
                default:
                    return false;
            }
        }
        
        private void AddNewRoom()
        {
            Console.WriteLine("Chọn loại phòng: ");
            Console.WriteLine("1. Phòng đơn");
            Console.WriteLine("2. Phòng đôi (mặc định)");
            Console.WriteLine("3. Phòng gia đình");
            Console.Write("Lựa chọn: ");

            Room room;
            switch (Input.Integer(false, 1, 3))
            {
                case 1:
                    room = new SingleRoom();
                    break;
                case 2:
                    room = new DoubleRoom();
                    break;
                case 3:
                    room = new FamilyRoom();
                    break;
                default:
                    room = new DoubleRoom();
                    break;
            }

            Console.Write("\nNhập vào số phòng: ");
            room.RoomId = Input.Integer(false);
            
            ReturnData result = roomManagement.AddRoom(room);
            Console.WriteLine(result.Message);
        }
    
        private void DeleteRoom()
        {
            Console.Write("Nhập vào số phòng cần xoá: ");
            int roomId = Input.Integer(false);

            ReturnData result = roomManagement.RemoveRoom(roomId);
            Console.WriteLine(result.Message);
        }

        private void UpdateRoom()
        {
            Console.WriteLine("Chọn loại phòng: ");
            Console.WriteLine("1. Phòng đơn");
            Console.WriteLine("2. Phòng đôi (mặc định)");
            Console.WriteLine("3. Phòng gia đình");
            Console.Write("Lựa chọn: ");

            Room room;
            switch (Input.Integer(false, 1, 3))
            {
                case 1:
                    room = new SingleRoom();
                    break;
                case 2:
                    room = new DoubleRoom();
                    break;
                case 3:
                    room = new FamilyRoom();
                    break;
                default:
                    room = new DoubleRoom();
                    break;
            }

            Console.Write("\nNhập vào số phòng: ");
            room.RoomId = Input.Integer(false);

            Console.Write("Trạng thái thuê: Y/N?");
            switch (Console.ReadLine())
            {
                case "Y":
                    room.IsRented = true;
                    break;
                case "N":
                    room.IsRented = false;
                    break;
                default:
                    room.IsRented = false;
                    break;
            }

            ReturnData result = roomManagement.UpdateRoom(room);
            Console.WriteLine(result.Message);
        }

        private void AddOrder()
        {
            BookingOrder bookingOrder = new BookingOrder();
            Console.Write("Nhập vào tên khách hàng: ");
            bookingOrder.CustomerName = Console.ReadLine();
            Console.Write("Nhập vào số phòng muốn đặt: ");
            bookingOrder.RoomId = Input.Integer();
            
            ReturnData result = bookingManagement.Add(bookingOrder, ref roomManagement);
            Console.WriteLine(result.Message);
        }

        private void RemoveOrder()
        {
            Console.Write("Nhập vào mã thông tin mà bạn muốn xoá: ");
            int orderId = Input.Integer();

            ReturnData result = bookingManagement.Delete(orderId);
            Console.WriteLine(result.Message);
        }

        private void UpdateOrder()
        {
            BookingOrder order = new BookingOrder();
            Console.Write("Nhập vào mã thông tin bạn muốn cập nhật: ");
            order.OrderId = Input.Integer();
            Console.Write("Nhập vào tên khách hàng mới: ");
            order.CustomerName = Console.ReadLine();
            Console.Write("Nhập vào số phòng mới: ");
            order.RoomId = Input.Integer();
            Console.Write("Nhập vào ngày đặt phòng: ");
            order.BookingDate = Input.Date();
            Console.Write("Nhập vào ngày trả phòng: ");
            order.ReturnDate = Input.Date();
            Console.Write("Nhập vào tổng tiền: ");
            order.Price = Input.Integer();

            ReturnData result = bookingManagement.Update(order, ref roomManagement);
            Console.WriteLine(result.Message);
        }

        private void BookARoom()
        {
            BookingOrder bookingOrder = new BookingOrder();
            Console.Write("Nhập vào tên khách hàng: ");
            bookingOrder.CustomerName = Console.ReadLine();

            Console.WriteLine("Chọn loại phòng: ");
            Console.WriteLine("1. Phòng đơn");
            Console.WriteLine("2. Phòng đôi (mặc định)");
            Console.WriteLine("3. Phòng gia đình");
            Console.Write("Lựa chọn: ");
            int roomType = Input.Integer(false, 1, 3);
            bookingOrder.RoomId = roomManagement.GetAvaiableRoomId(roomType);
            bookingOrder.Price = roomManagement.GetPerNightPrice(roomType);

            ReturnData changeStatusResult = roomManagement.ChangeRentedStatus(bookingOrder.RoomId);
            if (changeStatusResult.ErrorCode == (int)ErrorCode.NotAvailable)
            {
                Console.WriteLine(changeStatusResult.Message);
                return;
            }

            ReturnData result = bookingManagement.Add(bookingOrder, ref roomManagement);
            Console.WriteLine(result.Message);
        }

        private void CancelABooking()
        {

        }

        private void ShowOrderHistory()
        {
            Console.Write("Nhập vào số lượng bạn muốn hiện thị: ");
            
        }
    }
}
