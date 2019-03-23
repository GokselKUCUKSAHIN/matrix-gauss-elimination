#include "pch.h"
#include<iostream>
#include <math.h>
#define MAX 21
//float matrix[3][4] = { {1,2,3,4},{6,7,4,2},{8,6,4,2} }; //test matrix
void GaussElimination(float matrix[][MAX], int len);
using namespace std;
int main() {
	//float  matrix[MAX-1][MAX], ratio, det; //MAX = Max limit of Matris Size

	int i, j, k, n;

	printf("nxn+1 Matrisinin Boyutunu Girininz: ");
	cin >> n;
	float matrix[MAX - 1][MAX];

	cout << "Matrise Eleman Giriniz:" << endl;
	for (i = 0; i < n; i++) {
		for (j = 0; j < n + 1; j++) {
			printf("%d. Satirinin %d. elemanini girin: ", i + 1, j + 1);
			cin >> matrix[i][j];
		}
	}
	for (i = 0; i < n; i++)
	{
		for (j = 0; j < n + 1; j++)
		{
			printf(" %4.2f", matrix[i][j]);
		}
		cout << endl;
	}
	for (i = 0; i < n; i++)
	{
		for (j = 0; j < n + 1; j++)
		{
			printf(" %4.2f", matrix[i][j]);
		}
		cout << endl;
	}
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

	float x[MAX];
	for (i = n - 1; i >= 0; i--) {
		x[i] = matrix[i][n] / (float)matrix[i][i];
		for (k = i - 1; k >= 0; k--)
			matrix[k][n] -= matrix[k][i] * x[i];
	}
	for (i = 0; i < n; i++) {
		printf("%lf\n", x[i]);
	}
	system("pause");
	return 0;
}