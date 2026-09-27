// Bài 2.2: Lớp PersonList quản lý danh sách nhiều Person (quản lý nhân khẩu)
// Có chứa sẵn lớp Person (copy từ Bài 1.3)

using System;
using System.Collections.Generic;

namespace BaiHaiChamHai
{
    //LỚP PERSON (copy từ Bài 1.3)
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

    //LỚP PERSONLIST (Bài 2.2)
    public class PersonList
    {
        // Field: danh sách các Person
        private List<Person> ds;

        // Default constructor
        public PersonList()
        {
            ds = new List<Person>();
        }

        // Copy constructor
        public PersonList(PersonList other)
        {
            ds = new List<Person>();
            foreach (var p in other.ds)
                ds.Add(new Person(p)); // dùng copy constructor của Person
        }

        // Nhập danh sách Person
        public void Input()
        {
            Console.Write("Nhập số lượng người: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"--- Nhập người thứ {i + 1} ---");
                Person p = new Person();
                p.Input();
                Add(p);
            }
        }

        // Xuất danh sách Person
        public void Output()
        {
            foreach (var p in ds)
                p.Output();
        }

        // Thêm một Person vào danh sách
        public void Add(Person x)
        {
            ds.Add(x);
        }

        // Trả về một PersonList chỉ chứa những người còn sống
        public PersonList LivingPeople()
        {
            PersonList ketQua = new PersonList();
            foreach (var p in ds)
            {
                if (p.IsLiving())
                    ketQua.Add(p);
            }
            return ketQua;
        }
    }

    // CHƯƠNG TRÌNH CHÍNH 

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            // Nhập dữ liệu thật từ bàn phím, đúng chức năng Input() của PersonList
            PersonList dsNguoi = new PersonList();
            dsNguoi.Input();

            Console.WriteLine("\nDanh sách vừa nhập:");
            dsNguoi.Output();

            Console.WriteLine("\nNhững người còn sống:");
            dsNguoi.LivingPeople().Output();
        }
    }
}