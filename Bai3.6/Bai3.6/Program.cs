// Bài 3.6: Tính điểm thí sinh
// Thí sinh Chuyên và Siêu cúp - kế thừa và đa hình

using System;
using System.Collections.Generic;

namespace BaiBaChamSau
{
    /// <summary>
    /// Lớp cơ sở ThiSinh - minh hoạ kế thừa và đa hình
    /// </summary>
    public abstract class ThiSinh
    {
        protected string sbd = "";         // số báo danh
        protected string hoTen = "";
        protected double bai1, bai2, bai3; // điểm 3 bài thi lập trình
        protected double tongDiem;         // tổng điểm cuối cùng

        public string Sbd { get => sbd; set => sbd = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public double Bai1 { get => bai1; set => bai1 = value; }
        public double Bai2 { get => bai2; set => bai2 = value; }
        public double Bai3 { get => bai3; set => bai3 = value; }
        public double TongDiem => tongDiem;

        // Nhập thông tin chung: sbd, họ tên, điểm 3 bài thi lập trình
        public virtual void Input()
        {
            Console.Write("Nhập số báo danh: ");
            sbd = Console.ReadLine() ?? "";
            Console.Write("Nhập họ tên: ");
            hoTen = Console.ReadLine() ?? "";
            Console.Write("Nhập điểm bài 1: ");
            bai1 = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhập điểm bài 2: ");
            bai2 = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhập điểm bài 3: ");
            bai3 = double.Parse(Console.ReadLine() ?? "0");
        }

        // Tổng điểm 3 bài thi lập trình (dùng chung cho các lớp con)
        protected double TongBaiLapTrinh() => bai1 + bai2 + bai3;

        // Phương thức trừu tượng: mỗi đối tượng thí sinh tính tổng điểm khác nhau (đa hình)
        public abstract double TinhTongDiem();

        public virtual void Output()
        {
            tongDiem = TinhTongDiem();
            Console.WriteLine($"SBD: {sbd} - {hoTen} - Tổng điểm: {tongDiem}");
        }
    }

    // Thí sinh Chuyên: có thêm điểm tiếng Anh để cộng điểm thưởng
    public class ThiSinhChuyen : ThiSinh
    {
        private double tiengAnh;

        public double TiengAnh { get => tiengAnh; set => tiengAnh = value; }

        // Override để nhập thêm điểm tiếng Anh, gọi lại Input() gốc trước
        public override void Input()
        {
            base.Input();
            Console.Write("Nhập điểm tiếng Anh: ");
            tiengAnh = double.Parse(Console.ReadLine() ?? "0");
        }

        // Override: tổng 3 bài lập trình + điểm thưởng theo mức điểm tiếng Anh
        public override double TinhTongDiem()
        {
            double diemThuong = 0;
            if (tiengAnh >= 7 && tiengAnh <= 8)
                diemThuong = 1;
            else if (tiengAnh >= 9 && tiengAnh <= 10)
                diemThuong = 2;

            tongDiem = TongBaiLapTrinh() + diemThuong;
            return tongDiem;
        }
    }


    // Thí sinh Siêu cúp: có thêm điểm CSDL, tổng điểm là tổng của 4 bài thi

    public class ThiSinhSieuCup : ThiSinh
    {
        private double csdl;

        public double Csdl { get => csdl; set => csdl = value; }

        // Override để nhập thêm điểm CSDL
        public override void Input()
        {
            base.Input();
            Console.Write("Nhập điểm CSDL: ");
            csdl = double.Parse(Console.ReadLine() ?? "0");
        }

        // Override: tổng điểm của 4 bài thi (3 bài lập trình + CSDL)
        public override double TinhTongDiem()
        {
            tongDiem = TongBaiLapTrinh() + csdl;
            return tongDiem;
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            // Nhập thông tin cuộc thi thật từ bàn phím, mỗi thí sinh tự chọn đối tượng
            Console.Write("Nhập số lượng thí sinh: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            List<ThiSinh> danhSach = new List<ThiSinh>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhập thí sinh thứ {i + 1} ---");
                Console.WriteLine("Chọn đối tượng: 1. Chuyên   2. Siêu cúp");
                Console.Write("Lựa chọn: ");
                int loai = int.Parse(Console.ReadLine() ?? "1");

                // Tạo đúng lớp con dựa theo lựa chọn, gán vào biến kiểu lớp cha (đa hình)
                ThiSinh ts = (loai == 1) ? new ThiSinhChuyen() : new ThiSinhSieuCup();
                ts.Input();
                danhSach.Add(ts);
            }

            Console.WriteLine("\nKết quả thi:");
            foreach (var ts in danhSach)
                ts.Output(); // đa hình: gọi đúng TinhTongDiem() theo từng đối tượng thí sinh
        }
    }
}