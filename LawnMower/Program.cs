using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LawnMower
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> moverinput = new List<string>();
           
            StreamReader sr = new StreamReader("C:\\Files\\Chandra.txt");
            string gridSize = sr.ReadLine();
            string input = sr.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                moverinput.Add(input);
                input = sr.ReadLine();
            }
            var girdsize = LawnDimension.gridDimension(gridSize);
            Console.WriteLine($"GridCoordinates:({girdsize.GridX}, {girdsize.GridY})");
            if (moverinput.Count > 0)
            {
                List<MowerInput> allParsedInputs = new List<MowerInput>();
                for (int i = 0; i < moverinput.Count; i++)
                {
                    try
                    {
                        var test = MowerInput.ParseMowerInput(moverinput[i], moverinput[i + 1]);
                        allParsedInputs.Add(test);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                        Console.ReadLine();
                        Environment.Exit(-1);
                    }

                    i += 1;
                }

                foreach (var parsedInput in allParsedInputs)
                {
                    Console.WriteLine($"Coordinates:({parsedInput.X}, {parsedInput.Y}) Direction: {parsedInput.Direction} Commands: {parsedInput.Commands[0]} {parsedInput.Commands[1]} {parsedInput.Commands[2]} {parsedInput.Commands[3]}");
                }
                Console.ReadLine();
            }
            else { throw new ArgumentException("No input line detected"); }
            sr.Close();
            Console.ReadLine();
        }
    }
}
