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

        public int LivingNeighborsCount => Neighbors.Where(x => x.Alive).Count();

        public bool PopulationIsSustainable => (LivingNeighborsCount == 2 || LivingNeighborsCount == 3);

        public bool PopulationIncreasedDueToMigration => (LivingNeighborsCount == 3);

        public void UpdateTargetTileStatus()
        {
            if (Target.Alive)
                Target.Alive = PopulationIsSustainable;
            else
                Target.Alive = PopulationIncreasedDueToMigration; 
        }

    }
}
