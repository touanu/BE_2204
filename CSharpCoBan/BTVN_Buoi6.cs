using System;
using System.Collections.Generic;

namespace CSharpCoBan
{
    internal class BTVN_Buoi6
    {
        public struct HocSinh
        {
            public HocSinh(string hoTen, DateTime ngaySinh)
            {
                HoTen = hoTen;
                NgaySinh = ngaySinh;
            }
            public string HoTen { get; set; }
            public DateTime NgaySinh { get; set; }
        }
        internal void Menu()
        {
            Console.Write("Chọn bài tập: ");
            int luaChon = Nhap.SoNguyen(false, 0, 3);

            switch (luaChon)
            {
                case 1:
                    Bai1.Chay();
                    break;
                case 2:
                    Bai2.Chay();
                    break;
                case 3:
                    Bai3.Chay();
                    break;
                default:
                    break;
            }
        }
        internal class Bai1
        {
            public class Generic<T>
            {
                public int Count = 0;
                public List<T> list = new List<T> { };
                public void Add(T item)
                {
                    list.Add(item);
                    Count++;
                }
                public void Delete(int index)
                {
                    list.RemoveAt(index);
                    Count--;
                }
                public T Get(int index)
                {
                    return list[index];
                }
                public int Search(T item)
                {
                    if (item == null) { return -1; }
                    return list.FindIndex(c => c.Equals(item));
                }
            }

            internal static void Chay()
            {
                Generic<HocSinh> dsHocSinh = new Generic<HocSinh>();
                int luaChon;

                do
                {
                    Console.Clear();
                    Console.Write($@"
                        1. Thêm học sinh mới
                        2. Hiện thị tất cả học sinh
                        3. Tìm kiếm học sinh
                        0. Thoát chương trình

                        Lựa chọn: ");

                    luaChon = Nhap.SoNguyen(false, 0, 3);

                    switch (luaChon)
                    {
                        case 1:
                            ThemSachVaoDS(ref dsHocSinh);
                            break;
                        case 2:
                            InToanBoHS(dsHocSinh);
                            break;
                        case 3:
                            TimKiemHS(dsHocSinh);
                            break;
                        default:
                            break;
                    }

                    Console.ReadLine();
                } while (luaChon != 0);
            }

            internal static void ThemSachVaoDS(ref Generic<HocSinh> dsHocSinh)
            {
                var HS = new HocSinh();
                Console.WriteLine("\nNhập vào các thông tin của học sinh");
                Console.Write("Họ tên: ");
                HS.HoTen = Console.ReadLine();
                Console.Write("Tuổi: ");
                HS.NgaySinh = Nhap.NgayThang();

                dsHocSinh.Add(HS);
                Console.WriteLine($"Đã thêm {HS.HoTen} vào danh sách!");
            }

            internal static void InToanBoHS(Generic<HocSinh> dsHocSinh)
            {
                Console.WriteLine("\nTất cả học sinh có trong danh sách:");
                for (int i = 0; i < dsHocSinh.Count; i++)
                {
                    HocSinh hs = dsHocSinh.Get(i);
                    Console.WriteLine("Em " + hs.HoTen + ": " + hs.NgaySinh);
                }
            }

            internal static void TimKiemHS(Generic<HocSinh> dsHocSinh)
            {
                Console.Write("\nNhập họ tên của học sinh cần tìm: ");
                string hoTen = Nhap.Ten();
                Console.Write("Tuổi: ");
                DateTime ngaySinh = Nhap.NgayThang();

                HocSinh hocSinh = new HocSinh(hoTen, ngaySinh);

                int index = dsHocSinh.Search(hocSinh);
                Console.WriteLine("Tìm thấy học sinh này ở vị trí " + (index+1) + " trong danh sách!");
            }
        }
        internal class Bai2
        {
            public class SinhVien
            {
                private readonly HashSet<HocSinh> dsSinhVien = new HashSet<HocSinh>();
                public int Count
                { 
                    get
                    { return dsSinhVien.Count; }
                }
                public void AddItem(string hoTen, DateTime ngaySinh)
                {
                    var sv = new HocSinh(hoTen, ngaySinh);
                    dsSinhVien.Add(sv);
                }
                public HocSinh? GetItem(string hoTen)
                {
                    foreach (var item in dsSinhVien)
                    {
                        if (item.HoTen == hoTen)
                        {
                            return item;
                        }
                    }

                    return null;
                }
            }

            internal static void Chay()
            {
                SinhVien dsSV = new SinhVien();
                int luaChon;

                do
                {
                    Console.Clear();
                    Console.Write($@"
                        1. Thêm sinh viên mới
                        2. Hiện thị tất cả sinh viên
                        3. Tìm kiếm tuổi của sinh viên
                        0. Thoát chương trình

                        Lựa chọn: ");

                    luaChon = Nhap.SoNguyen(false, 0, 3);

                    switch (luaChon)
                    {
                        case 1:
                            ThemSachVaoDS(ref dsSV);
                            break;
                        case 2:
                            TimKiemSV(dsSV);
                            break;
                        default:
                            break;
                    }

                    Console.ReadLine();
                } while (luaChon != 0);
            }
            static void ThemSachVaoDS(ref SinhVien dsSV)
            {
                Console.WriteLine("\nNhập vào các thông tin của sinh viên");
                Console.Write("Họ tên: ");
                string hoTen = Console.ReadLine();
                Console.Write("Ngày sinh: ");
                DateTime ngaySinh = Nhap.NgayThang();

                dsSV.AddItem(hoTen, ngaySinh);
                Console.WriteLine($"Đã thêm {hoTen} vào danh sách!");
            }

            internal static void TimKiemSV(SinhVien dsSV)
            {
                Console.Write("\nNhập họ tên của học sinh cần tìm: ");
                string hoTen = Nhap.Ten();

                var sv = dsSV.GetItem(hoTen);

                if (sv == null)
                {
                    Console.WriteLine("Sinh viên này không tồn tại trong danh sách!");
                    return;
                }


                Console.WriteLine($"{hoTen}: {sv.Value.NgaySinh}");
            }
        }

        internal class Bai3
        {
            public static void Swap<T> (ref T t1, ref T t2)
            {
                T tam = t1;
                t1 = t2;
                t2 = tam;
                
            }
            public static void Chay()
            {
                var bienThuNhat = "111@";
                var bienThuHai = "222@";
                Console.WriteLine("Biến thứ nhất: " + bienThuNhat + " | Biến thứ hai: " + bienThuHai);
                Swap(ref bienThuNhat, ref bienThuHai);
                Console.WriteLine("Sau khi Swap():\nBiến thứ nhất: " + bienThuNhat + " | Biến thứ hai: " + bienThuHai);
            }
        }
    }
}
