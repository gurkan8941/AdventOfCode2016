using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var allDirections = ReadAllText("input1.txt");
            var directions = allDirections.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(d => d.Trim());
            var fromState = new State() { Direction = Direction.N, X = 0, Y = 0 };

            State firstRevisitedLocation = null;
            State toState = null;
            var allLocations = new Dictionary<string, State>();
            allLocations.Add(ToKey(fromState), fromState);
            foreach (var direction in directions)
            {
                toState = GoToNextLocation(fromState, direction);

                var visitedLocations = GetAllLocationsOnTheWay(fromState, toState);
                fromState = toState;

                foreach (var location in visitedLocations)
                {
                    if (allLocations.ContainsKey(ToKey(location)))
                    { 
                        if(firstRevisitedLocation == null)
                            firstRevisitedLocation = location;
                    }
                    else
                    {
                        allLocations.Add(ToKey(location), location);
                    }
                }
            }


            Console.WriteLine($"Distance from starting position: {Math.Abs(toState.X) + Math.Abs(toState.Y)}");
            Console.WriteLine($"Distance to first revisited position: {Math.Abs(firstRevisitedLocation.X) + Math.Abs(firstRevisitedLocation.Y)}");

            Console.ReadLine();
        }

        private static List<State> GetAllLocationsOnTheWay(State from, State to)
        {
            var locations = new List<State>();
            if(to.Direction == Direction.E)
            {
                for(int x = from.X + 1; x <= to.X; x++)
                {
                    locations.Add(new State() { Direction = to.Direction, X = x, Y = to.Y });
                }
            }
            if (to.Direction == Direction.W)
            {
                for (int x = from.X - 1; x >= to.X; x--)
                {
                    locations.Add(new State() { Direction = to.Direction, X = x, Y = to.Y });
                }
            }
            if (to.Direction == Direction.N)
            {
                for (int y = from.Y + 1; y <= to.Y; y++)
                {
                    locations.Add(new State() { Direction = to.Direction, X = to.X, Y = y });
                }
            }
            if (to.Direction == Direction.S)
            {
                for (int y = from.Y - 1; y >= to.Y; y--)
                {
                    locations.Add(new State() { Direction = to.Direction, X = to.X, Y = y });
                }
            }

            return locations;
        }

        private static string ToKey(State state)
        {
            return String.Concat(state.X, "_", state.Y);
        }

        private static State GoToNextLocation(State state, string direction)
        {
            var directionWay = direction.Substring(0, 1);
            var directionLength = Int32.Parse(direction.Substring(1));

            if(state.Direction == Direction.E)
            {
                if(directionWay == "L")
                {
                    return new State() { Direction = Direction.N, X = state.X, Y = state.Y + directionLength };
                }
                else
                {
                    return new State() { Direction = Direction.S, X = state.X, Y = state.Y - directionLength };
                }
            }
            if (state.Direction == Direction.W)
            {
                if (directionWay == "L")
                {
                    return new State() { Direction = Direction.S, X = state.X, Y = state.Y - directionLength };
                }
                else
                {
                    return new State() { Direction = Direction.N, X = state.X, Y = state.Y + directionLength };
                }
            }
            if (state.Direction == Direction.N)
            {
                if (directionWay == "L")
                {
                    return new State() { Direction = Direction.W, X = state.X - directionLength, Y = state.Y };
                }
                else
                {
                    return new State() { Direction = Direction.E, X = state.X + directionLength, Y = state.Y };
                }
            }
            if (state.Direction == Direction.S)
            {
                if (directionWay == "L")
                {
                    return new State() { Direction = Direction.E, X = state.X + directionLength, Y = state.Y };
                }
                else
                {
                    return new State() { Direction = Direction.W, X = state.X - directionLength, Y = state.Y };
                }
            }

            throw new NotSupportedException();
        }


        private static string ReadAllText(string fileName)
        {
            var path = Path.Combine(Environment.CurrentDirectory, fileName);
            var text = File.ReadAllText(path);
            return text;
        }
    }
}
