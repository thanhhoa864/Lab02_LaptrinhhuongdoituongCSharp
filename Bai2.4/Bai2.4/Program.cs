
// Bài "Dãy phân số": Lớp chứa n phân số và tính tổng của n phân số đó

using System;

namespace BaiDayPhanSo
{
    // Lớp PhanSo (lấy lại từ Bài 1.4) để DayPhanSo có thể sử dụng
    public class PhanSo
    {
        private int tuSo;
        private int mauSo;

        public int TuSo { get => tuSo; set => tuSo = value; }
        public int MauSo { get => mauSo; set => mauSo = value; }

        // Constructor mặc nhiên: phân số 0/1
        public PhanSo() { tuSo = 0; mauSo = 1; }

        // Constructor với tử số và mẫu số
        public PhanSo(int tuSo, int mauSo)
        {
            this.tuSo = tuSo;
            this.mauSo = mauSo;
        }

        // Hàm phụ dùng để tìm ước chung lớn nhất để rút gọn phân số
        private static int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0) { int t = b; b = a % b; a = t; }
            return a == 0 ? 1 : a;
        }

        // Rút gọn phân số
        public PhanSo RutGon()
        {
            int uc = UCLN(tuSo, mauSo);
            return new PhanSo(tuSo / uc, mauSo / uc);
        }

        // Override ToString() để xuất phân số
        public override string ToString()
        {
            return $"{tuSo}/{mauSo}";
        }

        // Overload toán tử + : quy đồng mẫu số rồi cộng tử số
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tuSo * b.mauSo + b.tuSo * a.mauSo, a.mauSo * b.mauSo).RutGon();
        }
    }

    public class DayPhanSo
    {
        private PhanSo[] ds;
        private int n;

        public DayPhanSo(int n)
        {
            this.n = n;
            ds = new PhanSo[n];
            for (int i = 0; i < n; i++)
                ds[i] = new PhanSo();
        }

        // Indexer
        public PhanSo this[int i]
        {
            get { return ds[i]; }
            set { ds[i] = value; }
        }

        // Nhập n phân số
        public void Input()
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"--- Nhập phân số thứ {i + 1} ---");
                Console.Write("Tử số: ");
                int tu = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Mẫu số: ");
                int mau = int.Parse(Console.ReadLine() ?? "1");
                ds[i] = new PhanSo(tu, mau);
            }
        }

        // Xuất danh sách phân số
        public void Output()
        {
            for (int i = 0; i < n; i++)
                Console.WriteLine($"Phân số {i + 1}: {ds[i]}");
        }

        // Tính tổng của n phân số nhờ overload toán tử + của lớp PhanSo
        public PhanSo Tong()
        {
            PhanSo tong = new PhanSo(0, 1);
            for (int i = 0; i < n; i++)
                tong = tong + ds[i];
            return tong;
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            // Nhập dữ liệu thật từ bàn phím
            Console.Write("Nhập số lượng phân số: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            DayPhanSo dps = new DayPhanSo(n);
            dps.Input();
            dps.Output();
            Console.WriteLine($"Tổng = {dps.Tong()}");
        }
    }
}