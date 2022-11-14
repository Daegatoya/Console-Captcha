using System.Text.RegularExpressions;

namespace Captcha
{
    public static class Class
    {
        public static void Check(string code)
        {
            int attempts = 5;
            string pattern = @"^\d+$";
            Regex regex = new Regex(pattern);

            switch (Console.ReadLine())
            {
                case var value when value == code:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\tAccess Granted");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case var value when !regex.IsMatch(value):
                    while (!regex.IsMatch(value))
                    {
                        Console.Write("\n\n\tPlease only input numbers. Retry : ");
                        value = Console.ReadLine();
                    }
                    if(value == code)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\tAccess Granted");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        attempts--;
                        while (value != code)
                        {
                            Console.Write($"\n\n\tWrong captcha. {attempts} attempts left : ");
                            attempts--;
                            value = Console.ReadLine();
                            while (!regex.IsMatch(value))
                            {
                                Console.Write("\n\n\tPlease only input numbers. Retry : ");
                                value = Console.ReadLine();
                            }
                            if (value == code)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n\tAccess Granted");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (attempts == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\tAccess Denied");
                                Console.ForegroundColor = ConsoleColor.White;
                                Environment.Exit(0x1);
                            }
                        }
                    }
                    break;

                case var value when value != code:
                        attempts--;
                        while (value != code)
                        {
                            Console.Write($"\n\n\tWrong captcha. {attempts} attempts left : ");
                            attempts--;
                            value = Console.ReadLine();
                        while (!regex.IsMatch(value))
                        {
                            Console.Write("\n\n\tPlease only input numbers. Retry : ");
                            value = Console.ReadLine();
                        }
                        if (value == code)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n\tAccess Granted");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (attempts == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\tAccess Denied");
                            Console.ForegroundColor = ConsoleColor.White;
                            Environment.Exit(0x1);
                        }
                    }
                    break;
            }
        }

        public static void Main()
        {
            string? captcha = null;
            int? num;
            string test;
            Random nb = new Random();

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    num = nb.Next(1, 10);
                    captcha += num.ToString();
                }
            }
            catch
            {
                captcha = null;
            }

            while (captcha == null)
            {
                test = captcha != null ? captcha : $@"Error while generating the Captcha. Retrying...";

                switch (test)
                {
                    case var value when value != captcha:
                        Console.WriteLine(test + "\n");
                        for (int i = 0; i < 5; i++)
                        {
                            num = nb.Next(1, 10);
                            captcha += num.ToString();
                        }
                break;
                }
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t----------------");
            Console.WriteLine("\t\t     " + captcha);
            Console.WriteLine("\t\t----------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\tPlease enter the Captcha here : ");
            Check(captcha);
        }
    }
}
