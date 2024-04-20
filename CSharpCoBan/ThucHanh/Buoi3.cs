using System;

namespace CSharpCoBan
{
    internal class Buoi3
    {
        public void SapXep(ref int[] daySo)
        {
            int tam;

            Console.Write("Day so ban dau: ");
            for (int i = 0; i < daySo.Length; i++)
            {
                Console.Write(daySo[i] + " ");
            }

            for (int i = 0; i < daySo.Length - 1; i++)
                for (int j = i+1;  j < daySo.Length; j++)
                    if (daySo[i] > daySo[j])
                    {
                        tam = daySo[i];
                        daySo[i] = daySo[j];
                        daySo[j] = tam;
                    }

            Console.Write("\nDay so da sap xep: ");
            for (int i = 0; i < daySo.Length; i++)
            {
                Console.Write(daySo[i] + " ");
            }
        }
    }
}
