using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day3
{
    public class Solver
    {
        private class Coordinate
        {
            public int X { get; set; }

            public int Y { get; set; }

            public int Distance => Math.Abs(X) + Math.Abs(Y);

            public Coordinate() : this(null)
            { }

            public Coordinate(Coordinate coordinate)
            {
                if (coordinate == null)
                    return;

                X = coordinate.X;
                Y = coordinate.Y;
            }

            public override bool Equals(object obj)
            {
                if (obj is Coordinate coordinate)
                    return X == coordinate.X && Y == coordinate.Y;
                return false;
            }

            public override int GetHashCode()
            {
                return X.GetHashCode() + Y.GetHashCode();
            }
        }

        internal int Solve1(string input)
        {
            int closesCross = -1;

            IEnumerable<string[]> linesDirections = input.Split(Environment.NewLine).Select(l => l.Split(","));

            //Map Coordinates
            List<List<Coordinate>> linesCoordinates = new List<List<Coordinate>>();
            for (var i = 0; i < linesDirections.Count(); i++)
            {
                Tuple<int, int> coordinate2 = new Tuple<int, int>(0, 0);
                string[] lineDirections = linesDirections.ElementAt(i);

                Coordinate coordinate = new Coordinate();
                List<Coordinate> lineCoordinates = new List<Coordinate>();
                for(var j = 0; j < lineDirections.Length; j++)
                {
                    coordinate = new Coordinate(coordinate);
                    string direction = lineDirections[j];

                    char direction2 = direction[0];
                    int distance = int.Parse(direction.Substring(1));

                    switch(direction2)
                    {
                        case 'R':
                            coordinate.X -= distance;
                            break;
                        case 'U':
                            coordinate.Y += distance;
                            break;
                        case 'L':
                            coordinate.X += distance;
                            break;
                        case 'D':
                            coordinate.Y -= distance;
                            break;
                    }

                    lineCoordinates.Add(coordinate);
                }
                linesCoordinates.Add(lineCoordinates);
            }


            List<Coordinate> matches = new List<Coordinate>();
            foreach (var coordinate in linesCoordinates[0])
            {
                var isMatch = linesCoordinates[1].Contains(coordinate);
                matches.Add(coordinate);
            }

            matches.OrderBy(m => m.Distance);
            closesCross = matches.First().Distance;
            return closesCross;

        }
    }
}
