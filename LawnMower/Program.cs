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
            MowerInput mi = new MowerInput();
            List<string> moverinput = new List<string>();
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Files\\Chandra.txt");
                string gridSize = sr.ReadLine();
                string input = sr.ReadLine();

                while (!string.IsNullOrEmpty(input))
                {
                    moverinput.Add(input);
                    input = sr.ReadLine();
                }

                if (moverinput.Count > 0)
                {
                    List<MowerInput> allParsedInputs = new List<MowerInput>();
                    for (int i = 0; i < moverinput.Count; i++)
                    {
                        var test = mi.ParseMowerInput(moverinput[i], moverinput[i + 1], gridSize);
                        allParsedInputs.Add(test);
                        i += 1;
                    }

                    foreach (var parsedInput in allParsedInputs)
                    {
                        Console.WriteLine($"GridCoordinates:({parsedInput.GridX}, {parsedInput.GridY}) Coordinates:({parsedInput.X}, {parsedInput.Y}) Direction: {parsedInput.Direction} Commands: {parsedInput.Commands[0]} {parsedInput.Commands[1]} {parsedInput.Commands[2]} {parsedInput.Commands[3]}");

                    }
                    Console.ReadLine();
                }
                else { throw new ArgumentException("No input line detected"); }
                //close the file
                sr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
                Console.ReadLine();
            }

         }
    }
}
