using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower
{
    class LawnDimension
    {
        public int GridX { get; set; }
        public int GridY { get; set; }

        public static LawnDimension gridDimension(string gridSize)
        {
            LawnDimension lawnDimension = new LawnDimension();
            int temp;
            string[] gridcoordinates = gridSize.Split(' ');


            if (int.TryParse(gridcoordinates[0], out temp))
            {
                lawnDimension.GridX = temp;
            }
            else { throw new ArgumentException("Not an integer"); }

            if (int.TryParse(gridcoordinates[1], out temp))
            {
                lawnDimension.GridY = temp;
            }
            else { throw new ArgumentException("Not an integer"); }

            return lawnDimension;
        }
    }
}
