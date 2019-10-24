﻿using System;
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


        void Convert()
        {
            int[] cp437 = new int[]
            {
                0, 1, 2, 3, 4, 5, 6,
                7, 8, 9, 10, 11, 12, 13, 14,
                15, 16, 17, 18, 19, 20, 21, 22,
                23, 24, 25, 26, 27, 28, 29, 30,
                31, 32, 33, 34, 35, 36, 37, 38,
                39, 40, 41, 42, 43, 44, 45, 46,
                47, 48, 49, 50, 51, 52, 53, 54,
                55, 56, 57, 58, 59, 60, 61, 62,
                63, 64, 65, 66, 67, 68, 69, 70,
                71, 72, 73, 74, 75, 76, 77, 78,
                79, 80, 81, 82, 83, 84, 85, 86,
                87, 88, 89, 90, 91, 92, 93, 94,
                95, 96, 97, 98, 99, 100, 101, 102,
                103, 104, 105, 106, 107, 108, 109, 110,
                111, 112, 113, 114, 115, 116, 117, 118,
                119, 120, 121, 122, 123, 124, 125, 126,
                8962, 199, 252, 233, 226, 228, 224, 229,
                231, 234, 235, 232, 239, 238, 236, 196,
                197, 201, 230, 198, 244, 246, 242, 251,
                249, 255, 214, 220, 162, 163, 165, 8359,
                402, 225, 237, 243, 250, 241, 209, 170,
                186, 191, 8976, 172, 189, 188, 161, 171,
                187, 9617, 9618, 9619, 9474, 9508, 9569, 9570,
                9558, 9557, 9571, 9553, 9559, 9565, 9564, 9563,
                9488, 9492, 9524, 9516, 9500, 9472, 9532, 9566,
                9567, 9562, 9556, 9577, 9574, 9568, 9552, 9580,
                9575, 9576, 9572, 9573, 9561, 9560, 9554, 9555,
                9579, 9578, 9496, 9484, 9608, 9604, 9612, 9616,
                9600, 945, 223, 915, 960, 931, 963, 181,
                964, 934, 920, 937, 948, 8734, 966, 949,
                8745, 8801, 177, 8805, 8804, 8992, 8993, 247,
                8776, 176, 8729, 183, 8730, 8319, 178, 9632,
                160
            };
            Console.Clear();
            byte[] fileBytes = File.ReadAllBytes(Directory.GetCurrentDirectory() + "\\386intel.txt");
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
