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
            for (var rowIndex = 0; rowIndex <= numberOfTimes; rowIndex++)
                row.Add(new Tile() { Alive = tileIsAlive });
        }

        [TestMethod]
        public void ProgressToNextGenerationReturnsCorrectBoard()
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
