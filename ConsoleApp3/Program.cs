using ClassLibrary1;
using System;
using static System.Console;
namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Введите текст чтобы записать лог:");
            string message = ReadLine();
            WriteLine(message);
            SaveLogs log = new SaveLogs();
            log.message += (mes) => WriteLine(mes);
            log.Add(message);
        }
    }
}
