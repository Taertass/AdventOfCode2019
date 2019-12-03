using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2019.Day3
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;
        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1()
        {
            string input = @"R75,D30,R83,U83,L12,D49,R71,U7,L72
U62,R66,U55,R34,D71,R55,D58,R83";
            
            Solver _intCodeComputer = new Solver();
            int distance = _intCodeComputer.Solve1(input);


            Assert.Equal(159, distance);
        }

        [Fact]
        public void Test2()
        {
            string input = @"R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51
U98,R91,D20,R16,D67,R40,U7,R15,U6,R7";

            Solver _intCodeComputer = new Solver();
            int distance = _intCodeComputer.Solve1(input);


            Assert.Equal(159, distance);
        }
    }



}
