using System;
using System.Text;

namespace BarbershopApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool running = true;

            while (running)
            {
                ShowMenu();

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ShowAbout();
                        Pause();
                        break;
                    case "2":
                        double from = ReadDouble("Початковий час (хв, 10-120): ", 10, 120);
                        double to = ReadDouble("Кінцевий час (хв, від поч. до 240): ", from, 240);
                        double step = ReadDouble("Крок (хв, 1-30): ", 1, 30);
                        ShowCostTable(from, to, step);
                        Pause();
                        break;
                    case "3":
                        int rows = ReadInt("Введіть кількість майстрів (1-20): ", 1, 20);
                        int cols = ReadInt("Введіть кількість робочих днів (1-31): ", 1, 31);
                        ShowWorkloadTable(rows, cols);
                        Pause();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("До побачення!");
                        break;
                    default:
                        Console.WriteLine("Немає такого пункту. Спробуйте ще раз.");
                        Pause();
                        break;
                }
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nНатисніть будь-яку клавішу...");
            Console.ReadKey(true);
            Console.Clear();
        }

        static void ShowMenu()
        {
            Console.WriteLine("=== Барбершоп ===");
            Console.WriteLine("1 - Про програму");
            Console.WriteLine("2 - Таблиця вартості послуги");
            Console.WriteLine("3 - Завантаженість майстрів");
            Console.WriteLine("0 - Вихід");
            Console.Write("Ваш вибір: ");
        }

        static void ShowAbout()
        {
            Console.WriteLine("Тема проєкту: Барбершоп");
            Console.WriteLine("Головна сутність: Запис");
            Console.WriteLine("Перелік полів:");
            Console.WriteLine("- номер запису (int)");
            Console.WriteLine("- клієнт (string)");
            Console.WriteLine("- майстер (string)");
            Console.WriteLine("- код послуги з довідника (int)");
            Console.WriteLine("- дата й час (DateTime)");
            Console.WriteLine("- тривалість у хвилинах (int)");
            Console.WriteLine("- ціна (double)");
            Console.WriteLine("- чи виконано (bool)");
        }

        static void ShowCostTable(double from, double to, double step)
        {
            Console.WriteLine("Залежність ціни від тривалості стрижки:");
            Console.WriteLine($"{"Час (хв)",10} | {"Вартість (грн)",15}");
            Console.WriteLine(new string('-', 28));

            for (double x = from; x <= to + 1e-9; x += step)
            {
                double y = CalculatePrice(x);
                Console.WriteLine($"{x,10:F1} | {y,15:F2}");
            }
        }

        static void ShowWorkloadTable(int rows, int cols)
        {
            Console.WriteLine("\nЗавантаженість майстрів (к-сть клієнтів на день):");

            Console.Write($"{"Майстер",10}");
            for (int c = 1; c <= cols; c++)
            {
                Console.Write($"| День {c,-2} ");
            }
            Console.WriteLine("| Підсумок");

            double[] colTotals = new double[cols];
            double grandTotal = 0;

            for (int r = 1; r <= rows; r++)
            {
                Console.Write($"{"№" + r,10}");
                double rowTotal = 0;

                for (int c = 1; c <= cols; c++)
                {
                    double clients = r + c * 0.5;
                    Console.Write($"| {clients,7:F1}");

                    rowTotal += clients;
                    colTotals[c - 1] += clients;
                }
                grandTotal += rowTotal;
                Console.WriteLine($"| {rowTotal,8:F1}");
            }

            Console.Write($"{"Всього",10}");
            for (int c = 0; c < cols; c++)
            {
                Console.Write($"| {colTotals[c],7:F1}");
            }
            Console.WriteLine($"| {grandTotal,8:F1}");
        }

        static double CalculatePrice(double duration)
        {
            return 200.0 + (duration * 4.5);
        }

        static int ReadInt(string prompt, int min, int max)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result) && result >= min && result <= max)
                    return result;
                Console.WriteLine($"Помилка: введіть ціле число від {min} до {max}.");
            }
        }

        static double ReadDouble(string prompt, double min, double max)
        {
            double result;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out result) && result >= min && result <= max)
                    return result;
                Console.WriteLine($"Помилка: введіть число від {min} до {max}.");
            }
        }
    }
}