// Bài 3.1: Dùng phương thức tĩnh Array.Sort(...) để sắp xếp các đối tượng của một lớp
// Lớp SinhVienSapXep cài đặt IComparable để dùng được với Array.Sort()

using System;

namespace BaiBaChamMot
{
    public class SinhVienSapXep : IComparable<SinhVienSapXep>
    {
        private string hoTen = "";
        private double diemTrungBinh;

        public string HoTen { get => hoTen; set => hoTen = value; }
        public double DiemTrungBinh { get => diemTrungBinh; set => diemTrungBinh = value; }

        public SinhVienSapXep() { }

        public SinhVienSapXep(string hoTen, double diemTrungBinh)
        {
            this.hoTen = hoTen;
            this.diemTrungBinh = diemTrungBinh;
        }

        // Nhập thông tin sinh viên từ bàn phím
        public void Input()
        {
            Console.Write("Nhập họ tên: ");
            hoTen = Console.ReadLine() ?? "";
            Console.Write("Nhập điểm trung bình: ");
            diemTrungBinh = double.Parse(Console.ReadLine() ?? "0");
        }

        // So sánh theo điểm trung bình để Array.Sort() sắp xếp tăng dần
        public int CompareTo(SinhVienSapXep? other)
        {
            if (other == null) return 1;
            return diemTrungBinh.CompareTo(other.diemTrungBinh);
        }

        public override string ToString()
        {
            return $"{hoTen} - {diemTrungBinh}";
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            // Nhập số lượng và thông tin từng sinh viên từ bàn phím
            Console.Write("Nhập số lượng sinh viên: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            SinhVienSapXep[] ds = new SinhVienSapXep[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"--- Nhập sinh viên thứ {i + 1} ---");
                ds[i] = new SinhVienSapXep();
                ds[i].Input();
            }

            Array.Sort(ds); // dùng IComparable đã cài đặt trong SinhVienSapXep

            Console.WriteLine("\nDanh sách sau khi sắp xếp theo điểm trung bình:");
            foreach (var sv in ds)
                Console.WriteLine(sv);
        }
    }
}