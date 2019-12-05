using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2019.Day4
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
            Assert.True(IsValidPassword(111111));
        }

        [Fact]
        public void Test2()
        {
            Assert.False(IsValidPassword(223450));
        }

        [Fact]
        public void Test3()
        {
            Assert.False(IsValidPassword(123789));
        }

        [Fact]
        public void Test4()
        {
            Assert.False(IsValidPassword(200000));
        }

        [Fact]
        public void Solve1()
        {
            //193651-649729
            int minimum = 193651;
            int maxiumum = 649729;

            List<int> validPasswords = new List<int>();
            for (int i = minimum; i <= maxiumum; i++)
            {
                if (IsValidPassword(i))
                {
                    validPasswords.Add(i);
                }
            }

            _output.WriteLine($"Valid passwords {validPasswords.Count}");
        }

        [Fact]
        public void Test5()
        {
            Assert.True(IsValidPassword2(112233));
        }

        [Fact]
        public void Test6()
        {
            Assert.False(IsValidPassword2(123444));
        }

        [Fact]
        public void Test7()
        {
            Assert.True(IsValidPassword2(111122));
        }

        [Fact]
        public void Solve2()
        {
            //193651-649729
            int minimum = 193651;
            int maxiumum = 649729;

            List<int> validPasswords = new List<int>();
            for (int i = minimum; i <= maxiumum; i++)
            {
                if (IsValidPassword2(i))
                {
                    validPasswords.Add(i);
                }
            }

            _output.WriteLine($"Valid passwords 2 {validPasswords.Count}");
        }

        private bool IsValidPassword(int password)
        {
            int[] splitPassword = ToArray(password);

            //1) More than 6 charaters
            //if (password / 1000000 > 0)
            //    return false;

            //2) Within range

            //4) Increasing
            for (int i = 0; i < splitPassword.Length - 1; i++)
            {
                if (splitPassword.Skip(i + 1).Any(i2 => i2 < splitPassword[i]))
                    return false;
            }

            //3) Are two digits the same
            bool foundDoubles = false;
            for (int i = 0; i < splitPassword.Length - 1; i++)
            {
                if (splitPassword[i] == splitPassword[i + 1])
                {
                    foundDoubles = true;
                    break;
                }
                    
            }

            if (foundDoubles == false)
                return false;

            return true;

        }

        private bool IsValidPassword2(int password)
        {
            int[] splitPassword = ToArray(password);

            //1) More than 6 charaters
            //if (password / 1000000 > 0)
            //    return false;

            //2) Within range

            //4) Increasing
            for (int i = 0; i < splitPassword.Length - 1; i++)
            {
                if (splitPassword.Skip(i + 1).Any(i2 => i2 < splitPassword[i]))
                    return false;
            }

            //3) Are two digits the same
            for (int i = 0; i < splitPassword.Length - 1; i++)
            {
                var grouped = splitPassword.GroupBy(i => i);
                if (grouped.Where(g => g.Count() == 2).Any() == false)
                    return false;
            }

            return true;

        }

        private int[] ToArray(int number)
        {
            List<int> numberSplit = new List<int>();
            do
            {
                numberSplit.Insert(0, number % 10);
                number /= 10;
            } while (number > 0);

            return numberSplit.ToArray();
        }

        //        [Fact]
        //        public void Test2()
        //        {
        //            string input = @"R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51
        //U98,R91,D20,R16,D67,R40,U7,R15,U6,R7";

        //            Solver _intCodeComputer = new Solver();
        //            int distance = _intCodeComputer.Solve1(input);


        //            Assert.Equal(135, distance);
        //        }

        //        [Fact]
        //        public void _Solve1()
        //        {

        //            string input = File.ReadAllText("Input.txt");

        //            Solver _intCodeComputer = new Solver();
        //            int distance = _intCodeComputer.Solve1(input);

        //            _output.WriteLine($"Solve1: {distance}");
        //        }
    }



}
