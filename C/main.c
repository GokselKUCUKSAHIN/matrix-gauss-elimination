#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main() {
	int i, j, k, n;
	printf("nxn Matrisinin Boyutunu Girininz: "); //matris boyutunu al
	scanf("%d",&n);
	float matrix[n][n+1]; //Matris oluþtur
	//Eleman gir
	printf("Matrise Eleman Giriniz:\n");
	for (i = 0; i < n; i++) {
		for (j = 0; j < n + 1; j++) {
			printf("%d. Satirinin %d. elemanini girin: ", i + 1, j + 1);
			scanf("%f",&matrix[i][j]);
		}
	}
	//Yazdýr
	for(i = 0;i< n;i++) {
		for (j=0;j<n+1;j++)
			printf(" %4.2f",matrix[i][j]);
		printf("\n");
	}
	//Gauss Elimination
	for (i = 0; i < n; i++) {
        float maxEl = abs(matrix[i][i]);
        int maxRow = i;
        for (k = i + 1; k < n; k++) {
            if (abs(matrix[k][i]) > maxEl) {
                maxEl = abs(matrix[k][i]);
                maxRow = k;
            }
        }
        for (k = i; k < n + 1; k++) {
            float tmp = matrix[maxRow][k];
            matrix[maxRow][k] = matrix[i][k];
            matrix[i][k] = tmp;
        }
        for (k = i + 1; k < n; k++) {
            float c = -matrix[k][i] / (float)matrix[i][i];
            	for (j = i; j < n + 1; j++) {
                    if (i == j) matrix[k][j] = 0;
                    else matrix[k][j] += c * matrix[i][j];
                }
        }
    }
    float x[n]; //sonucu hesapla
    for (i = n - 1; i >= 0; i--) {
        x[i] = matrix[i][n] / (float)matrix[i][i];
        for (k = i - 1; k >= 0; k--)
            matrix[k][n] -= matrix[k][i] * x[i];
    }
    //sonuçlarý yazdýr
    for(i=0;i<n;i++) {
    	printf("%f\n",x[i]);
	}
	system("pause");//dur
	return 0;
}
