using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCoBan.BTVN
{
    internal class Buoi3
    {
        internal void Main()
        {
            Console.WriteLine("Buoc 1: Nhap vao mang");
            var mang = Bai1();

            Console.Write($@"
                Chon bai:
                    2. In ra mang so le va mang so chan tu mang da nhap o buoc so 1
                    3. Sap xep day tang va giam dan tu mang da nhap o buoc so 1
                    4. Tinh tong cac so chan va tong cac so le tu mang da nhap o buoc so 1
                    5. In ra cac so la so Armstrong tu mang da nhap o buoc so 1.
                    6. Tinh tong cua tat ca cac so nguyen to tu mang da nhap o buoc so 1
                    0. Thoat                

                Lua chon: ");

            int luaChon = Input.Integer(false, 0, 6);

            switch (luaChon)
            {
                case 2:
                    Bai2(ref mang);
                    break;
                case 3:
                    Bai3(mang);
                    break;
                case 4:
                    Bai4(ref mang);
                    break;
                case 5:
                    Bai5(ref mang);
                    break;
                case 6:
                    Bai6(ref mang);
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }

        internal List<int> Bai1()
        {
            Console.Write("Nhap vao do rong cua mang: ");
            int n = Input.Integer();
            int[] mangSN = new int[n];

            Console.WriteLine("Nhap vao mang so nguyen");
            for (int i = 0; i < mangSN.Length; i++)
            {
                Console.Write("So thu " + (i+1) + " = ");
                mangSN[i] = Input.Integer();
            }

            return mangSN.ToList();
        }

        internal void Bai2(ref List<int> mangSN)
        {
            var soLe = new List<int>();
            var soChan = new List<int>();

            for (int i = 0;i < mangSN.Count;i++)
            {
                bool laSoChan = mangSN[i] % 2 == 0;
                if (laSoChan)
                {
                    soChan.Add(mangSN[i]);
                }
                else
                {
                    soLe.Add(mangSN[i]);
                }
            }

            Console.WriteLine("\nMang so le: ");
            for (int i = 0; i < soLe.Count;i++)
            {
                Console.Write($"{soLe[i]} ");
            }

            Console.WriteLine("\nMang so chan: ");
            for (int i = 0; i < soChan.Count; i++)
            {
                Console.Write($"{soChan[i]} ");
            }
        }

        internal void Bai3(List<int> mangSN)
        {
            for (int i = 0, tam; i < mangSN.Count - 1; i++)
            {
                for (int j = i + 1; j < mangSN.Count; j++)
                {
                    if (mangSN[i] < mangSN[j])
                    {
                        tam = mangSN[i];
                        mangSN[i] = mangSN[j];
                        mangSN[j] = tam;
                    }
                }
            }

            Console.WriteLine("\nSap xep tu lon den be:");
            for (int i = 0; i < mangSN.Count; i++)
            {
                Console.Write($"{mangSN[i]} ");
            }

            Console.WriteLine("\nSap xep tu be den lon:");
            for (int i = mangSN.Count - 1; i >= 0; i--)
            {
                Console.Write($"{mangSN[i]} ");
            }
        }

        internal void Bai4(ref List<int> mangSN)
        {
            int tongSoLe = 0, tongSoChan = 0;

            for (int i = 0; i < mangSN.Count; i++)
            {
                bool laSoChan = mangSN[i] % 2 == 0;
                if (laSoChan)
                {
                    tongSoChan+=mangSN[i];
                }
                else
                {
                    tongSoLe+=mangSN[i];
                }
            }

            Console.WriteLine($"Tong so chan: {tongSoChan}\nTong so le: {tongSoLe}");
        }

        internal void Bai5(ref List<int> mangSN)
        {
            Console.WriteLine("Cac so Armstrong co trong mang la:");
            for (int i = 0; i < mangSN.Count; i++)
            {
                if (LaSoArmstrong(mangSN[i]))
                {
                    Console.Write(mangSN[i] + " ");
                }
            }
        }

        internal bool LaSoArmstrong(int so)
        {
            int n = so.ToString().Length;
            int[] chuSo = new int[n];
            for (int i = 0, soTamThoi = so; i < n; i++)
            {
                chuSo[i] = soTamThoi % 10;
                soTamThoi /= 10;
            }

            double tong = 0;
            foreach (int i in chuSo)
            {
                tong += Math.Pow(i,n);
            }

            if (tong == so)
                return true;
            else 
                return false;
        }

        internal void Bai6(ref List<int> mangSN)
        {
            int tong = 0;
            for (int i = 0; i < mangSN.Count;i++)
            {
                if (LaSoNguyenTo(mangSN[i]))
                    tong += mangSN[i];
            }

            Console.WriteLine("Tong tat ca so nguyen to la " + tong);
        }

        internal bool LaSoNguyenTo(int so)
        {
            for (int i = 2; i < so/2; i++)
            {
                if (so % i == 0)
                    return false;
            }

            return true;
        }
    }
}
