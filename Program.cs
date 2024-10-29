using System;
using System.Collections.Generic;
using System.IO;

namespace MathOperationsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var history = new List<string>();
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
            // Простой парсер для выражений (можно улучшить)
            var dataTable = new System.Data.DataTable();
            return Convert.ToDouble(dataTable.Compute(expression, string.Empty));
        }

        static void SaveHistory(List<string> history)
        {
            File.WriteAllLines("history.txt", history);
            Console.WriteLine("История сохранена в history.txt");
        }
    }
}
