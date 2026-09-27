// Bài 3.5: Tính lương nhân viên
// Nhân viên kinh doanh và nhân viên sản xuất - kế thừa và đa hình

using System;
using System.Collections.Generic;

namespace BaiBaChamNam
{
    // Lớp cơ sở NhanVien - minh hoạ kế thừa và đa hình
    public abstract class NhanVien
    {
        protected string maNV = "";
        protected string hoTen = "";

        public string MaNV { get => maNV; set => maNV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }

        // Nhập thông tin chung: mã nhân viên, họ tên
        public virtual void Input()
        {
            Console.Write("Nhập mã nhân viên: ");
            maNV = Console.ReadLine() ?? "";
            Console.Write("Nhập họ tên: ");
            hoTen = Console.ReadLine() ?? "";
        }

        // Phương thức trừu tượng: mỗi loại nhân viên tính lương khác nhau (thể hiện đa hình)
        public abstract double TinhLuong();

        public virtual void Output()
        {
            // Khi gọi TinhLuong() ở đây, C# sẽ tự gọi đúng phiên bản override của lớp con
            Console.WriteLine($"{maNV} - {hoTen} - Lương: {TinhLuong():N0} VNĐ");
        }
    }

    // Nhân viên kinh doanh: lương cơ bản + 500.000đ cho mỗi hợp đồng ký được

    public class NhanVienKinhDoanh : NhanVien
    {
        private double luongCoBan;
        private int soHopDong;

        public double LuongCoBan { get => luongCoBan; set => luongCoBan = value; }
        public int SoHopDong { get => soHopDong; set => soHopDong = value; }

        // Override để nhập thêm dữ liệu riêng, gọi lại Input() gốc để nhập mã NV, họ tên trước
        public override void Input()
        {
            base.Input();
            Console.Write("Nhập lương cơ bản: ");
            luongCoBan = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhập số hợp đồng đã ký: ");
            soHopDong = int.Parse(Console.ReadLine() ?? "0");
        }

        // Override tính lương riêng cho nhân viên kinh doanh
        public override double TinhLuong()
        {
            const double THUONG_MOI_HOP_DONG = 500000;
            return luongCoBan + soHopDong * THUONG_MOI_HOP_DONG;
        }
    }

    // Nhân viên sản xuất: lương = số lượng sản phẩm x 1000, thưởng thêm 5% nếu làm trên 3000 sản phẩm
    public class NhanVienSanXuat : NhanVien
    {
        private int soLuongSanPham;

        public int SoLuongSanPham { get => soLuongSanPham; set => soLuongSanPham = value; }

        // Override để nhập thêm dữ liệu riêng
        public override void Input()
        {
            base.Input();
            Console.Write("Nhập số lượng sản phẩm: ");
            soLuongSanPham = int.Parse(Console.ReadLine() ?? "0");
        }

        // Override tính lương riêng cho nhân viên sản xuất
        public override double TinhLuong()
        {
            const double DON_GIA = 1000;
            double luong = soLuongSanPham * DON_GIA;
            if (soLuongSanPham > 3000)
                luong += luong * 0.05; // thưởng thêm 5% khi vượt 3000 sản phẩm
            return luong;
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            // Nhập danh sách nhân viên thật từ bàn phím, mỗi người tự chọn loại
            Console.Write("Nhập số lượng nhân viên: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            List<NhanVien> danhSach = new List<NhanVien>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhập nhân viên thứ {i + 1}");
                Console.WriteLine("Chọn loại nhân viên: 1. Kinh doanh   2. Sản xuất");
                Console.Write("Lựa chọn: ");
                int loai = int.Parse(Console.ReadLine() ?? "1");

                // Tạo đúng lớp con dựa theo lựa chọn, gán vào biến kiểu lớp cha (đa hình)
                NhanVien nv = (loai == 1) ? new NhanVienKinhDoanh() : new NhanVienSanXuat();
                nv.Input();
                danhSach.Add(nv);
            }

            Console.WriteLine("\nBảng lương nhân viên:");
            foreach (var nv in danhSach)
                nv.Output(); // đa hình: gọi đúng TinhLuong() theo từng loại nhân viên
        }
    }
}