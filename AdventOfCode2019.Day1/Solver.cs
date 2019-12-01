using System;
using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode2019.Day1
{
    public class Solver
    {
        public int CalulateFuelLoad(int mass)
        {
            return Math.Max(0, (mass / 3) - 2);
        }

        public int CalulateFuelLoad(IEnumerable<int> masses)
        {
            int totalFuelLoad = 0;
            foreach (var mass in masses)
            {
                totalFuelLoad += CalulateFuelLoad(mass);
            }
            return totalFuelLoad;
        }

        public int CalulateFuelLoadWithMass(int mass)
        {
            int totalMass = mass;
            int totalRequiredFuelLoad = 0;

            int requiredFuelLoad = totalMass;
            do
            {
                requiredFuelLoad = CalulateFuelLoad(requiredFuelLoad);
                totalMass += requiredFuelLoad;
                totalRequiredFuelLoad += requiredFuelLoad;

            } while (requiredFuelLoad > 0);

            return totalRequiredFuelLoad;
        }

        public int CalulateFuelLoadWithMass(IEnumerable<int> masses)
        {
            int totalFuelLoad = 0;
            foreach (var mass in masses)
            {
                totalFuelLoad += CalulateFuelLoad(mass);
            }
            return totalFuelLoad;
        }
    }
}
