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
                Console.WriteLine("=== Барбершоп ===");
                Console.WriteLine("1 - Про програму");
                Console.WriteLine("2 - Таблиця вартості послуги");
                Console.WriteLine("3 - Завантаженість майстрів");
                Console.WriteLine("0 - Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ShowAbout();
                        Pause();
                        break;
                    case "2":
                        ShowCostTable();
                        Pause();
                        break;
                    case "3":
                        Console.WriteLine("Поки не зроблено.");
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

        static void ShowCostTable()
        {
            Console.WriteLine("Залежність ціни від тривалості стрижки:");
            Console.WriteLine($"{"Час (хв)",10} | {"Вартість (грн)",15}");
            Console.WriteLine(new string('-', 28));

            double from = 15.0;
            double to = 60.0;
            double step = 5.5;

            for (double x = from; x <= to + 1e-9; x += step)
            {
                double y = 200.0 + (x * 4.5);
                Console.WriteLine($"{x,10:F1} | {y,15:F2}");
            }
        }
    }
}