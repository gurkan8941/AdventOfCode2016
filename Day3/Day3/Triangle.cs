using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Triangle
    {
        private int A;
        private int B;
        private int C;

        public Triangle(int[] sides)
        {
            A = sides[0];
            B = sides[1];
            C = sides[2];
        }

        public bool IsValid()
        {
            var AB = A + B;
            var AC = A + C;
            var BC = B + C;

            return AB > C && AC > B && BC > A;
        }
    }
}
