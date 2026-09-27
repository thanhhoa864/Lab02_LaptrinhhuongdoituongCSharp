// Bài 2.1: Lớp ArrayPoint lưu trữ danh sách các Point bằng ArrayList

using System;
using System.Collections;

namespace BaiHaiChamMot
{
    public class Point
    {
        private double x, y;
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public Point() { x = 0; y = 0; }
        public Point(double x, double y) { this.x = x; this.y = y; }

        public override string ToString() => $"({x}, {y})";
    }

    
    public class ArrayPoint
    {
        // Field: ArrayList chứa các Point
        private ArrayList danhSach;

        public ArrayPoint()
        {
            danhSach = new ArrayList();
        }

        // Thêm điểm vào danh sách
        public void Add(Point p)
        {
            danhSach.Add(p);
        }

        // Số lượng điểm hiện có
        public int Count => danhSach.Count;

        // Indexer cho phép truy cập Point thứ i của ArrayList
        public Point this[int i]
        {
            get { return (Point)danhSach[i]!; }
            set { danhSach[i] = value; }
        }

        // Xuất toàn bộ danh sách điểm
        public void Output()
        {
            for (int i = 0; i < danhSach.Count; i++)
                Console.WriteLine($"Điểm thứ {i}: {this[i]}");
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            ArrayPoint ap = new ArrayPoint();
            ap.Add(new Point(1, 1));
            ap.Add(new Point(2, 2));
            ap.Output();
        }
    }
}