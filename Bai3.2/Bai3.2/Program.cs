// Bài 3.2: Viết phương thức sắp xếp một mảng tổng quát bằng interface
// (mô phỏng phương thức Array.Sort(...))
// Mô phỏng Array.Sort(...) bằng interface IComparable
// Sắp xếp mảng tổng quát cho mọi lớp implement IComparable

using System;

namespace BaiBaChamHai
{
   
    public static class SapXepTongQuat
    {
        // Sắp xếp mảng tổng quát bằng thuật toán chọn (selection sort), dựa vào IComparable
        public static void SapXep<T>(T[] mang) where T : IComparable<T>
        {
            int n = mang.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int viTriNhoNhat = i;
                for (int j = i + 1; j < n; j++)
                {
                    // Gọi CompareTo do lớp T tự định nghĩa để so sánh
                    if (mang[j].CompareTo(mang[viTriNhoNhat]) < 0)
                        viTriNhoNhat = j;
                }
                // Hoán vị phần tử nhỏ nhất về đúng vị trí
                (mang[i], mang[viTriNhoNhat]) = (mang[viTriNhoNhat], mang[i]);
            }
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            // Nhập mảng số nguyên thật từ bàn phím
            Console.Write("Nhập số lượng phần tử: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            int[] mang = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập phần tử thứ {i + 1}: ");
                mang[i] = int.Parse(Console.ReadLine() ?? "0");
            }

            SapXepTongQuat.SapXep(mang); // int đã cài sẵn IComparable<int>

            Console.WriteLine("Mảng sau khi sắp xếp: " + string.Join(" ", mang));
        }
    }
}