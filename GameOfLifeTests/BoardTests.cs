using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;
using System.Collections.Generic;

namespace GameOfLifeTests
{
    [TestClass]
    public class BoardTests
    {

        private List<Tile> EmptyRow(int columns)
        {
            var row = new List<Tile>();
            for (var rowIndex = 1; rowIndex <= columns; rowIndex++)
                row.Add(new Tile() { Alive = false });
            return row;
        }

        private List<Tile> FilledRow(int columns)
        {
            var row = new List<Tile>();
            for (var rowIndex = 1; rowIndex <= columns; rowIndex++)
                row.Add(new Tile() { Alive = true });
            return row;
        }

        private void FillRowXTimes(List<Tile> row, int numberOfTimes, bool tileIsAlive = false)
        {
            for (var rowIndex = 1; rowIndex <= numberOfTimes; rowIndex++)
                row.Add(new Tile() { Alive = tileIsAlive });
        }

        [TestMethod]
        public void ProgressToNextGenerationReturnsCorrectBoard()
        {
            var inputTiles = new List<List<Tile>>
            {
                EmptyRow(4)
            };

            var filledRow = new List<Tile>();
            FillRowXTimes(filledRow, 2);
            filledRow.Add(new Tile() { Alive = true });
            FillRowXTimes(filledRow, 1);
            inputTiles.Add(filledRow);

            filledRow = new List<Tile>();
            FillRowXTimes(filledRow, 1);
            FillRowXTimes(filledRow, 2, true);
            FillRowXTimes(filledRow, 1);
            inputTiles.Add(filledRow);

            inputTiles.Add(EmptyRow(4));
            var inputBoard = new Board(inputTiles);

            var expectedTiles = new List<List<Tile>>
            {
                EmptyRow(4)
            };

            filledRow = new List<Tile>();
            FillRowXTimes(filledRow, 1);
            FillRowXTimes(filledRow, 2, true);
            FillRowXTimes(filledRow, 1);
            expectedTiles.Add(filledRow);

            filledRow = new List<Tile>();
            FillRowXTimes(filledRow, 1);
            FillRowXTimes(filledRow, 2, true);
            FillRowXTimes(filledRow, 1);
            expectedTiles.Add(filledRow);

            expectedTiles.Add(EmptyRow(4));
            var expectedBoard = new Board(expectedTiles);

            Assert.IsTrue(inputBoard.GetNextGenerationBoard().Matches(expectedBoard));
        }

        [TestMethod]
        public void GetNeighboringSquaresReturns8SquaresIfSurrounded()
        {
            var inputBoard = new Board(new List<List<Tile>>()
                {
                    FilledRow(3),
                    FilledRow(3),
                    FilledRow(3)
                });

            var result = inputBoard.GetNeighboringSquares(1, 1);

            Assert.AreEqual(8, result.Count);
        }

        [TestMethod]
        public void GetNeighboringSquaresReturns3SquaresIfAtTheTopOfTheBoard()
        {
            var inputBoard = new Board(new List<List<Tile>>()
                {
                    FilledRow(3),
                    FilledRow(3),
                    FilledRow(3)
                });

            var result = inputBoard.GetNeighboringSquares(2, 2);

            Assert.AreEqual(3, result.Count);
        }
    }
}
