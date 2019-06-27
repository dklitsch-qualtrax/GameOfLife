using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Board
    {
        public Board(int width, int height)
        {
            this.tiles = new List<List<Tile>>();
            this.Width = width;
            this.Height = height;

            for (var columnIndex = 0; columnIndex <= height; columnIndex++)
            {
                for (var rowIndex = 0; rowIndex < width; columnIndex++)
                {
                    tiles[columnIndex][rowIndex] = new Tile { Alive = RandomBool() };
                }
            }
        }

        public Board(List<List<Tile>> filledSpacesOnBoard)
        {
            this.tiles = filledSpacesOnBoard;
        }

        public List<List<Tile>> tiles;

        int Width { get; set; }
        int Height { get; set; }
        private static bool RandomBool()
        {
            return new Random().NextDouble() > 0.5;
        }

        private List<(int xLocation, int yLocation)> neighborsCoordinates = new List<(int xLocation, int yLocation)>();

        private void AddCoordinate(int xLocation, int yLocation)
        {
            if (xLocation > -1 && yLocation > -1)
                neighborsCoordinates.Add((xLocation, yLocation));
        }

        private void AddNeighborCoordinate(int targetXLocation, int targetYLocation)
        {
            AddCoordinate(targetXLocation - 1, targetYLocation - 1);
            AddCoordinate(targetXLocation, targetYLocation - 1);
            AddCoordinate(targetXLocation + 1, targetYLocation - 1);
            AddCoordinate(targetXLocation - 1, targetYLocation);
            AddCoordinate(targetXLocation + 1, targetYLocation);
            AddCoordinate(targetXLocation - 1, targetYLocation + 1);
            AddCoordinate(targetXLocation, targetYLocation + 1);
            AddCoordinate(targetXLocation + 1, targetYLocation + 1);
        }

        public List<Tile> GetNeighboringSquares(int xLocation, int yLocation)
        {
            var neighboringSquares = new List<Tile>();

            foreach (var coordinate in neighborsCoordinates)
                neighboringSquares.Add(tiles[coordinate.xLocation][coordinate.yLocation]);

            return neighboringSquares;
        }

        public void ProgressToNextGeneration()
        {
            for (var columnIndex = 0; columnIndex <= Height; columnIndex++)
            {
                for (var rowIndex = 0; rowIndex <= Width; rowIndex++)
                {
                    new Frame(this, rowIndex, columnIndex).UpdateStatus();
                }
            }
        }

        public bool Matches(Board boardToCompare)
        {
            if (this.Height != boardToCompare.Height || this.Width != boardToCompare.Width)
                throw new Exception("Cannot compare different sized boards.");

            for (var columnIndex = 0; columnIndex <= Width; columnIndex++)
            {
                for (var rowIndex = 0; rowIndex < Height; columnIndex++)
                {
                    var tileOnThisBoard = this.tiles[columnIndex][rowIndex];
                    var tileToCompare = boardToCompare.tiles[columnIndex][rowIndex];
                    if (!tileOnThisBoard.Matches(tileToCompare))
                        return false;
                }
            }

            return true;
        }
    }
}