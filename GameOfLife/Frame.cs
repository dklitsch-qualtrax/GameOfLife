using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Frame
    {
        public Frame(Board board, int xLocation, int yLocation)
        {
            this.Target = board.tiles[xLocation][yLocation];
            this.Neighbors = board.GetNeighboringSquares(xLocation, yLocation);
        }

        public Frame(Tile target, List<Tile> neighbors)
        {
            this.Target = target;
            this.Neighbors = neighbors;
        }

        public Tile Target { get; set; }
        public List<Tile> Neighbors { get; set;  }

        public void UpdateTargetTileStatus()
        {
            var livingNeighbors = Neighbors.Select(x => x.Alive).Count();

            if (Target.Alive)
            {
                if (livingNeighbors < 2 || livingNeighbors > 3)
                    Target.Alive = false;
            }
            else
            {
                if (livingNeighbors == 3)
                    Target.Alive = true; 
            }
            
        }

    }
}
