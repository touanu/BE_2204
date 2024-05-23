// See https://aka.ms/new-console-template for more information
using CSharpCoBan;
using EmployeesDB;
using EmployeesDB.DataAccess.Objects;
using EmployeesDB.DataAccess.Services;

var employeesDB = new EmployeerServices();
string? luaChon;
do
{
    Console.Clear();
    Console.Write($@"
                        1. Thêm nhân viên
                        2. Sửa thông tin nhân viên
                        3. Xoá nhân viên khỏi CSDL
                        4. Tìm kiếm nhân viên theo tên
                        5. Tìm kiếm nhân viên theo truyền may
                        6. Xuất báo cáo
                        0. Thoát chương trình

                        Lựa chọn: ");

    luaChon = Console.ReadLine();

    switch (luaChon)
    {
        case "1":
            {
                Console.WriteLine("Nhập vào thông tin cho nhân viên mới:");
                Employeer employeer = new();

                Console.Write("Họ tên nhân viên: ");
                employeer.FullName = Console.ReadLine();
                Console.Write("Nhập vào ngày sinh: ");
                employeer.Birthday = Input.Date();
                var returnData = await employeesDB.Create(employeer);

                Console.WriteLine($"Code {returnData.ErrorCode}: {returnData.Message}");
                break;
            }
        case "2":
            {
                Console.Write("Nhập vào mã nhân viên cần sửa: ");
                int employeerID = Input.Integer(false);
                var employeer = await employeesDB.GetEmployeerByID(employeerID);

                if (employeer == null)
                {
                    Console.WriteLine("Nhân viên này không tồn tại!");
                    break;
                }

                Console.Write("Họ tên nhân viên: ");
                employeer.FullName = Console.ReadLine();
                Console.Write("Nhập vào ngày sinh: ");
                employeer.Birthday = Input.Date();
                var returnData = await employeesDB.Update(employeer);

                Console.WriteLine($"Code {returnData.ErrorCode}: {returnData.Message}");
                break;
            }
        case "3":
            {
                Console.Write("Nhập vào mã nhân viên cần sửa: ");
                int employeerID = Input.Integer(false);
                var returnData = await employeesDB.Delete(employeerID);
                Console.WriteLine($"Code {returnData.ErrorCode}: {returnData.Message}");
                break;
            }
        case "4":
            {
                Console.Write("Nhập vào tên nhân viên: ");
                string? employeerName = Console.ReadLine();

                if (string.IsNullOrEmpty(employeerName))
                {
                    Console.WriteLine("Tên nhân viên không được để trống!");
                    break;
                }

                var employeers = await employeesDB.GetEmployeerByName(employeerName);

                if (employeers.Count == 0)
                {
                    Console.WriteLine("Không tồn tại nhân viên này!");
                    break;
                }

                Console.WriteLine(Helper.WriteEmployeer(employeers));
                break;
            }
        case "5":
            {
                Console.Write("Nhập vào mã truyền máy: ");
                int processID = Input.Integer();

                var employeer = await employeesDB.GetEmployeerByProcessID(processID);

                if (employeer == null)
                {
                    Console.WriteLine("Không tồn tại nhân viên này!");
                    break;
                }

                Console.WriteLine(Helper.WriteEmployeer(employeer));
                break;
            }
        case "0":
            break;
        default:
            break;
    }

    Console.ReadLine();
} while (luaChon != "0");