// Bài 1.1. Tính tuổi 1 sinh viên
// Viết chương trình nhập thông tin sinh viên (họ tên, năm sinh). Tính và xuất tuổi sinh viên này.

using System;

namespace Baimotchammot
{
    public class SinhVien
    {
        // Field lưu họ tên
        private string hoTen;
        // Field lưu năm sinh
        private int namSinh;

        // Constructor mặc định
        public SinhVien()
        {
            hoTen = "";
            namSinh = 0;
        }

        // Constructor có tham số
        public SinhVien(string hoTen, int namSinh)
        {
            this.hoTen = hoTen;
            this.namSinh = namSinh;
        }

        // Property truy cập họ tên
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        // Property truy cập năm sinh
        public int NamSinh
        {
            get { return namSinh; }
            set { namSinh = value; }
        }

        // Nhập thông tin sinh viên từ bàn phím
        public void Input()
        {
            Console.Write("Nhập họ tên: ");
            hoTen = Console.ReadLine() ?? "";
            Console.Write("Nhập năm sinh: ");
            namSinh = int.Parse(Console.ReadLine() ?? "0");
        }

        // Xuất thông tin sinh viên
        public void Output()
        {
            Console.WriteLine($"Họ tên: {hoTen} - Năm sinh: {namSinh} - Tuổi: {TinhTuoi()}");
        }

        // Tính tuổi sinh viên dựa trên năm hiện tại của hệ thống
        public int TinhTuoi()
        {
            int namHienTai = DateTime.Now.Year;
            return namHienTai - namSinh;
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            SinhVien sv = new SinhVien();
            sv.Input();
            sv.Output();
        }
    }
}