using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeEx7
{
    public class Tree
    {
        public double data;
        public Tree left, right;
        public override string ToString()
        {
            return data.ToString();
        }
        public Tree(double value)
        {
            data = value;
            left = null;
            right = null;
        }
        public static Tree MakeAPoint(double value)
        {
            Tree nPoint = new Tree(value);
            return nPoint;
        }
        public static int GetSize(int length)
        {
            int size = length + (length - 1);
            return size;
        }
        public static CreateATree(double head, double[][] arr)
        {
            Tree root = MakeAPoint(head);
            for (int j = arr.Length - 2; j > -1; j--)
            {
                for (int i = arr[j].Length - 1; i > arr[j].Length - 3; i--)
                {

                }
            }

        }
        public void ShowTree(int indent)
        {
            if (left != null)
                left.ShowTree(indent + 3);
            Console.WriteLine(new string(' ', indent) + ToString());
            if (right != null)
                right.ShowTree(indent + 3);
        }
    }
    class Program
    {
        static double[][] ArraySort(double[][] arr)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                for (int i = 0; i < arr[j].Length; i++)
                {
                    double temp;
                    for (int k = i + 1; k < arr[j].Length; k++)
                    {
                        if (arr[i][j] < arr[k][j])
                        {
                            temp = arr[i][j];
                            arr[i][j] = arr[k][j];
                            arr[k][j] = temp;
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
                    arr[i][0] = freq;
                    summ += arr[i][0];
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
            for (int j = 1; j < arr.Length; j++)
            {
                for (int i = 0; i < arr[j].Length; i++)
                {
                    arr[i][j] = arr[i][j-1];
                    arr[arr[j].Length - 1][j] = arr[i + 1][j - 1] + arr[i][j - 1];
                }
                ArraySort(arr);
            }
            Console.WriteLine("Таблица для построения дерева: ");
            ShowArr(arr);

        }
    }
}
