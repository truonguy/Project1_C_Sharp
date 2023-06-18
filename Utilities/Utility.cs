using System.Text;
using System.Text.RegularExpressions;

namespace Utilities
{
    public class Utility
    {
        public static void WaitForKey(string msg)
        {
            Console.Write(msg);
            Console.ReadKey();
        }

        public static string FormatCurrency(string currency)
        {
            for (int i = currency.Length - 3; i > 0; i = i - 3)
            {
                currency = currency.Insert(i, ".");
            }
            return currency;
        }

        public static bool IsContinue(string text)
        {
            Console.Write(text);
            string input = Console.ReadLine() ?? "";
            while (true)
            {
                if (Regex.Match(input, @"^[yYnN]$").Success)
                {
                    break;
                }
                else
                {
                    Console.Write("Choose (Y/N): ");
                    input = Console.ReadLine() ?? "";
                }
            }
            if (input == "y" || input == "Y")
            {
                return true;
            }
            return false;
        }


        public static string GetPassword()
        {
            StringBuilder sb = new StringBuilder();

            // Vòng lặp liên tục đọc các ký tự từ console cho đến khi người dùng bấm phím Enter
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        sb.Length--;
                    }
                    continue;
                }
                Console.Write('*');
                sb.Append(cki.KeyChar);
            }
            return sb.ToString();
        }


        public static int Menu(string[] menu, string name)
        {
            Console.Clear();
            Console.WriteLine("=================================================================================================");
            Console.WriteLine($"                                             {name,-25}                                         ");
            Console.WriteLine("=================================================================================================");
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menu[i]}");
            }
            Console.WriteLine("=================================================================================================");
            int choice;
            do
            {
                Console.Write("Choose: ");
                int.TryParse(Console.ReadLine(), out choice);
            } while (choice < 1 || choice > menu.Length);
            return choice;
        }
    }
}