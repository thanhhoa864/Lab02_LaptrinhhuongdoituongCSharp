// Bài 2.4: Lớp mảng 2 chiều kích thước n x m
// Xây dựng lớp mảng 2 chiều. Constructor, Indexer, Nhập/Xuất, Tìm số nguyên tố

using System;

namespace BaiHaiChamBon
{
    public class Mang2Chieu
    {
        private int[,] a;
        private int n, m; // n dòng, m cột

        // Constructor mặc định
        public Mang2Chieu()
        {
            n = m = 0;
            a = new int[0, 0];
        }

        // Constructor với kích thước n x m
        public Mang2Chieu(int n, int m)
        {
            this.n = n;
            this.m = m;
            a = new int[n, m];
        }

        // Constructor sao chép
        public Mang2Chieu(Mang2Chieu other)
        {
            n = other.n;
            m = other.m;
            a = new int[n, m];
            Array.Copy(other.a, a, n * m);
        }

        // Indexer để truy cập phần tử tại (i, j)
        public int this[int i, int j]
        {
            get { return a[i, j]; }
            set { a[i, j] = value; }
        }

        // Nhập mảng 2 chiều từ bàn phím
        public void Input()
        {
            Console.Write("Nhập số dòng n: ");
            n = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhập số cột m: ");
            m = int.Parse(Console.ReadLine() ?? "0");
            a = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    a[i, j] = int.Parse(Console.ReadLine() ?? "0");
                }
        }

        // Xuất mảng 2 chiều
        public void Output()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(a[i, j] + "\t");
                Console.WriteLine();
            }
        }

        // Hàm phụ trợ kiểm tra một số có phải số nguyên tố hay không
        private static bool LaSoNguyenTo(int x)
        {
            if (x < 2) return false;
            for (int i = 2; i * i <= x; i++)
                if (x % i == 0) return false;
            return true;
        }

        // Tìm các số nguyên tố có trong mảng
        public void TimSoNguyenTo()
        {
            Console.WriteLine("Các số nguyên tố trong mảng:");
            bool coSoNguyenTo = false;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (LaSoNguyenTo(a[i, j]))
                    {
                        Console.WriteLine($"a[{i},{j}] = {a[i, j]}");
                        coSoNguyenTo = true;
                    }

            if (!coSoNguyenTo)
                Console.WriteLine("(Không có số nguyên tố nào trong mảng)");
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {

            Mang2Chieu m = new Mang2Chieu();
            m.Input();
            m.Output();
            m.TimSoNguyenTo();
        }
    }
}