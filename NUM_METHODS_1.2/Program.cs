using System;

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
                    Console.Write(Math.Round(b[i, j], 6) + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Input the size of your matrix: ");
            int k, i, j, n = Convert.ToInt32(Console.ReadLine());

            double[,] a = new double[n, n];
            double[,] b = new double[n, n];

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    a[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
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

                double r = 1 / a[k, k];
                for (j = 0; j < n; j++)
                {
                    a[k, j] = a[k, j] * r;
                    b[k, j] = b[k, j] * r;
                }

                SHOW_STEP(a, n);
                SHOW_STEP(b, n);

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
            }

            Console.WriteLine();
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write(Math.Round(b[i, j], 4) + " ");
                }
                Console.WriteLine();
            }

            double det = 1;
            for (i = 0; i < n; i++)
            {
                det *= Math.Round(a[i, i]);
            }

            if (Double.IsNaN(det))
            {
                Console.WriteLine("Matrix wasn`t inverted!");
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
                }
            }
        }
    }
}