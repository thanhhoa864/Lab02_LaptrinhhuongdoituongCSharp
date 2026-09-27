// Bài 1.2. Thiết kế lớp Point
// Field: x, y | Property: X, Y | Constructor mặc định | Method Input, Output
// Override ToString | Toán tử +, -, lấy âm | Khoảng cách & Trung điểm (thành viên + tĩnh)

using System;

namespace Baimotchamhai
{
    public class Point
    {
        // Field lưu hoành độ
        private double x;
        // Field lưu tung độ
        private double y;

        // Constructor mặc định
        public Point()
        {
            x = 0;
            y = 0;
        }

        // Constructor có tham số
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Copy constructor
        public Point(Point p)
        {
            this.x = p.x;
            this.y = p.y;
        }

        // Property truy cập hoành độ
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        // Property truy cập tung độ
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        // Nhập tọa độ điểm
        public void Input()
        {
            Console.Write("Nhập x: ");
            x = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhập y: ");
            y = double.Parse(Console.ReadLine() ?? "0");
        }

        // Xuất tọa độ điểm
        public void Output()
        {
            Console.WriteLine($"({x}, {y})");
        }

        // Override hàm ToString để xuất điểm
        public override string ToString()
        {
            return $"({x}, {y})";
        }

        // Toán tử cộng hai điểm
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }

        // Toán tử trừ hai điểm
        public static Point operator -(Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y);
        }

        // Toán tử lấy âm (một ngôi)
        public static Point operator -(Point a)
        {
            return new Point(-a.x, -a.y);
        }

        // Phương thức thành viên tính khoảng cách đến điểm khác
        public double KhoangCach(Point other)
        {
            return Math.Sqrt(Math.Pow(x - other.x, 2) + Math.Pow(y - other.y, 2));
        }

        // Phương thức tĩnh tính khoảng cách giữa hai điểm
        public static double KhoangCach(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
        }

        // Phương thức thành viên tìm trung điểm với điểm khác
        public Point TrungDiem(Point other)
        {
            return new Point((x + other.x) / 2, (y + other.y) / 2);
        }

        // Phương thức tĩnh tìm trung điểm của hai điểm
        public static Point TrungDiem(Point a, Point b)
        {
            return new Point((a.x + b.x) / 2, (a.y + b.y) / 2);
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            Point A = new Point();
            Point B = new Point();

            Console.WriteLine("Nhập điểm A:");
            A.Input();
            Console.WriteLine("Nhập điểm B:");
            B.Input();

            Console.WriteLine($"Khoảng cách (thành viên): {A.KhoangCach(B)}");
            Console.WriteLine($"Khoảng cách (tĩnh): {Point.KhoangCach(A, B)}");

            Point I1 = A.TrungDiem(B);
            Point I2 = Point.TrungDiem(A, B);

            Console.WriteLine($"Trung điểm (thành viên): {I1}");
            Console.WriteLine($"Trung điểm (tĩnh): {I2}");
        }
    }
}