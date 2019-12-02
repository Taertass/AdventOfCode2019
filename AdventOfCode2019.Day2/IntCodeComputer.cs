namespace AdventOfCode2019.Day2
{
    public class IntCodeComputer
    {
        public int[] Memory { get; private set; }

        private int _instructionPointer = 0;

        public void LoadIntoMemory(int[] intCodeProgram)
        {
            Memory = new int[intCodeProgram.Length];
            intCodeProgram.CopyTo(Memory, 0);
        }

        public void Run()
        {
            while (true)
            {
                Opcode upCode = (Opcode)Memory[_instructionPointer];

                if(upCode == Opcode.Halt)
                {
                    break;
                }

                int parameter1 = Memory[_instructionPointer + 1];
                int parameter2 = Memory[_instructionPointer + 2];
                int parameter3 = Memory[_instructionPointer + 3];

                int number1 = Memory[parameter1];
                int number2 = Memory[parameter2];

                switch (upCode)
                {
                    case Opcode.Add:
                        Memory[parameter3] = number1 + number2;
                        break;
                    case Opcode.Multiply:
                        Memory[parameter3] = number1 * number2;
                        break;
                }

                _instructionPointer += 4;
            }
        }

        private enum Opcode
        {
            Add = 1,
            Multiply = 2,
            Halt = 99,
        }
    }
}
