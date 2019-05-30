using GameOfLife.Models;

namespace GameOfLife.Services
{
    public interface INeighbourCounter
    {
        int[,] CountNeighbours(Cell[,] cells);
        bool HasLiveCell(int row, int col, Cell[,] cells);
    }

    public class NeighbourCounter : INeighbourCounter
    {
        private const int RowIndex = 0;
        private const int ColIndex = 1;

        public int[,] CountNeighbours(Cell[,] cells)
        {
            var cellCounts = new int[cells.GetLength(RowIndex), cells.GetLength(ColIndex)];

            for (var row = 0; row < cells.GetLength(RowIndex); row++)
            {
                for (var col = 0; col < cells.GetLength(ColIndex); col++)
                {
                    var count = 0;
                    if (HasLiveCell(row - 1, col - 1, cells)) count++;
                    if (HasLiveCell(row, col - 1, cells)) count++;
                    if (HasLiveCell(row + 1, col - 1, cells)) count++;
                    if (HasLiveCell(row - 1, col, cells)) count++;
                    if (HasLiveCell(row + 1, col, cells)) count++;
                    if (HasLiveCell(row - 1, col + 1, cells)) count++;
                    if (HasLiveCell(row, col + 1, cells)) count++;
                    if (HasLiveCell(row + 1, col + 1, cells)) count++;

                    cellCounts[row, col] = count;
                }
            }

            return cellCounts;
        }

        public bool HasLiveCell(int row, int col, Cell[,] cells)
        {
            if (row < 0) return false;
            if (col < 0) return false;
            if (cells.GetLength(RowIndex) <= row) return false;
            if (cells.GetLength(ColIndex) <= col) return false;

            return cells[row, col].Alive;
        }
    }
}
