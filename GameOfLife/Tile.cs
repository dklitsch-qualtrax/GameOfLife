using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Tile
    {
        public bool Alive { get; set; }

        public bool Matches(Tile tileToCompare)
        {
            return this.Alive == tileToCompare.Alive;
        }
    }
}
