using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows. Forms;

namespace OOP28_04
{
    delegate void output(params object[] values);
    internal class Program
    {
        static void NamesOfObj(object[] _arr)
        {
            string output = string.Empty;
            int f = 0;
            foreach (var item in _arr)
            {
                output += $"{item.GetType()}\n";
                if(item.GetType() == f.GetType())// проверка объекта является ли он числом
                {
                    f+=int.Parse(item.ToString());
                }
            }
            Console.WriteLine(f);
            MessageBox.Show(output);
        }
        static void Main(string[] args)
        {
            Action<string> myActionDel; // встроенный делегат action, что то делает и ничего не возвращает
            output myPrint = (object[] _arr) =>// неявное определение функции
            {
                foreach (var item in _arr)
                {
                    Console.WriteLine($"{item} - {item.GetType()}");
                }
            };
            myPrint += NamesOfObj;
            myPrint += (object[] _arr) =>
            {
                using (var sw = new StreamWriter("output.txt", true))
                {
                    foreach (var item in _arr)
                    {
                        sw.WriteLine(item.ToString(), true);
                    }
                }
            };
            myPrint(1, "два", 3.5f, 'f');
            myPrint -= NamesOfObj;
            myPrint(2, (double)2.6, true, "END");
        }
    }
}
