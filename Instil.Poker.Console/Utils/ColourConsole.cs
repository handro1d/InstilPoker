using System;

namespace Instil.Poker.Console.Utils
{
    public static class ColourConsole
    {
        /// <summary>
        /// Read user input.
        /// </summary>
        /// <param name="prompt">Prompt to provide user</param>
        /// <param name="colour"><see cref="ConsoleColour"> to write prompt in</param>
        /// <returns>String value entered by User.</returns>
        public static string ReadLine(string prompt, ConsoleColor? colour = null)
        {
            Write(prompt, colour);
            return System.Console.ReadLine();
        }

        /// <summary>
        /// WriteLine with colour.
        /// </summary>
        /// <param name="message">Message to write to the console.</param>
        /// <param name="colour"><see cref="ConsoleColour"> to write prompt in</param>
        public static void WriteLine(string message, ConsoleColor? colour = null)
        {
            if (!colour.HasValue)
            {
                System.Console.WriteLine(message);
                return;
            }

            System.Console.ForegroundColor = colour.Value;
            System.Console.WriteLine(message);
            System.Console.ResetColor();
        }

        /// <summary>
        /// Write with colour.
        /// </summary>
        /// <param name="message">Message to write to the console.</param>
        /// <param name="colour"><see cref="ConsoleColour"> to write prompt in</param>
        public static void Write(string message, ConsoleColor? colour = null)
        {
            if (!colour.HasValue)
            {
                System.Console.Write(message);
                return;
            }

            System.Console.ForegroundColor = colour.Value;
            System.Console.Write(message);
            System.Console.ResetColor();
        }
    }
}