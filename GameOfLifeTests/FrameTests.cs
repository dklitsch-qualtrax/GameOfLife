using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife;

namespace GameOfLifeTests
{
    [TestClass]
    public class FrameTests
    {
        [TestMethod]
        public void UpdateStatusUnderpopulationKillsTile()
        {
            var testFrame = new Frame(
                new Tile() { Alive = true },
                new List<Tile>()
                );

            Assert.IsFalse(testFrame.UpdateTargetTileStatus().Alive);
        }

        [TestMethod]
        public void UpdateStatusOverpopulationKillsTile()
        {
            var testFrame = new Frame(
                new Tile() { Alive = true },
                new List<Tile>()
                    {
                        new Tile() { Alive = true },
                        new Tile() { Alive = true },
                        new Tile() { Alive = true },
                        new Tile() { Alive = true }
                    }
                );

            Assert.IsFalse(testFrame.UpdateTargetTileStatus().Alive);
        }

        [TestMethod]
        public void UpdateStatusTwoNeighborsDoesNotKillTarget()
        {
            var testFrame = new Frame(
                new Tile() { Alive = true },
                new List<Tile>()
                    {
                        new Tile() { Alive = true },
                        new Tile() { Alive = true },
                    }
                );

            Assert.IsTrue(testFrame.UpdateTargetTileStatus().Alive);
        }

        [TestMethod]
        public void UpdateStatusThreeNeighborsDoesNotKillTarget()
        {
            var testFrame = new Frame(
                new Tile() { Alive = true },
                new List<Tile>()
                    {
                        new Tile() { Alive = true },
                        new Tile() { Alive = true },
                        new Tile() { Alive = true }
                    }
                );

            Assert.IsTrue(testFrame.UpdateTargetTileStatus().Alive);
        }

        [TestMethod]
        public void UpdateStatusThreeNeighborsComesAlive()
        {
            var testFrame = new Frame(
                new Tile() { Alive = false },
                new List<Tile>()
                    {
                        new Tile() { Alive = true },
                        new Tile() { Alive = true },
                        new Tile() { Alive = true }
                    }
                );

            Assert.IsTrue(testFrame.UpdateTargetTileStatus().Alive);
        }

        [TestMethod]
        public void UpdateStatusUnderpopulatedDeadCellStaysDead()
        {
            var testFrame = new Frame(
                new Tile() { Alive = false },
                new List<Tile>()
                    {
                        new Tile() { Alive = true },
                    }
                );

            Assert.IsFalse(testFrame.UpdateTargetTileStatus().Alive);
        }
    }
}
