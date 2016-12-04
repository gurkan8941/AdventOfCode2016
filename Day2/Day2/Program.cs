using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var instructions = ReadAllLines("input1.txt");
            var code = String.Empty;
            var digit = 5;

            foreach(var instruction in instructions)
            {
                digit = GetCodeDigit(instruction.ToArray(), digit);
                code = String.Concat(code, digit);
            }

            Console.WriteLine($"The code is: {code}");
            Console.ReadLine();
        }

        private static int MinCurrentRow(int currentRow)
        {
            if (currentRow == 1)
                return 1;
            if (currentRow == 2)
                return 4;
            if (currentRow == 3)
                return 7;

            throw new NotSupportedException();
        }

        private static int MaxCurrentRow(int currentRow)
        {
            if (currentRow == 1)
                return 3;
            if (currentRow == 2)
                return 6;
            if (currentRow == 3)
                return 9;

            throw new NotSupportedException();
        }

        private static int MinCurrentColumn(int currentColumn)
        {
            if (currentColumn == 1)
                return 1;
            if (currentColumn == 2)
                return 2;
            if (currentColumn == 3)
                return 3;

            throw new NotSupportedException();
        }

        private static int MaxCurrentColumn(int currentColumn)
        {
            if (currentColumn == 1)
                return 7;
            if (currentColumn == 2)
                return 8;
            if (currentColumn == 3)
                return 9;

            throw new NotSupportedException();
        }

        private static int GetCodeDigit(char[] instructions, int startDigit)
        {
            var currentDigit = startDigit;

            foreach(var instruction in instructions)
            {
                var currentRow = currentDigit % 3 == 0 ? (currentDigit / 3) : (currentDigit / 3) + 1;
                var currentColumn = currentDigit % 3 == 0 ? 3 : currentDigit % 3;

                if(instruction == 'L')
                {
                    currentDigit = currentDigit - 1 < MinCurrentRow(currentRow) ? MinCurrentRow(currentRow) : currentDigit - 1;
                }
                if (instruction == 'R')
                {
                    currentDigit = currentDigit + 1 > MaxCurrentRow(currentRow) ? MaxCurrentRow(currentRow) : currentDigit + 1;
                }
                if (instruction == 'U')
                {
                    currentDigit = currentDigit - 3 < MinCurrentColumn(currentColumn) ? MinCurrentColumn(currentColumn) : currentDigit - 3;
                }
                if (instruction == 'D')
                {
                    currentDigit = currentDigit + 3 > MaxCurrentColumn(currentColumn) ? MaxCurrentColumn(currentColumn) : currentDigit + 3;
                }
            }

            return currentDigit;
        }

        private static string[] ReadAllLines(string fileName)
        {
            var path = Path.Combine(Environment.CurrentDirectory, fileName);
            var text = File.ReadAllLines(path);
            return text;
        }
    }
}
