using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2016_1
{
    public class State
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Direction Direction { get; set; }

    }

    public enum Direction
    {
        N,S,E,W
    }
}
