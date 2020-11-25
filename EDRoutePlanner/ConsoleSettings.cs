using System;

namespace EDRoutePlanner
{
    internal record ConsoleSettings(ConsoleColor ForegroundColor, ConsoleColor BackgroundColor, int? CursorLeft = null, int? CursorTop = null);
}
