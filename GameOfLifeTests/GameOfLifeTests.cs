using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;
using System.Collections.Generic;

namespace GameOfLifeTests
{
    [TestClass]
    public class GameOfLifeTests
    {

        private List<Tile> EmptyRow(int columns)
        {
            var row = new List<Tile>();
            for (var rowIndex = 0; rowIndex <= columns; rowIndex++)
                row.Add(new Tile() { Alive = false });
            return row;
        }

        private void FillRowXTimes(List<Tile> row, int numberOfTimes, bool tileIsAlive = false)
        {
            for (var rowIndex = 0; rowIndex <= numberOfTimes; rowIndex++)
                row.Add(new Tile() { Alive = tileIsAlive });
        }

        [TestMethod]
        public void BasicGame()
        {
            var inputTiles = new List<List<Tile>>
            {
                EmptyRow(8)
            };

            var filledRow = new List<Tile>();
            FillRowXTimes(filledRow, 4);
            filledRow.Add(new Tile() { Alive = true });
            FillRowXTimes(filledRow, 3);
            inputTiles.Add(filledRow);

            filledRow = new List<Tile>();
            FillRowXTimes(filledRow, 3);
            FillRowXTimes(filledRow, 2, true);
            FillRowXTimes(filledRow, 3);
            inputTiles.Add(filledRow);

            inputTiles.Add(EmptyRow(8));
            var inputBoard = new Board(inputTiles);

            var expectedTiles = new List<List<Tile>>
            {
                EmptyRow(8)
            };

            filledRow = new List<Tile>();
            FillRowXTimes(filledRow, 3);
            FillRowXTimes(filledRow, 2, true);
            FillRowXTimes(filledRow, 3);
            expectedTiles.Add(filledRow);

            filledRow = new List<Tile>();
            FillRowXTimes(filledRow, 3);
            FillRowXTimes(filledRow, 2, true);
            FillRowXTimes(filledRow, 3);
            expectedTiles.Add(filledRow);

            expectedTiles.Add(EmptyRow(8));
            var expectedBoard = new Board(expectedTiles);

            inputBoard.ProgressToNextGeneration();

            Assert.IsTrue(inputBoard.Matches(expectedBoard));
        }
    }
}
