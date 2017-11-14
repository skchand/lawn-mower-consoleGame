using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LawnMower
{
    public class Program
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

                Engine eng = new Engine(girdsize);
                foreach (var mower in mowers)
                {
                    try
                    {
                        eng.ProcessCommands(mower);

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

    }
}
