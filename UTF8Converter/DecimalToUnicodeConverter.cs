using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTF8Converter
{
    class DecimalToUnicodeConverter
    {
        public DecimalToUnicodeConverter()
        {
            var f = new ProgramFunction("Convert decimal to UTF-8", Convert);
        }

        

        void Convert()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Encoding utf8 = new UTF8Encoding();
            

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Enter a decimal number to convert it to an UTF-8 symbol and show Unicode and UTF-8 number codes.");
            Console.WriteLine("Enter the command BACK to return to the menu.");
            while (true)
            {
                string val = Console.ReadLine();

                if (val.ToLower() == "back")
                {
                    Program.DoWelcomeScreen();
                    break;
                }

                int intValue;
                if (!int.TryParse(val, out intValue))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(val + " That is not a decimal number.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                

                //Display unicode code point
                Console.WriteLine();
                Console.WriteLine("Unicode number: U+" + intValue.ToString("X4"));

                //Display UTF-8 bytes in hex
                Console.Write("UTF-8 number: ");
                byte[] utf8bytes = GetBytesFromUnicodeCodePoint(intValue);
                foreach (var byt in utf8bytes)
                {
                    Console.Write(byt.ToString("X2") + " ");
                }
                //Display character encoded in UTF-8
                Console.Write("\nCharacter: ");
                string unicodeString = char.ConvertFromUtf32(intValue).ToString();
                Console.WriteLine(unicodeString);
                Console.WriteLine();
            }
        }
        public static byte[] GetBytesFromUnicodeCodePoint(int intValue)
        {
            return Encoding.UTF8.GetBytes(char.ConvertFromUtf32(intValue).ToString());
        }
    }
}
