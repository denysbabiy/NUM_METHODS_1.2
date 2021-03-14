using System;
using System.IO;
using System.Collections.Generic;

namespace kanafon
{
    class Program
    {
        static void SHOW_STEP(double[,] b, int n)
        {
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(Math.Round(b[i, j], 4) + " ");
                }
                Console.WriteLine();
            }
        }

        static void WRITE_STEP(double[,] b, int n, StreamWriter s)
        {
            s.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    s.Write(Math.Round(b[i, j], 4) + " ");
                }
                s.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            //Console.Write("Input the size of your matrix: ");
            //int k, i, j, n = Convert.ToInt32(Console.ReadLine());

            StreamWriter sw = File.CreateText("1.txt");

            string[] lines = File.ReadAllLines("TEST_MATRIX_1.txt");
            double[,] a = new double[lines.Length, lines[0].Split(' ').Length];

            for (int l = 0; l < lines.Length; l++)
            {
                string[] Temp = lines[l].Split(' ');
                for (int t = 0; t < Temp.Length; t++)
                    a[l, t] = Double.Parse(Temp[t]); 
            }
       
            int k, i, j, n = lines.Length;
            double[,] b = new double[n, n];
            /*
            double[,] a = new double[n, n];
            

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    a[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
            */

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write(a[i, j] + " ");
                    sw.Write(a[i, j] + " ");
                }
                Console.WriteLine();
                sw.WriteLine();
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        b[i, j] = 1;
                    }

                    else
                    {
                        b[i, j] = 0;
                    }
                }
            }

            for (k = 0; k < n; k++)
            {
                int i_m = k;
                double max = Math.Abs(a[k, k]);

                for (i = k + 1; i < n; i++)
                {
                    if (max < Math.Abs(a[i, k]))
                    {
                        max = Math.Abs(a[i, k]);
                        i_m = i;
                    }
                }

                for (j = k; j < n; j++)
                {
                    double c = a[k, j];
                    a[k, j] = a[i_m, j];
                    a[i_m, j] = c;

                }

                for (j = 0; j < n; j++)
                {
                    double c = b[k, j];
                    b[k, j] = b[i_m, j];
                    b[i_m, j] = c;
                }

                SHOW_STEP(a, n);
                SHOW_STEP(b, n);
                WRITE_STEP(a, n, sw);
                WRITE_STEP(b, n, sw);

                double r = 1 / a[k, k];
                for (j = 0; j < n; j++)
                {
                    a[k, j] = a[k, j] * r;
                    b[k, j] = b[k, j] * r;
                }

                SHOW_STEP(a, n);
                SHOW_STEP(b, n);
                WRITE_STEP(a, n, sw);
                WRITE_STEP(b, n, sw);

                for (i = k + 1; i < n; i++)
                {
                    double res = a[i, k];
                    for (int z = 0; z < n; z++)
                    {
                        a[i, z] = a[i, z] - a[k, z] * res;
                        b[i, z] = b[i, z] - b[k, z] * res;
                    }
                }

                SHOW_STEP(a, n);
                SHOW_STEP(b, n);
                WRITE_STEP(a, n, sw);
                WRITE_STEP(b, n, sw);
            }

            Console.WriteLine();
            sw.WriteLine();
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write(Math.Round(b[i, j], 4) + " ");
                    sw.Write(Math.Round(b[i, j], 4) + " ");
                }
                Console.WriteLine();
                sw.WriteLine();
            }

            double det = 1;
            for (i = 0; i < n; i++)
            {
                det *= Math.Round(a[i, i]);
            }

            if (Double.IsNaN(det))
            {
                Console.WriteLine("Matrix wasn`t inverted!");
                sw.WriteLine("Matrix wasn`t inverted!");
            }

            else
            {
                for (k = n - 1; k >= 0; k--)
                {
                    for (i = k - 1; i >= 0; i--)
                    {
                        double rez = a[i, k];

                        for (int z = n - 1; z >= 0; z--)
                        {
                            a[i, z] = a[i, z] - a[k, z] * rez;
                            b[i, z] = b[i, z] - b[k, z] * rez;
                        }
                    }
                    SHOW_STEP(a, n);
                    SHOW_STEP(b, n);
                    WRITE_STEP(a, n, sw);
                    WRITE_STEP(b, n, sw);
                }
            }

            sw.Close();
        }
    }
}