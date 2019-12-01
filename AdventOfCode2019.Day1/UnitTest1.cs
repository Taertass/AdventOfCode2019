using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2019.Day1
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;
        private readonly Solver _solver;
        public UnitTest1(ITestOutputHelper output)
        {
            _solver = new Solver();
            _output = output;
        }

        [Fact]
        public void Test1()
        {
            var fuelRequired = _solver.CalulateFuelLoad(12);

            Assert.Equal(2, fuelRequired);
        }

        [Fact]
        public void Test2()
        {
            var fuelRequired = _solver.CalulateFuelLoad(14);

            Assert.Equal(2, fuelRequired);
        }

        [Fact]
        public void Test3()
        {
            var fuelRequired = _solver.CalulateFuelLoad(1969);

            Assert.Equal(654, fuelRequired);
        }

        [Fact]
        public void Test4()
        {
            var fuelRequired = _solver.CalulateFuelLoad(100756);

            Assert.Equal(33583, fuelRequired);
        }

        [Fact]
        public void _Solve1()
        {
            var input = File.ReadAllLines("Input.txt").Select(i => int.Parse(i));

            Solver solver = new Solver();
            int totalFuleLoad = solver.CalulateFuelLoad(input);

            _output.WriteLine($"Total fuel load needed is: {totalFuleLoad}");
        }

        [Fact]
        public void Test5()
        {
            var fuelRequired = _solver.CalulateFuelLoadWithMass(14);

            Assert.Equal(2, fuelRequired);
        }

        [Fact]
        public void Test6()
        {
            var fuelRequired = _solver.CalulateFuelLoadWithMass(1969);

            Assert.Equal(966, fuelRequired);
        }

        [Fact]
        public void Test7()
        {
            var fuelRequired = _solver.CalulateFuelLoadWithMass(100756);

            Assert.Equal(50346, fuelRequired);
        }



        [Fact]
        public void _Solve2()
        {
            var input = File.ReadAllLines("Input.txt").Select(i => int.Parse(i));

            Solver solver = new Solver();
            int totalFuleLoad = solver.CalulateFuelLoadWithMass(input);

            _output.WriteLine($"Total fuel load needed with mass of fule included is: {totalFuleLoad}");
        }

        //var input = await File.ReadAllLinesAsync("Input.txt");

        //Divide by 3, round down, - 2
    }
}
