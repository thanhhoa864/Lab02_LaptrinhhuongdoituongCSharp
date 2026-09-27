// Bài 2.5: Tính lương nhân viên
// Một phòng ban có n nhân viên (họ tên, mức lương, số ngày vắng)
// Mỗi ngày vắng trừ 100.000 VNĐ. Tính tổng lương phòng ban.

using System;
using System.Collections.Generic;

namespace BaiHaiChamNam
{
    public class NhanVienPhongBan
    {
        private string hoTen = "";
        private double mucLuong;
        private int soNgayVang;

        public string HoTen { get => hoTen; set => hoTen = value; }
        public double MucLuong { get => mucLuong; set => mucLuong = value; }
        public int SoNgayVang { get => soNgayVang; set => soNgayVang = value; }

        public NhanVienPhongBan() { }

        public NhanVienPhongBan(string hoTen, double mucLuong, int soNgayVang)
        {
            this.hoTen = hoTen;
            this.mucLuong = mucLuong;
            this.soNgayVang = soNgayVang;
        }

        // Nhập thông tin nhân viên từ bàn phím
        public void Input()
        {
            Console.Write("Nhập họ tên: ");
            hoTen = Console.ReadLine() ?? "";
            Console.Write("Nhập mức lương: ");
            mucLuong = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhập số ngày vắng: ");
            soNgayVang = int.Parse(Console.ReadLine() ?? "0");
        }

        // Tính lương thực nhận: mỗi ngày vắng trừ 100.000 VNĐ
        public double TinhLuong()
        {
            const double TIEN_TRU_MOI_NGAY = 100000;
            return mucLuong - soNgayVang * TIEN_TRU_MOI_NGAY;
        }

        public void Output()
        {
            Console.WriteLine($"{hoTen} - Lương thực nhận: {TinhLuong():N0} VNĐ");
        }
    }

    // Lớp PhongBan quản lý danh sách nhân viên và tính tổng lương của phòng ban

    public class PhongBan
    {
        private List<NhanVienPhongBan> danhSach = new();

        // Thêm nhân viên vào phòng ban
        public void Add(NhanVienPhongBan nv) => danhSach.Add(nv);

        // Nhập danh sách n nhân viên từ bàn phím
        public void Input()
        {
            Console.Write("Nhập số lượng nhân viên: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($" Nhập nhân viên thứ {i + 1}");
                NhanVienPhongBan nv = new NhanVienPhongBan();
                nv.Input();
                Add(nv);
            }
        }

        public void Output()
        {
            foreach (var nv in danhSach)
                nv.Output();
        }

        // Tổng lương của toàn phòng ban
        public double TongLuong()
        {
            double tong = 0;
            foreach (var nv in danhSach)
                tong += nv.TinhLuong();
            return tong;
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            PhongBan pb = new PhongBan();
            pb.Input();

            Console.WriteLine("\nBảng lương phòng ban:");
            pb.Output();
            Console.WriteLine($"Tổng lương phòng ban: {pb.TongLuong():N0} VNĐ");
        }
    }
}