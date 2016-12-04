using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var allLines = ReadAllLines("input.txt").Select(l => l.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            var triangles = ParseTriangles(allLines);
            var validTriangles = triangles.Where(t => t.IsValid());

            Console.WriteLine($"There are {validTriangles.Count()} valid triangles");


            var allSides = allLines.SelectMany(s => s.Select(t => Int32.Parse(t)));
            triangles = ParseTriangles(allSides);
            validTriangles = triangles.Where(t => t.IsValid());

            Console.WriteLine($"There are {validTriangles.Count()} valid triangles");


            Console.ReadLine();
        }

        private static IEnumerable<Triangle> ParseTriangles(IEnumerable<int> inputSides)
        {
            var firstColumnSides = inputSides.Where((s, index) => (index % 3) == 0);
            var secondColumnSides = inputSides.Where((s, index) => (index % 3) == 1);
            var thirdColumnSides = inputSides.Where((s, index) => (index % 3) == 2);

            var triangles = new List<Triangle>();

            triangles.AddRange(GetTriangles(firstColumnSides));
            triangles.AddRange(GetTriangles(secondColumnSides));
            triangles.AddRange(GetTriangles(thirdColumnSides));

            return triangles;
        }

        private static IEnumerable<Triangle> GetTriangles(IEnumerable<int> columnSides)
        {
            var triangles = new List<Triangle>();

            for (int i = 0; i <= columnSides.Count() - 3; i = i + 3)
            {
                var triangle = new Triangle(columnSides.Skip(i).Take(3).ToArray());
                triangles.Add(triangle);
            }

            return triangles;
        }

        private static IEnumerable<Triangle> ParseTriangles(IEnumerable<string[]> inputLines)
        {
            var triangles = new List<Triangle>();
            foreach (var line in inputLines)
            {
                var sides = line.Select(l => Int32.Parse(l)).ToArray();
                var triangle = new Triangle(sides);
                triangles.Add(triangle);
            }

            return triangles;
        }

        private static string[] ReadAllLines(string fileName)
        {
            var path = Path.Combine(Environment.CurrentDirectory, fileName);
            var text = File.ReadAllLines(path);
            return text;
        }
    }
}
