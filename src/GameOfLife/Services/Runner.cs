using GameOfLife.Models;

namespace GameOfLife.Services
{
    public interface IRunner
    {
        Cell[,] Run(Cell[,] providedCells);
    }

    public class Runner : IRunner
    {
        private readonly INeighbourCounter _neighbourCounter;

        private const int RowIndex = 0;
        private const int ColIndex = 1;

        public Runner(INeighbourCounter neighbourCounter)
        {
            _neighbourCounter = neighbourCounter;
        }

        public Cell[,] Run(Cell[,] providedCells)
        {
            var neighbourCounterGrid = _neighbourCounter.CountNeighbours(providedCells);

            for (var row = 0; row < providedCells.GetLength(RowIndex); row++)
            {
                for (var col = 0; col < providedCells.GetLength(ColIndex); col++)
                {
                    var neighbourCount = neighbourCounterGrid[row, col];
                    var cell = providedCells[row, col];
                    CheckForUnderpopulation(neighbourCount, ref cell);
                    CheckForOvercrowding(neighbourCount, ref cell);
                    CheckForMating(neighbourCount, ref cell);
                }
            }

            return providedCells;
        }

        private static void CheckForUnderpopulation(int neighbourCount, ref Cell cell)
        {
            if (neighbourCount < 2)
            {
                cell.Alive = false;
            }
        }

        private static void CheckForOvercrowding(int neighbourCount, ref Cell cell)
        {
            if (neighbourCount > 3)
            {
                cell.Alive = false;
            }
        }

        private static void CheckForMating(int neighbourCount, ref Cell cell)
        {
            if (neighbourCount == 3)
            {
                cell.Alive = true;
            }
        }
    }
}
