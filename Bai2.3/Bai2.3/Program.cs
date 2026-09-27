
/// Bài "Đa thức": Lớp đa thức P(x) = a0.x^0 + a1.x^1 + ... + an.x^n
/// gồm n+1 đơn thức
using System;

namespace BaiDaThuc
{
    // Lớp DonThuc (lấy lại từ Bài 1.5) để DaThuc có thể sử dụng
    public class DonThuc
    {
        private double heSo;
        private int soMu;

        public double HeSo { get => heSo; set => heSo = value; }
        public int SoMu { get => soMu; set => soMu = value; }

        public DonThuc() { heSo = 0; soMu = 0; }
        public DonThuc(double heSo, int soMu) { this.heSo = heSo; this.soMu = soMu; }

        public double TinhGiaTri(double x) => heSo * Math.Pow(x, soMu);
    }

    
    public class DaThuc
    {
        private DonThuc[] cacDonThuc; // mảng n+1 đơn thức
        private int n; // bậc cao nhất của đa thức

        // Constructor mặc định
        public DaThuc()
        {
            n = 0;
            cacDonThuc = new DonThuc[1] { new DonThuc(0, 0) };
        }

        // Constructor theo bậc n (đa thức có n+1 hệ số)
        public DaThuc(int n)
        {
            this.n = n;
            cacDonThuc = new DonThuc[n + 1];
            for (int i = 0; i <= n; i++)
                cacDonThuc[i] = new DonThuc(0, i);
        }

        // Indexer để truy cập đơn thức thứ i
        public DonThuc this[int i]
        {
            get { return cacDonThuc[i]; }
            set { cacDonThuc[i] = value; }
        }

        // Nhập hệ số cho đa thức
        public void Input()
        {
            Console.Write("Nhập bậc n của đa thức: ");
            n = int.Parse(Console.ReadLine() ?? "0");
            cacDonThuc = new DonThuc[n + 1];
            for (int i = 0; i <= n; i++)
            {
                Console.Write($"Nhập hệ số a{i} (ứng với x^{i}): ");
                double ai = double.Parse(Console.ReadLine() ?? "0");
                cacDonThuc[i] = new DonThuc(ai, i);
            }
        }

        // Xuất đa thức
        public void Output()
        {
            Console.Write("P(x) = ");
            for (int i = n; i >= 0; i--)
            {
                Console.Write($"{cacDonThuc[i].HeSo}x^{i}");
                if (i > 0) Console.Write(" + ");
            }
            Console.WriteLine();
        }

        // Tính giá trị của đa thức với giá trị x được nhập từ bàn phím (hoặc truyền vào)
        public double TinhGiaTri(double x)
        {
            double tong = 0;
            for (int i = 0; i <= n; i++)
                tong += cacDonThuc[i].TinhGiaTri(x);
            return tong;
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            // Nhập hệ số đa thức từ bàn phím (thay vì gán cứng dt[0], dt[1], dt[2]...)
            DaThuc dt = new DaThuc();
            dt.Input();
            dt.Output();

            // Nhập giá trị x từ bàn phím để tính giá trị đa thức, đúng yêu cầu đề bài
            Console.Write("Nhập giá trị x cần tính: ");
            double x = double.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine($"Giá trị P({x}) = {dt.TinhGiaTri(x)}");
        }
    }
}