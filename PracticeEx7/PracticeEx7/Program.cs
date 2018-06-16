using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeEx7
{
    class Program
    {
        static double[][] ArraySort(double[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    double temp;
                    for (int k = j + 1; k < arr[i].Length; k++)
                    {
                        if (arr[i][j] < arr[i][k])
                        {
                            temp = arr[i][j];
                            arr[i][j] = arr[i][k];
                            arr[i][k] = temp;
                        }
                    }
                }
            }
            return arr;
        }
        static void ShowArr(double[][] arr)
        {
            Console.WriteLine("Указанные частоты: ");
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                    Console.Write("{0, 7}", arr[i][j]);
                Console.Write("\n");
            }
        }
        static void CreateTree(double[] arr)
        {

        }
        static double ScanDouble()
        {
            bool ok;
            double buf;
            do
            {
                ok = double.TryParse(Console.ReadLine(), out buf);
                if (!ok)
                    Console.WriteLine("Ошибка! Введите действительное число");
                if (buf <= 0)
                {
                    Console.WriteLine("Ошибка! Введите действительное число большее 0!");
                    ok = false;
                }
                if (buf > 1)
                {
                    Console.WriteLine("Частота - величина, в диапазоне от нуля до единицы! Повторите ввод.");
                    ok = false;
                }
            } while (!ok);
            return buf;
        }
        static void Main(string[] args)
        {
            bool flag = false;
            bool ok;
            int N;
            Console.WriteLine("Введите количество букв в алфавите: ");
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out N);
                if (!ok)
                    Console.WriteLine("Ошибка! Введите натуральное число!");
                if (N <= 0)
                {
                    Console.WriteLine("Ошибка! Введите натуральное число!");
                    ok = false;
                }
            } while (!ok);
            double[][] arr = new double[N][];
            for (int i = 0; i < N; i++)
            {
                int columns = N - i;
                arr[i] = new double[columns];
            }
            do
            {
                Console.WriteLine("Введите частоты букв по порядку, через Enter: ");
                double summ = 0;
                for (int i = 0; i < N; i++)
                {
                    double freq = ScanDouble();
                    arr[0][i] = freq;
                    summ += arr[0][i];
                }
                if (summ == 1)
                {
                    flag = true;

                }
                else
                {
                    Console.WriteLine("Сумма всех частот должна равняться единице! Повторите ввод с самого начала.");
                    flag = false;
                }
            } while (!flag);
            ArraySort(arr);
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = arr[i - 1][j];
                    arr[i][arr[i].Length - 1] = arr[i - 1][arr[i-1].Length - 1] + arr[i - 1][arr[i-1].Length - 2];
                }
                ArraySort(arr);
            }
            ShowArr(arr);
        }
    }
}
