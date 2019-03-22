using System;
namespace GaussElimination {
    class Program {
        static void Main() {
            //(n)x(n+1)
            int n = BoyutAl();
            if (n == -1) Main();
            else
            {
                float[,] array = MatrisOlustur(n);
                MatrisYazdir(array);
                var result = GaussElimination(array);
                foreach (var item in result)
                    Console.WriteLine(item);
            }
        }
        private static float[] GaussElimination(float[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++) {
                float maxEl = Math.Abs(matrix[i, i]);
                int maxRow = i;
                for (int k = i + 1; k < n; k++) {
                    if (Math.Abs(matrix[k, i]) > maxEl) {
                        maxEl = Math.Abs(matrix[k, i]);
                        maxRow = k;
                    }
                }
                for (int k = i; k < n + 1; k++) {
                    float tmp = matrix[maxRow, k];
                    matrix[maxRow, k] = matrix[i, k];
                    matrix[i, k] = tmp;
                }
                for (int k = i + 1; k < n; k++) {
                    float c = -matrix[k, i] / matrix[i, i];
                    for (int j = i; j < n + 1; j++) {
                        if (i == j) matrix[k, j] = 0;
                        else matrix[k, j] += c * matrix[i, j];
                    }
                }
            }
            float[] x = new float[n];
            for (int i = n - 1; i >= 0; i--) {
                x[i] = matrix[i, n] / matrix[i, i];
                for (int k = i - 1; k >= 0; k--)
                    matrix[k, n] -= matrix[k, i] * x[i];
            }
            return x;
        }
        private static void MatrisYazdir(float[,] matris) {
            int r = matris.GetLength(0); //satır sayısı
            int c = matris.GetLength(1); //kolon sayısı
            for (int i = 0; i < r; i++)
            {
                Console.Write("[");
                for (int j = 0; j < c - 1; j++)
                    Console.Write("{0,4} ", matris[i, j]);
                Console.Write(" |{0,4} ", matris[i, c - 1]);
                Console.WriteLine("]");
            }
        }
        private static float[,] MatrisOlustur(int n)
        {
            float[,] matris = new float[n, n+1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++) 
                {
                    try
                    {
                        Console.Write("{0}. Satırının {1}. elemanını girin: ", i + 1, j + 1);
                        matris[i, j] = float.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        j--;
                    }
                }
            }
            return matris;
        }
        private static int BoyutAl()
        {
            Console.Write("nxn+1 Matris Boyutunu girin. n ->");
            int n = 0;
            try
            {
                n = int.Parse(Console.ReadLine());
                if (n < 2 || n > 100)
                {
                    if (n > 100)
                    {
                        Console.WriteLine("Girilen değer aşırı büyük!\nDaha küçük boyutları deneyin.\nDevam Etmek bir için bir tuşa basın...");
                    }
                    else
                    {
                        Console.WriteLine("Girilen değer 2'den küçük olamaz\nDevam Etmek bir için bir tuşa basın...");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    return -1;
                }
                else
                {
                    return n;
                }
            }
            catch (FormatException)
            {
                Console.Write("Geçersiz değer girişi Tekrar Deneyin.\nDevam Etmek bir için bir tuşa basın...");
                Console.ReadKey();
                Console.Clear();
                return -1;
            }
        }
    }
}
//float[,] array = new float[5, 6] { { 1, 1, 1, 6, 3, 4 }, { 2, 4, 5, 1, -1, 1 }, { -1, 2, 2, 9, 6, 2 }, { 6, 4, 3, 1, 2, -2 }, { 1, 6, 3, 4, 1, 2 } }; //test array