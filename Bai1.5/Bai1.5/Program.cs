using System;

namespace Baimotchamnam
{
    public class DonThuc
    {
        private double heSo; // hệ số a
        private int soMu;    // số mũ n (nguyên không âm)

        public double HeSo { get => heSo; set => heSo = value; }
        public int SoMu
        {
            get => soMu;
            set
            {
                if (value < 0) throw new ArgumentException("Số mũ phải không âm");
                soMu = value;
            }
        }

        public DonThuc() { heSo = 0; soMu = 0; }

        public DonThuc(double heSo, int soMu)
        {
            if (soMu < 0) throw new ArgumentException("Số mũ phải không âm");
            this.heSo = heSo;
            this.soMu = soMu;
        }

        public override string ToString()
        {
            return $"{heSo}x^{soMu}";
        }

        // (a) Tính giá trị đơn thức tại x cho trước
        public double TinhGiaTri(double x)
        {
            return heSo * Math.Pow(x, soMu);
        }

        // (b) Đạo hàm đơn thức: Q(x) = a.n.x^(n-1)
        public DonThuc DaoHam()
        {
            if (soMu == 0)
                return new DonThuc(0, 0); // đạo hàm của hằng số bằng 0
            return new DonThuc(heSo * soMu, soMu - 1);
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            DonThuc dt = new DonThuc(2, 3); // P(x) = 2x^3
            Console.WriteLine($"P(x) = {dt}");
            Console.WriteLine($"P(2) = {dt.TinhGiaTri(2)}");
            Console.WriteLine($"Đạo hàm Q(x) = {dt.DaoHam()}");
        }
    }
}