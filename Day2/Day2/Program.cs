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

            var keypadSolver = new KeyPadSolver(GetTraditionalKeyPad());
            var startPosition = new Tuple<int, int>(1, 1);
            var traditionalCode = GetCode(keypadSolver, startPosition, instructions);

            keypadSolver = new KeyPadSolver(GetDesignedKeyPad());
            var currentPosition = new Tuple<int, int>(2, 0);
            var designCode = GetCode(keypadSolver, currentPosition, instructions);


            Console.WriteLine($"The traditional code is: {traditionalCode}");
            Console.WriteLine($"The design code is: {designCode}");
            Console.ReadLine();
        }

        private static string GetCode(KeyPadSolver keypadSolver, Tuple<int, int> startPosition, string[] instructions)
        {
            var code = String.Empty;
            var currentPosition = startPosition;

            foreach (var instruction in instructions)
            {
                currentPosition = keypadSolver.GetCodePosition(instruction.ToArray(), currentPosition);
                var instructionCode = keypadSolver.GetCodeFromPosition(currentPosition);
                code = String.Concat(code, instructionCode);
            }

            return code;
        }

        private static string[,] GetDesignedKeyPad()
        {
            var keyPad = new string[5, 5];
            keyPad[0, 2] = "1";
            keyPad[1, 1] = "2";
            keyPad[1, 2] = "3";
            keyPad[1, 3] = "4";
            keyPad[2, 0] = "5";
            keyPad[2, 1] = "6";
            keyPad[2, 2] = "7";
            keyPad[2, 3] = "8";
            keyPad[2, 4] = "9";
            keyPad[3, 1] = "A";
            keyPad[3, 2] = "B";
            keyPad[3, 3] = "C";
            keyPad[4, 2] = "D";

            return keyPad;
        }

        private static string[,] GetTraditionalKeyPad()
        {
            var keyPad = new string[3, 3];
            keyPad[0, 0] = "1";
            keyPad[0, 1] = "2";
            keyPad[0, 2] = "3";
            keyPad[1, 0] = "4";
            keyPad[1, 1] = "5";
            keyPad[1, 2] = "6";
            keyPad[2, 0] = "7";
            keyPad[2, 1] = "8";
            keyPad[2, 2] = "9";

            return keyPad;
        }

        private static string[] ReadAllLines(string fileName)
        {
            var path = Path.Combine(Environment.CurrentDirectory, fileName);
            var text = File.ReadAllLines(path);
            return text;
        }
    }
}
