using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2019.Day2
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
            string input = "1,9,10,3,2,3,11,0,99,30,40,50";
            int[] intCode = input.Split(",").Select(i => int.Parse(i)).ToArray();

            IntCodeComputer _intCodeComputer = new IntCodeComputer();
            _intCodeComputer.LoadIntoMemory(intCode);
            _intCodeComputer.Run();

            int[] result = _intCodeComputer.Memory;

            Assert.Equal("3500,9,10,70,2,3,11,0,99,30,40,50", string.Join(",", result));
        }

        [Fact]
        public void Test2()
        {
            string input = "1,0,0,0,99";
            int[] intCode = input.Split(",").Select(i => int.Parse(i)).ToArray();

            IntCodeComputer _intCodeComputer = new IntCodeComputer();
            _intCodeComputer.LoadIntoMemory(intCode);
            _intCodeComputer.Run();

            int[] result = _intCodeComputer.Memory;

            Assert.Equal("2,0,0,0,99", string.Join(",", result));
        }

        [Fact]
        public void Test3()
        {
            string input = "2,3,0,3,99";
            int[] intCode = input.Split(",").Select(i => int.Parse(i)).ToArray();

            IntCodeComputer _intCodeComputer = new IntCodeComputer();
            _intCodeComputer.LoadIntoMemory(intCode);
            _intCodeComputer.Run();

            int[] result = _intCodeComputer.Memory;

            Assert.Equal("2,3,0,6,99", string.Join(",", result));
        }

        [Fact]
        public void Test4()
        {
            string input = "2,4,4,5,99,0";
            int[] intCode = input.Split(",").Select(i => int.Parse(i)).ToArray();

            IntCodeComputer _intCodeComputer = new IntCodeComputer();
            _intCodeComputer.LoadIntoMemory(intCode);
            _intCodeComputer.Run();

            int[] result = _intCodeComputer.Memory;

            Assert.Equal("2,4,4,5,99,9801", string.Join(",", result));
        }

        [Fact]
        public void Test5()
        {
            string input = "1,1,1,4,99,5,6,0,99";
            int[] intCode = input.Split(",").Select(i => int.Parse(i)).ToArray();

            IntCodeComputer _intCodeComputer = new IntCodeComputer();
            _intCodeComputer.LoadIntoMemory(intCode);
            _intCodeComputer.Run();

            int[] result = _intCodeComputer.Memory;

            Assert.Equal("30,1,1,4,2,5,6,0,99", string.Join(",", result));
        }

        [Fact]
        public void _Solve2()
        {
            int[] intCode = File.ReadAllText("Input.txt").Split(",").Select(i => int.Parse(i)).ToArray();

            int foundVal1 = -1;
            int foundVal2 = -1;

            for (int val1 = 1; val1 < 100; val1++)
            {
                for (int val2 = 1; val2 < 100; val2++)
                {
                    intCode[1] = val1;
                    intCode[2] = val2;

                    IntCodeComputer _intCodeComputer = new IntCodeComputer();
                    _intCodeComputer.LoadIntoMemory(intCode);
                    _intCodeComputer.Run();

                    int[] result = _intCodeComputer.Memory;

                    if(result[0] == 19690720)
                    {
                        foundVal1 = val1;
                        foundVal2 = val2;
                        break;
                    }
                        
                }

                if(foundVal1 > -1 && foundVal2 > -1)
                {
                    break;
                }
            }

            _output.WriteLine($"foundVal1 {foundVal1}, foundVal2 {foundVal2}");


        }

        [Fact]
        public void _Solve1()
        {
            int[] intCode = File.ReadAllText("Input.txt").Split(",").Select(i => int.Parse(i)).ToArray();

            intCode[1] = 12;
            intCode[2] = 2;

            IntCodeComputer _intCodeComputer = new IntCodeComputer();
            _intCodeComputer.LoadIntoMemory(intCode);
            _intCodeComputer.Run();

            int[] result = _intCodeComputer.Memory;

            _output.WriteLine($"Resul1: {result[0]}");
        }
    }



}
