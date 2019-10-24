using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace UTF8Converter
{
    class ConverterFunction
    {
        public ConverterFunction()
        {
            var f = new ProgramFunction("Convert file to UTF-8", Convert);
        }

        string SelectEncodingFile()
        {
            Console.WriteLine("\nPlease enter the name of the CP437 file.");
            string ans = Console.ReadLine();
            if(!File.Exists(Directory.GetCurrentDirectory() + "\\" + ans))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File does not exist.");
                ans = "";
                Console.ForegroundColor = ConsoleColor.White;
                return SelectEncodingFile();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ans + " selected.");
            Console.ForegroundColor = ConsoleColor.White;
            return ans;
        }

        string SelectTextFile()
        {
            Console.WriteLine("\nPlease enter the name of the encoded text file.");
            string ans = Console.ReadLine();
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\" + ans))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File does not exist.");
                ans = "";
                Console.ForegroundColor = ConsoleColor.White;
                return SelectTextFile();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ans + " selected.");
            Console.ForegroundColor = ConsoleColor.White;
            return ans;
        }

        void Convert()
        {
            Console.Clear();


            int[] cp437 = new int[256];
            string encoderName = SelectEncodingFile();
            string[] cp437Lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\" + encoderName);
            foreach(var l in cp437Lines)
            {
                int index = int.Parse(l.Split(':').First());
                int val = int.Parse(l.Split(':')[1]);
                cp437[index] = val;
            }


            string textFile = SelectTextFile();
            byte[] fileBytes = File.ReadAllBytes(Directory.GetCurrentDirectory() + "\\" + textFile);
            int[] unicode = new int[fileBytes.Length];

            FileStream f = File.OpenWrite(Directory.GetCurrentDirectory() + "\\output.txt");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine("Writing...");
            for (int i = 0; i < fileBytes.Length; i++)
            {
                int currentByteValue = fileBytes[i];
                unicode[i] = cp437[currentByteValue];
                string unicodeString = char.ConvertFromUtf32(unicode[i]).ToString();
                f.Write(DecimalToUnicodeConverter.GetBytesFromUnicodeCodePoint(unicode[i]), 0, DecimalToUnicodeConverter.GetBytesFromUnicodeCodePoint(unicode[i]).Length);
            }
            f.Close();
            Console.WriteLine("Finished writing to output.txt!");
            stopWatch.Stop();
            Console.WriteLine("Time elapsed: " + stopWatch.ElapsedMilliseconds + " ms");
            Console.ReadKey();
            Program.DoWelcomeScreen();
        }
    }
}
