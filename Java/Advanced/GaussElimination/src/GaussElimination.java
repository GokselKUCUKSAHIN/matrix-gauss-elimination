import java.util.Scanner;

public class GaussElimination
{

    public static void main(String[] args)
    {
        int n = BoyutAl();
        if (n == -1) main(null);
        else
        {
            float[][] array = MatrisOlustur(n);
            MatrisYazdir(array);
            float[] result = gaussElimination(array);
            for (float item : result)
                System.out.println(item);
        }
    }

    private static float[] gaussElimination(float[][] matrix)
    {
        int n = matrix.length;
        for (int i = 0; i < n; i++)
        {
            float maxEl = Math.abs((matrix[i][i]));
            int maxRow = i;
            for (int k = i + 1; k < n; k++)
            {
                if (Math.abs(matrix[k][i]) > maxEl)
                {
                    maxEl = Math.abs(matrix[k][i]);
                    maxRow = k;
                }
            }
            for (int k = i; k < n + 1; k++)
            {
                float tmp = matrix[maxRow][k];
                matrix[maxRow][k] = matrix[i][k];
                matrix[i][k] = tmp;
            }
            for (int k = i + 1; k < n; k++)
            {
                float c = -matrix[k][i] / (float) matrix[i][i];
                for (int j = i; j < n + 1; j++)
                {
                    if (i == j) matrix[k][j] = 0;
                    else matrix[k][j] += c * matrix[i][j];
                }
            }
        }
        float x[] = new float[n]; //sonucu hesapla
        for (int i = n - 1; i >= 0; i--)
        {
            x[i] = matrix[i][n] / (float) matrix[i][i];
            for (int k = i - 1; k >= 0; k--)
                matrix[k][n] -= matrix[k][i] * x[i];
        }
        return x;
    }

    //
    private static int BoyutAl()
    {
        Scanner scanner = new Scanner(System.in);
        System.out.print("nxn+1 Matris Boyutunu girin. n ->");
        int n = 0;
        try
        {

            n = Integer.parseInt(scanner.nextLine());
            if (n < 2 || n > 100)
            {
                if (n > 100)
                {
                    System.out.println("Girilen değer aşırı büyük!\nDaha küçük boyutları deneyin.\nDevam Etmek bir için bir tuşa basın...");
                } else
                {
                    System.out.println("Girilen değer 2'den küçük olamaz\nDevam Etmek bir için bir tuşa basın...");
                }
                scanner.nextLine();
                return -1;
            } else
            {
                return n;
            }
        }
        catch (NumberFormatException ex)
        {
            System.out.println("Geçersiz değer girişi Tekrar Deneyin.\nDevam Etmek bir için bir tuşa basın...");
            scanner.nextLine();
            return -1;
        }
    }

    //
    private static float[][] MatrisOlustur(int n)
    {
        Scanner scanner = new Scanner(System.in);
        float[][] matris = new float[n][n + 1];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n + 1; j++)
            {
                try
                {
                    System.out.printf("%d. Satırının %d. elemanını girin: ", i + 1, j + 1);
                    matris[i][j] = Float.parseFloat(scanner.nextLine());
                }
                catch (NumberFormatException ex)
                {
                    j--;
                }
            }
        }
        return matris;
    }

    //
    private static void MatrisYazdir(float[][] matris)
    {
        int r = matris.length; //satır sayısı
        int c = matris[0].length; //kolon sayısı
        for (int i = 0; i < r; i++)
        {
            System.out.print("[");
            for (int j = 0; j < c - 1; j++)
                System.out.printf("%4.2f ", matris[i][j]);
            System.out.printf(" |%4.2f ", matris[i][c - 1]);
            System.out.println("]");
        }
    }
}