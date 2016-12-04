using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class KeyPadSolver
    {
        private string[,] _keypad;

        public KeyPadSolver(string[,] keypad)
        {
            _keypad = keypad;
        }

        private bool IsValidPosition(Tuple<int, int> position)
        {
            if(position.Item1 >= 0 && position.Item2 >= 0)
            {
                if(position.Item1 < _keypad.GetLength(0) && position.Item2 < _keypad.GetLength(1))
                {
                    var value = _keypad[position.Item1, position.Item2];
                    if(!String.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public string GetCodeFromPosition(Tuple<int, int> position)
        {
            return _keypad[position.Item1, position.Item2];
        }

        public Tuple<int, int> GetCodePosition(char[] instructions, Tuple<int, int> startPosition)
        {
            var currentPosition = startPosition;

            foreach (var instruction in instructions)
            {
                if (instruction == 'L')
                {
                    var newPosition = new Tuple<int, int>(currentPosition.Item1, currentPosition.Item2 - 1);
                    if (IsValidPosition(newPosition))
                    {
                        currentPosition = newPosition;
                    }
                }
                if (instruction == 'R')
                {
                    var newPosition = new Tuple<int, int>(currentPosition.Item1, currentPosition.Item2 + 1);
                    if (IsValidPosition(newPosition))
                    {
                        currentPosition = newPosition;
                    }
                }
                if (instruction == 'U')
                {
                    var newPosition = new Tuple<int, int>(currentPosition.Item1 - 1, currentPosition.Item2);
                    if (IsValidPosition(newPosition))
                    {
                        currentPosition = newPosition;
                    }
                }
                if (instruction == 'D')
                {
                    var newPosition = new Tuple<int, int>(currentPosition.Item1 + 1, currentPosition.Item2);
                    if (IsValidPosition(newPosition))
                    {
                        currentPosition = newPosition;
                    }
                }
            }

            return currentPosition;
        }
    }
}
