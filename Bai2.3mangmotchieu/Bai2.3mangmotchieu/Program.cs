// Bài 2.3: Lớp dãy số chứa n số nguyên (mảng 1 chiều)

using System;

namespace BaiHaiChamBa
{
    public class DaySo
    {
        private int[] a;
        private int n;

        public int N => n;

        // Constructor mặc định
        public DaySo()
        {
            n = 0;
            a = Array.Empty<int>();
        }

        // Constructor với số lượng phần tử n
        public DaySo(int n)
        {
            this.n = n;
            a = new int[n];
        }

        // Constructor sao chép
        public DaySo(DaySo other)
        {
            n = other.n;
            a = new int[n];
            Array.Copy(other.a, a, n);
        }

        // Indexer để truy cập phần tử thứ i trong dãy
        public int this[int i]
        {
            get { return a[i]; }
            set { a[i] = value; }
        }

        // Nhập dãy số từ bàn phím
        public void Input()
        {
            Console.Write("Nhập số phần tử n: ");
            n = int.Parse(Console.ReadLine() ?? "0");
            a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập a[{i}] = ");
                a[i] = int.Parse(Console.ReadLine() ?? "0");
            }
        }

        // Xuất dãy số
        public void Output()
        {
            Console.Write("Dãy số: ");
            foreach (int x in a)
                Console.Write(x + " ");
            Console.WriteLine();
        }

        // Tìm các số chẵn trong dãy, trả về mảng mới chứa các số chẵn
        public int[] TimSoChan()
        {
            int demSoChan = 0;
            foreach (int x in a)
                if (x % 2 == 0) demSoChan++;

            int[] ketQua = new int[demSoChan];
            int viTri = 0;
            foreach (int x in a)
            {
                if (x % 2 == 0)
                    ketQua[viTri++] = x;
            }
            return ketQua;
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            DaySo d = new DaySo();
            d.Input();
            d.Output();
            Console.WriteLine("Các số chẵn: " + string.Join(" ", d.TimSoChan()));
        }
    }
}