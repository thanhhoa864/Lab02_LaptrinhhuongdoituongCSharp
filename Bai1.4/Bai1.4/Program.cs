// Lớp phân số 
using System;

namespace Baimotchambon
{
    public class PhanSo
    {
        private int tuSo;
        private int mauSo;

        public int TuSo { get => tuSo; set => tuSo = value; }
        public int MauSo
        {
            get => mauSo;
            set
            {
                if (value == 0)
                    throw new ArgumentException("Mẫu số không được bằng 0");
                mauSo = value;
            }
        }

        // Constructor mặc nhiên: phân số 0/1
        public PhanSo()
        {
            tuSo = 0;
            mauSo = 1;
        }

        // Constructor sao chép
        public PhanSo(PhanSo p)
        {
            tuSo = p.tuSo;
            mauSo = p.mauSo;
        }

        // Constructor với tử số và mẫu số
        public PhanSo(int tuSo, int mauSo)
        {
            if (mauSo == 0) throw new ArgumentException("Mẫu số không được bằng 0");
            this.tuSo = tuSo;
            this.mauSo = mauSo;
        }

        // Constructor với số nguyên (mẫu số mặc định = 1)
        public PhanSo(int tuSo)
        {
            this.tuSo = tuSo;
            this.mauSo = 1;
        }

        // Hàm phụ trợ tìm ước chung lớn nhất để rút gọn phân số
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

        // Toán tử một ngôi + (giữ nguyên dấu)
        public static PhanSo operator +(PhanSo p)
        {
            return new PhanSo(p.tuSo, p.mauSo);
        }

        // Toán tử một ngôi - (lấy đối)
        public static PhanSo operator -(PhanSo p)
        {
            return new PhanSo(-p.tuSo, p.mauSo);
        }

        // Toán tử hai ngôi + : quy đồng mẫu số rồi cộng tử số
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tuSo * b.mauSo + b.tuSo * a.mauSo, a.mauSo * b.mauSo).RutGon();
        }

        // Toán tử hai ngôi -
        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tuSo * b.mauSo - b.tuSo * a.mauSo, a.mauSo * b.mauSo).RutGon();
        }

        // Toán tử hai ngôi *
        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tuSo * b.tuSo, a.mauSo * b.mauSo).RutGon();
        }

        // Toán tử hai ngôi /
        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            if (b.tuSo == 0) throw new DivideByZeroException("Không thể chia cho phân số 0");
            return new PhanSo(a.tuSo * b.mauSo, a.mauSo * b.tuSo).RutGon();
        }

        // Quy đổi ra giá trị double để so sánh
        private static double GiaTri(PhanSo p) => (double)p.tuSo / p.mauSo;

        // Overload các toán tử so sánh
        public static bool operator >(PhanSo a, PhanSo b) => GiaTri(a) > GiaTri(b);
        public static bool operator <(PhanSo a, PhanSo b) => GiaTri(a) < GiaTri(b);
        public static bool operator >=(PhanSo a, PhanSo b) => GiaTri(a) >= GiaTri(b);
        public static bool operator <=(PhanSo a, PhanSo b) => GiaTri(a) <= GiaTri(b);
        public static bool operator ==(PhanSo a, PhanSo b) => GiaTri(a) == GiaTri(b);
        public static bool operator !=(PhanSo a, PhanSo b) => GiaTri(a) != GiaTri(b);

        // Bắt buộc override Equals/GetHashCode khi đã overload == và !=
        public override bool Equals(object? obj)
        {
            if (obj is not PhanSo p) return false;
            return GiaTri(this) == GiaTri(p);
        }

        public override int GetHashCode()
        {
            return GiaTri(this).GetHashCode();
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            PhanSo p1 = new PhanSo(1, 2);
            PhanSo p2 = new PhanSo(1, 3);
            Console.WriteLine($"p1 = {p1}, p2 = {p2}");
            Console.WriteLine($"p1 + p2 = {p1 + p2}");
            Console.WriteLine($"p1 - p2 = {p1 - p2}");
            Console.WriteLine($"p1 * p2 = {p1 * p2}");
            Console.WriteLine($"p1 / p2 = {p1 / p2}");
            Console.WriteLine($"-p1 = {-p1}");
            Console.WriteLine($"p1 > p2: {p1 > p2}");
            Console.WriteLine($"p1 == p2: {p1 == p2}");
        }
    }
}