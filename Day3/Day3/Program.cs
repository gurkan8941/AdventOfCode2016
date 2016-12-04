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
            Console.ReadLine();
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
