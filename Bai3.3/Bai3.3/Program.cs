// Bài 3.3: Viết phương thức sắp xếp một mảng tổng quát bằng delegate

using System;

namespace BaiBaChamBa
{
   
    public static class SapXepBangDelegate
    {
        // Khai báo delegate so sánh 2 phần tử, trả về số âm/0/dương giống IComparer
        public delegate int SoSanh<T>(T a, T b);

        // Sắp xếp mảng tổng quát dùng delegate do người dùng truyền vào,
        // không cần lớp T phải cài đặt sẵn IComparable
        public static void SapXep<T>(T[] mang, SoSanh<T> soSanh)
        {
            int n = mang.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int viTriNhoNhat = i;
                for (int j = i + 1; j < n; j++)
                {
                    // Gọi delegate do người dùng cung cấp để so sánh
                    if (soSanh(mang[j], mang[viTriNhoNhat]) < 0)
                        viTriNhoNhat = j;
                }
                (mang[i], mang[viTriNhoNhat]) = (mang[viTriNhoNhat], mang[i]);
            }
        }
    }

    class ChuongTrinh
    {
        static void Main(string[] args)
        {
            // Nhập mảng chuỗi thật từ bàn phím
            Console.Write("Nhập số lượng phần tử: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            string[] ten = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập tên thứ {i + 1}: ");
                ten[i] = Console.ReadLine() ?? "";
            }

            // Truyền delegate so sánh chuỗi theo thứ tự alphabet
            SapXepBangDelegate.SapXep(ten, (a, b) => string.Compare(a, b));

            Console.WriteLine("Mảng sau khi sắp xếp: " + string.Join(" ", ten));
        }
    }
}