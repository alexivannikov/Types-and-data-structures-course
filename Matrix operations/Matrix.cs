/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 08.04.2020
 * Time: 9:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace swqqwqw
{
	/// <summary>
	/// Description of Matrix.
	/// </summary>
	public class Matrix
	{
		private int n {get; set;}
		private double [,] matr {get; set;}
		
		public Matrix(int n)
		{
			this.n = n;
			this.matr = matr;
			
			matr = new double[n,n];
		}
		
		/*Заполнение матрицы значениями*/
		public void MatrixInput()
		{			
			Random rnd = new Random();
			
			for(int i = 0; i <n; i++)
			{
				for(int j = 0; j<n; j++)
				{
					matr[i, j] = rnd.Next(1, 10);
				}
			}
		}
		
		/*Вывод матрицы на экран*/
		public void MatrixOutput()
		{						
			for(int i = 0; i <n; i++)
			{
				for(int j = 0; j<n; j++)
				{
					Console.Write(matr[i, j] + " ");
				}
				Console.WriteLine();
			}
			
			Console.WriteLine();
		}
		
		/*Сложение матриц*/
		public Matrix AddMatrix(Matrix A, Matrix B)
		{
			A.MatrixInput();
			A.MatrixOutput();
			B.MatrixInput();
			B.MatrixOutput();
			
			Matrix C = new Matrix(n);
			
			for(int i = 0; i < n; i++)
			{
				for(int j = 0; j < n; j++)
				{
					C.matr[i, j] = A.matr[i, j] + B.matr[i, j];
				}
			}
			
			C.MatrixOutput();
			
			return C;
		}
			
		/*Сортировка столбцов матрицы*/
		public Matrix MatrixBubbleColSort(Matrix A)
		{
			A.MatrixInput();
			A.MatrixOutput();
					
			double temp = 0;
			
			for(int k = 0; k < n -1; k++)
			{
				for (int j = 0; j < n - 1; j++)
				{
					if(A.matr[0, j] > A.matr[0, j + 1])
					{
						for(int i = 0; i < n; i++)
						{
							temp = A.matr[i, j+1];
							A.matr[i, j+1] = A.matr[i, j];
							A.matr[i, j] = temp;	
						}
					}
				}
			}
			
			A.MatrixOutput();
			
			return A;
		}
		
		/*Сортировка строк матрицы*/
		public Matrix MatrixBubbleRowSort(Matrix A)
		{
			A.MatrixInput();
			A.MatrixOutput();
			
			double temp = 0;
			
			for(int k = 0; k < n -1; k++)
			{
				for (int i = 0; i < n - 1; i++)
				{
					if(A.matr[i, 0] > A.matr[i+1, 0])
					{
						for(int j = 0; j < n; j++)
						{
							temp = A.matr[i+1, j];
							A.matr[i+1, j] = A.matr[i, j];
							A.matr[i, j] = temp;	
						}
					}
				}
			}
			
			A.MatrixOutput();
			
			return A;
		}
	}
}
