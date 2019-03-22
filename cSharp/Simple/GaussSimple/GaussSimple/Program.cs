using System;
namespace GaussSimple {
    class Program {
        static void Main() {
            Console.Write("nxn+1 Matrisin Boyunu girin. n->");
            int n = Int32.Parse(Console.ReadLine());
            float[,] matrix = new float[n, n + 1];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n+1; j++)
                    matrix[i, j] = float.Parse(Console.ReadLine());
            var result = GaussElimination(matrix);
            foreach (var item in result)
                Console.WriteLine(item);
        }
        private static float[] GaussElimination(float[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++) {
                float maxEl = Math.Abs(matrix[i, i]);
                int maxRow = i;
                for (int k = i + 1; k < n; k++)
                    if (Math.Abs(matrix[k, i]) > maxEl){
                        maxEl = Math.Abs(matrix[k, i]);
                        maxRow = k;}
                for (int k = i; k < n + 1; k++){
                    float tmp = matrix[maxRow, k];
                    matrix[maxRow, k] = matrix[i, k];
                    matrix[i, k] = tmp;}
                for (int k = i + 1; k < n; k++){
                    float c = -matrix[k, i] / matrix[i, i];
                    for (int j = i; j < n + 1; j++){
                        if (i == j) matrix[k, j] = 0;
                        else matrix[k, j] += c * matrix[i, j];}}}
            float[] x = new float[n];
            for (int i = n - 1; i >= 0; i--){
                x[i] = matrix[i, n] / matrix[i, i];
                for (int k = i - 1; k >= 0; k--)
                    matrix[k, n] -= matrix[k, i] * x[i];}
            return x;
        }
    }
}