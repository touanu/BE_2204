using System;
using System.Text;
using System.Collections.Generic;
using static CSharpCoBan.BTVN_Buoi4;

namespace CSharpCoBan
{
    internal class BTVN_Buoi4
    {
        public struct Sach
        {
            public string TieuDe { get; set; }
            public string TacGia { get; set; }
            public int Nam { get; set; }

            public override string ToString()
            {
                return $"{TieuDe} cua {TacGia}";
            }
        }

        internal void Bai1()
        {
            var TuSach = new List<Sach>();
            int luaChon;

            do
            {
                Console.Clear();
                Console.OutputEncoding = Encoding.UTF8;
                Console.Write($@"
1. Them sach moi
2. Hien thi danh sach cac sach da them
3. Tim kiem sach theo tieu de
0. Thoat chuong trinh

Lua chon: ");

                luaChon = Nhap.SoNguyen(false, 0, 3);

                switch (luaChon)
                {
                    case 1:
                        ThemSachVaoDS(ref TuSach);
                        break;
                    case 2:
                        InToanBoSach(TuSach);
                        break;
                    case 3:
                        TimKiemSach(TuSach);
                        break;
                    default:
                        break;
                }

                Console.ReadLine();
            } while (luaChon != 0);
        }

        internal void ThemSachVaoDS(ref List<Sach> TuSach)
        {
            var Sach = new Sach();
            Console.WriteLine("\nNhap vao cac thong tin cua sach");
            Console.Write("Tieu de: ");
            Sach.TieuDe = Console.ReadLine();
            Console.Write("Tac Gia: ");
            Sach.TacGia = Console.ReadLine();
            Console.Write("Nam xuat ban: ");
            Sach.Nam = Nhap.SoNguyen(false);

            TuSach.Add(Sach);
            Console.WriteLine($"Da them quyen sach {Sach.TieuDe} vao tu sach!");
        }

        internal void InToanBoSach(List<Sach> TuSach)
        {
            foreach (var sach in TuSach)
            {
                Console.WriteLine("\nCac sach co trong tu sach:");
                Console.WriteLine(sach.ToString() + "\n");
            }
        }

        private void TimKiemSach(List<Sach> TuSach)
        {
            Console.WriteLine("\nNhap ten sach can tim: ");
            string TieuDe = Console.ReadLine();

            foreach (var sach in TuSach)
            {
                if (sach.TieuDe == TieuDe)
                {
                    Console.WriteLine("Quyen sach " + sach.TieuDe);
                    Console.WriteLine("Tac gia " + sach.TacGia);
                    Console.WriteLine("Xuat ban nam " + sach.Nam);
                }
            }
        }

        public struct HocSinh
        {
            public string HoTen { get; set; }
            public int Tuoi { get; set; }
            public float DiemTB { get; set; }
        }

        internal void Bai2()
        {
            var DSHocSinh = new List<HocSinh>();
            int luaChon;

            do
            {
                Console.Clear();
                Console.OutputEncoding = Encoding.UTF8;
                Console.Write($@"
1. Them hoc sinh moi
2. Hien thi danh sach cac hoc sinh da them
3. Tim kiem hoc sinh theo ten
0. Thoat chuong trinh

Lua chon: ");

                luaChon = Nhap.SoNguyen(false, 0, 3);

                switch (luaChon)
                {
                    case 1:
                        ThemSachVaoDS(ref DSHocSinh);
                        break;
                    case 2:
                        InToanBoHS(DSHocSinh);
                        break;
                    case 3:
                        TimKiemHS(DSHocSinh);
                        break;
                    default:
                        break;
                }

                Console.ReadLine();
            } while (luaChon != 0);
        }

        void ThemSachVaoDS(ref List<HocSinh> DSHocSinh)
        {
            var HS = new HocSinh();
            Console.WriteLine("\nNhap vao cac thong tin cua sach");
            Console.Write("Tieu de: ");
            HS.HoTen = Console.ReadLine();
            Console.Write("Tac Gia: ");
            HS.Tuoi = Nhap.SoNguyen(false);
            Console.Write("Nam xuat ban: ");
            HS.DiemTB = Nhap.SoThuc();

            DSHocSinh.Add(HS);
            Console.WriteLine($"Da them {HS.HoTen} vao danh sach!");
        }

        internal void InToanBoHS(List<HocSinh> DSHocSinh)
        {
            foreach (var hs in DSHocSinh)
            {
                Console.WriteLine("\nTat ca hoc sinh co trong danh sach:");
                Console.WriteLine(hs.HoTen + "\n");
            }
        }

        private void TimKiemHS(List<HocSinh> DSHocSinh)
        {
            Console.WriteLine("\nNhap ho ten cua hoc sinh can tim: ");
            string HoTen = Console.ReadLine();

            foreach (var hs in DSHocSinh)
            {
                if (hs.HoTen == HoTen)
                {
                    Console.WriteLine("Em " + hs.HoTen);
                    Console.WriteLine(hs.Tuoi + "tuoi");
                    Console.WriteLine("Diem trung binh: " + hs.DiemTB);
                }
            }
        }
    }
}
