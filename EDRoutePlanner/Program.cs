using System;
using System.Threading.Tasks;
using EDRoutePlanner.SpanshApi;
using EDRoutePlanner.SpanshApi.Data.Plotter;

using static EDRoutePlanner.ConsoleHelper;

namespace EDRoutePlanner
{
    internal static class Program
    {
        private static readonly object _writeLock = new object();
        private static int Progress
        {
            set
            {
                lock (_writeLock)
                {
                    ConsoleSettings settings = SaveSetting(true);

                    Console.CursorLeft = 0;
                    Console.CursorTop = Console.WindowHeight - 1;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write($"Прогресс: {value}%");

                    LoadSettings(settings);
                }
            }
        }

        private static async Task Main()
        {
            Console.WriteLine("Вас приветствует наигламурнейший оптимизатор маршрутов по нейтронкам от TrickyBestia.");
            Console.Write("Введите начальную систему: ");
            string sourceSystem = Console.ReadLine();
            Console.Write("Введите конечную систему: ");
            string destinationSystem = Console.ReadLine();
            Console.Write("Введите дальность вашего прыжка: ");
            int range = int.Parse(Console.ReadLine());
            Progress = 0;

            Response optimalRoute = await Plotter.GetOptimalRoute(sourceSystem, destinationSystem, range, new Progress<int>(progress => Progress = progress));

            lock (_writeLock)
            {
                Console.WriteLine("Кратчайший маршрут:");
                ConsoleSettings settings = SaveSetting(false);
                Console.WriteLine($"https://spansh.co.uk/plotter/results/{optimalRoute.Result.Job.ToString().ToUpper()}{new Request(range, optimalRoute.Result.Efficiency, sourceSystem, destinationSystem).ToQuery()}");
                LoadSettings(settings);
                Console.ReadLine();
            }
        }
    }
}
