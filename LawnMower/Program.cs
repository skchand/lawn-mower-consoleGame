using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace LawnMower
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleTitle();
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

            if (moverinput.Count > 0)
            {
                List<MowerInput> mowers = new List<MowerInput>();
                for (int i = 0; i < moverinput.Count; i++)
                {
                    try
                    {
                        var eachMower = MowerInput.ParseMowerInput(moverinput[i], moverinput[i + 1]);
                        mowers.Add(eachMower);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                        throw e;

                    }

                    i += 1;
                }

                Engine engine = new Engine(girdsize);
                foreach (var mower in mowers)
                {
                    try
                    {
                        Console.WriteLine($"Initial Position: ({mower.X}, {mower.Y}) Direction:{mower.Direction}");
                        var mowerOutput = engine.ProcessCommands(mower);
                        Console.WriteLine($"New Position: ({mowerOutput.X}, {mowerOutput.Y}) Direction:{mowerOutput.Direction}");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                        throw e;

                    }
                }
                Console.ReadLine();
            }
            else { throw new ArgumentException("No input line detected"); }
            sr.Close();
            Console.ReadLine();
        }
        private static void ConsoleTitle()
        {
            string Progresbar = "This is Lawn Mower Console Game";
            var title = "";
          
                for (int i = 0; i < Progresbar.Length; i++)
                {
                    title += Progresbar[i];
                    Console.Title = title;
                    Thread.Sleep(10);
                }
                title = "";
            }
        
    }
   
   
}
