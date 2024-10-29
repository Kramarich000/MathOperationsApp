using System;
using System.Collections.Generic;
using System.IO;

namespace MathOperationsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var history = LoadHistory();
            string input;
            Console.WriteLine("Введите математические выражения (или 'exit' для выхода):");

            while (true)
            {
                Console.Write("> ");
                input = Console.ReadLine();
                if (input.ToLower() == "exit") break;

                try
                {
                    double result = EvaluateExpression(input);
                    Console.WriteLine($"Результат: {result}");
                    history.Add($"{input} = {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }

            SaveHistory(history);
        }

        static double EvaluateExpression(string expression)
        {
            var dataTable = new System.Data.DataTable();
            return Convert.ToDouble(dataTable.Compute(expression, string.Empty));
        }
        static List<string> LoadHistory()
        {
            if (File.Exists("history.txt"))
            {
                return new List<string>(File.ReadAllLines("history.txt"));
            }
            return new List<string>();
        }

        static void SaveHistory(List<string> history)
        {
            Console.WriteLine("Сохраняем историю");
            File.WriteAllLines("history.txt", history);
            Console.WriteLine("История сохранена в history.txt");
        }
    }
}
