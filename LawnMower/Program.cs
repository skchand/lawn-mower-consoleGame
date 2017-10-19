﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower
{
    class Program
    {
        static void Main(string[] args)
        {
            MowerInput mi = new MowerInput();

            string gridSize = Console.ReadLine();
          

            List<string> moverinput = new List<string>();

            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                moverinput.Add(input);
                input = Console.ReadLine();
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
                //allParsedInputs

                //foreach (var parsedInput in allParsedInputs)
                //{
                //    Console.WriteLine($"GridCoordinates:({parsedInput.GridX}, {parsedInput.GridY}) Coordinates:({parsedInput.X}, {parsedInput.Y}) Direction: {parsedInput.Direction} Commands: {parsedInput.Commands[0]} {parsedInput.Commands[1]} {parsedInput.Commands[2]} {parsedInput.Commands[3]}");

                //}
                //Console.ReadLine();
            }
        }
    }
}
