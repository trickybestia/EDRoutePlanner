using System;

namespace EDRoutePlanner
{
    internal static class ConsoleHelper
    {
        public static ConsoleSettings SaveSetting(bool saveCursorPosition)
        {
            if (saveCursorPosition)
                return new ConsoleSettings(Console.ForegroundColor, Console.BackgroundColor, Console.CursorLeft, Console.CursorTop);
            else return new ConsoleSettings(Console.ForegroundColor, Console.BackgroundColor);
        }
        public static void LoadSettings(ConsoleSettings settings)
        {
            if (settings.CursorLeft is not null)
                Console.CursorLeft = settings.CursorLeft.Value;
            if (settings.CursorTop is not null)
                Console.CursorTop = settings.CursorTop.Value;
            Console.ForegroundColor = settings.ForegroundColor;
            Console.BackgroundColor = settings.BackgroundColor;
        }
    }
}
