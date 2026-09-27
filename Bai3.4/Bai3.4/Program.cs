// Bài 3.4*: Lớp ConsoleMenu tổng quát, áp dụng cho bài toán giải phương trình bậc 2
// Thư viện hỗ trợ mở rộng qua sự kiện, kế thừa

using System;

namespace BaiBaChamBon
{
    // Khai báo delegate cho sự kiện Choose: truyền số chức năng được chọn
    public delegate void ChonChucNangHandler(int chucNang);

    /// <summary>
    /// Lớp ConsoleMenu tổng quát - hiển thị menu, nhận lựa chọn
    /// và phát sự kiện Choose để lớp con (hoặc bên ngoài) xử lý.
    /// </summary>
    public class ConsoleMenu
    {
        // Danh sách tên các chức năng, có thể được lớp con truyền vào
        protected string[] tenChucNang;

        // Sự kiện được phát ra khi người dùng chọn 1 chức năng (mở rộng qua sự kiện)
        public event ChonChucNangHandler? Choose;

        public ConsoleMenu(string[] tenChucNang)
        {
            this.tenChucNang = tenChucNang;
        }

        // Hiển thị menu ra màn hình
        protected virtual void HienThiMenu()
        {
            Console.WriteLine("Menu");
            for (int i = 0; i < tenChucNang.Length; i++)
                Console.WriteLine($"{i + 1}. {tenChucNang[i]}");
            Console.WriteLine("0. Thoát chương trình");
        }

        // Chạy vòng lặp menu cho đến khi người dùng chọn thoát (0)
        public void Run()
        {
            int luaChon;
            do
            {
                HienThiMenu();
                Console.Write("Thực hiện: ");
                luaChon = int.Parse(Console.ReadLine() ?? "0");
                if (luaChon == 0)
                {
                    Console.WriteLine("Thoát chương trình.");
                }
                else
                {
                    // Phát sự kiện Choose để lớp kế thừa / người đăng ký xử lý
                    if (Choose != null)
                        Choose(luaChon);
                    else
                        Console.WriteLine($"Bạn thực hiện chức năng {luaChon}");
                }
            } while (luaChon != 0);
        }
    }
    // Áp dụng ConsoleMenu cho bài toán giải phương trình bậc 2: a.x^2 + b.x + c = 0
    public class PTBac2Console : ConsoleMenu
    {
        // Kế thừa ConsoleMenu, cung cấp sẵn tên các chức năng cụ thể
        public PTBac2Console() : base(new string[] { "Giải phương trình bậc 2", "Xem hướng dẫn" })
        {
            // Đăng ký xử lý sự kiện Choose ngay trong lớp con (thể hiện kế thừa + sự kiện)
            Choose += XuLyChon;
        }

        // Hàm xử lý khi người dùng chọn chức năng
        private void XuLyChon(int chucNang)
        {
            switch (chucNang)
            {
                case 1:
                    GiaiPhuongTrinhBac2();
                    break;
                case 2:
                    Console.WriteLine("Nhập 3 hệ số a, b, c của phương trình ax^2 + bx + c = 0");
                    break;
                default:
                    Console.WriteLine("Chức năng không hợp lệ!");
                    break;
            }
        }

        // Giải phương trình bậc 2: ax^2 + bx + c = 0, nhập a, b, c từ bàn phím
        private void GiaiPhuongTrinhBac2()
        {
            Console.Write("Nhập a: ");
            double a = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhập b: ");
            double b = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhập c: ");
            double c = double.Parse(Console.ReadLine() ?? "0");

            if (a == 0)
            {
                if (b == 0)
                    Console.WriteLine(c == 0 ? "Phương trình vô số nghiệm" : "Phương trình vô nghiệm");
                else
                    Console.WriteLine($"Phương trình có 1 nghiệm x = {-c / b}");
                return;
            }

            double delta = b * b - 4 * a * c; // Tính delta
            if (delta < 0)
            {
                Console.WriteLine("Phương trình vô nghiệm");
            }
            else if (delta == 0)
            {
                Console.WriteLine($"Phương trình có nghiệm kép x = {-b / (2 * a)}");
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine($"Phương trình có 2 nghiệm: x1 = {x1}, x2 = {x2}");
            }
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            PTBac2Console app = new PTBac2Console();
            app.Run(); // Menu tự chờ người dùng nhập lựa chọn và dữ liệu
        }
    }
}