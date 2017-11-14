using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower
{
    public class LawnDimension
    {
        public int GridX { get; set; }
        public int GridY { get; set; }

        public static LawnDimension gridDimension(string gridSize)
        {
            LawnDimension girdSize = new LawnDimension();
            int temp;
            string[] gridcoordinates = gridSize.Split(' ');


            if (int.TryParse(gridcoordinates[0], out temp))
            {
                girdSize.GridX = temp;
            }
            else { throw new ArgumentException("Not an integer"); }

            if (int.TryParse(gridcoordinates[1], out temp))
            {
                girdSize.GridY = temp;
            }
            else { throw new ArgumentException("Not an integer"); }

            return girdSize;
        }
    }
}
