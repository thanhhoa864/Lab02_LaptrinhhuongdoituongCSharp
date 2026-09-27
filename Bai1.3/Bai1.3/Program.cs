// Bài 1.3. Lớp Person
// Dữ liệu: id, name, yob (năm sinh), yod (năm mất)
// Default Constructor, Copy Constructor, Input, Output, IsLiving

using System;

namespace Baimotchamba
{
    public class Person
    {
        // Field lưu mã định danh
        private string id;
        // Field lưu họ tên
        private string name;
        // Field lưu năm sinh
        private int yob;
        // Field lưu năm mất (0 nghĩa là còn sống)
        private int yod;

        // Constructor mặc định
        public Person()
        {
            id = "";
            name = "";
            yob = 0;
            yod = 0;
        }

        // Copy constructor
        public Person(Person p)
        {
            id = p.id;
            name = p.name;
            yob = p.yob;
            yod = p.yod;
        }

        // Constructor đầy đủ
        public Person(string id, string name, int yob, int yod = 0)
        {
            this.id = id;
            this.name = name;
            this.yob = yob;
            this.yod = yod;
        }

        // Property truy cập id
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        // Property truy cập họ tên
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Property truy cập năm sinh
        public int Yob
        {
            get { return yob; }
            set { yob = value; }
        }

        // Property truy cập năm mất
        public int Yod
        {
            get { return yod; }
            set { yod = value; }
        }

        // Nhập thông tin người
        public void Input()
        {
            Console.Write("Nhập ID: ");
            id = Console.ReadLine() ?? "";
            Console.Write("Nhập họ tên: ");
            name = Console.ReadLine() ?? "";
            Console.Write("Nhập năm sinh: ");
            yob = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhập năm mất (0 nếu còn sống): ");
            yod = int.Parse(Console.ReadLine() ?? "0");
        }

        // Xuất thông tin người
        public void Output()
        {
            string trangThai = (yod == 0) ? "Còn sống" : yod.ToString();
            Console.WriteLine($"ID: {id} | Họ tên: {name} | Năm sinh: {yob} | Năm mất: {trangThai}");
        }

        // Kiểm tra người còn sống hay không
        public bool IsLiving()
        {
            return yod == 0;
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Input();
            p.Output();
            Console.WriteLine($"Còn sống: {p.IsLiving()}");
        }
    }
}