using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeEx7
{
    class Program
    {
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
            } while (!ok);
            return buf;
        }
        static void Main(string[] args)
        {
            bool flag = false;
            bool ok;
            int N;
            do
            {
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
                Console.WriteLine("Введите частоты букв по порядку, через Enter: ");
                double[] arr = new double[N];
                double summ = 0;
                for (int i = 0; i < N; i++)
                {
                    double prob = ScanDouble();
                    arr[i] = prob;
                    summ += arr[i];
                }
                if (summ == 1)
                    flag = true;
                else
                {
                    Console.WriteLine("Сумма всех частот должна равняться единице! Повторите ввод с самого начала.");
                    flag = false;
                }
            } while (!flag);

        }
    }
}
