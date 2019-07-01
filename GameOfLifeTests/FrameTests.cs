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
    class FrameTests
    {
        [TestMethod]
        public void UpdateStatusUnderpopulationKillsTile()
        {
            var testFrame = new Frame(
                new Tile() { Alive = true },
                new List<Tile>()
                );

            testFrame.UpdateTargetTileStatus();

            Assert.IsFalse(testFrame.Target.Alive);
        }
    }
}
