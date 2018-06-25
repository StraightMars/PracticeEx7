using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeEx7
{
    public class Tree : IComparable
    {
        public double data;
        public Tree left, right;
        public string word;
        public override string ToString()
        {
            return "tree" + this.data;
        }
        public Tree(double value)
        {
            this.data = value;
        }
        public void ShowTree(int indent)
        {
            if (this.left != null)
                this.left.ShowTree(indent + 3);
            Console.WriteLine(new string(' ', indent) + ToString());
            if (this.right != null)
                this.right.ShowTree(indent + 3);
        }
        public int CompareTo(object obj)
        {
            Tree tree = obj as Tree;
            if (this.data < tree.data)
                return -1;
            if (this.data > tree.data)
                return 1;
            else
                return 0;
        }
    }
    class Words
    {
        public static List<string> list;
        public static void GetWords(Tree tree, string letters = "")
        {
            if (tree.right == null && tree.left == null)
            {
                tree.word = letters;
                list.Add(letters);
            }
            if (tree.right != null)
                GetWords(tree.right, letters + "0");
            if (tree.left != null)
                GetWords(tree.left, letters + "1");
        }
        public static List<string> getWords(Tree tree)
        {
            list = new List<string>();
            GetWords(tree);
            return list;
        }
    }
    class Program
    {
        static double GetSum(List<double> list)
        {
            double sum = 0;
            foreach (double elem in list)
            {
                sum += elem;
            }
            return sum;
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
        static string StringReverse(string s)
        {
            char[] ch = s.ToCharArray();
            for (int i = 0; i < ch.Length / 2; i++)
            {
                char tmp = ch[ch.Length - i - 1];
                ch[ch.Length - i - 1] = ch[i];
                ch[i] = tmp;
            }
            s = new string(ch);
            return s;
        }
        static void Main(string[] args)
        {
            List<double> list = new List<double>();
            Console.WriteLine("Вводите частоты букв по порядку через Enter.\nКогда сумма частот достигнет единицы, ввод прекратится.");
            while (true)
            {
                double elem = ScanDouble();
                list.Add(elem);
                double sum = GetSum(list);
                if (sum > 1)
                {
                    Console.WriteLine("Ошибка ввода! Сумма частот не должна превышать 1. Повторите ввод с самого начала.");
                    list = new List<double>();
                }
                if (sum == 1)
                    break;
            }
            Console.WriteLine("Отсортированные введенные частоты: ");
            list.Sort();
            list.Reverse();
            foreach (double elem in list)
                Console.WriteLine(elem);
            List<Tree> treeList = new List<Tree>();
            for (int i = 0; i < list.Count; i++)
            {
                treeList.Add(new Tree(list[i]));
            }
            while (treeList.Count > 1)
            {
                treeList.Sort();
                Tree first = treeList[0];
                Tree second = treeList[1];
                treeList[1] = new Tree(first.data + second.data);
                treeList[1].right = first;
                treeList[1].left = second;
                treeList.RemoveAt(0);
            }
            List<string> codes = Words.getWords(treeList[0]);
            Console.WriteLine("Полученный результат: ");
            for (int i = 0; i < codes.Count; i++)
            {
                string reversed = StringReverse(codes[i]);
                codes[i] = reversed;
            }
            codes.Sort();
            foreach (string elem in codes)
            {
                Console.WriteLine(elem);
            }
            Console.ReadLine();
        }
    }
}
