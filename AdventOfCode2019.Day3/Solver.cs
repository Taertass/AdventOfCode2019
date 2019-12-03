using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day3
{
    public class Solver
    {
        private class Point
        {
            public int X { get; set; }

            public int Y { get; set; }

            public int Distance => Math.Abs(X) + Math.Abs(Y);

            public int Index { get; internal set; }

            public Point() : this(null)
            { }

            public Point(Point coordinate)
            {
                if (coordinate == null)
                    return;

                X = coordinate.X;
                Y = coordinate.Y;
            }

            public override bool Equals(object obj)
            {
                if (obj is Point coordinate)
                    return X == coordinate.X && Y == coordinate.Y;
                return false;
            }

            public override int GetHashCode()
            {
                return X.GetHashCode() + Y.GetHashCode();
            }

            public override string ToString()
            {
                return $"{X}, {Y}, {Distance}, {Index}";
            }
        }

        int[,] grid = new int[1000,1000];

        internal int Solve1(string input)
        {
            int closesCross = -1;

            IEnumerable<string[]> linesDirections = input.Split(Environment.NewLine).Select(l => l.Split(","));


            //Map Coordinates
            List<List<Point>> linesCoordinates = new List<List<Point>>();
            for (var i = 0; i < linesDirections.Count(); i++)
            {
                Tuple<int, int> coordinate2 = new Tuple<int, int>(0, 0);
                string[] lineDirections = linesDirections.ElementAt(i);

                Point coordinate = new Point();
                List<Point> lineCoordinates = new List<Point>();
                int index = 0;
                for(var j = 0; j < lineDirections.Length; j++)
                {
                    string direction = lineDirections[j];

                    char direction2 = direction[0];
                    int distance = int.Parse(direction.Substring(1));

                    for(var k = 0; k < distance; k++)
                    {
                        coordinate = new Point(coordinate);
                        coordinate.Index = index;

                        switch (direction2)
                        {
                            case 'R':
                                coordinate.X += 1;
                                break;
                            case 'U':
                                coordinate.Y += 1;
                                break;
                            case 'L':
                                coordinate.X -= 1;
                                break;
                            case 'D':
                                coordinate.Y -= 1;
                                break;
                        }

                        lineCoordinates.Add(coordinate);
                        index++;
                    }    
                }

                linesCoordinates.Add(lineCoordinates);
            }

            //Find intersections
            List<Tuple<Point, Point>> matches = new List<Tuple<Point, Point>>();
            Dictionary<int, Tuple<Point, Point>> matches2 = new Dictionary<int, Tuple<Point, Point>>();
            foreach (var coordinate in linesCoordinates[0])
            {
                var coordinate2 = linesCoordinates[1].FirstOrDefault(c => c.Equals(coordinate));
                if(coordinate2 != null)
                {
                    int totalSteps = coordinate.Index + coordinate2.Index;

                    matches.Add(new Tuple<Point, Point>(coordinate, coordinate2));
                }
                    
            }

            var sortedMatches = matches.OrderBy(m => m.Item1.Index + m.Item2.Index).First();

            closesCross = 0;
            return closesCross;

        }
    }
}

