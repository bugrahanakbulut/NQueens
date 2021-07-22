using System;
using System.Collections.Generic;
using System.Text;
using NQueens.Utils;

namespace NQueens
{
    public class NQueens
    {
        private int _gridSize;
        
        private char[][] _grid;

        private char _queen = 'Q';
        private char _emptyGrid = 'X';
        public NQueens(int n)
        {
            _gridSize = n;
            
            InitGrid();
            SolveNQueens(0);
            PrintGrid();
        }

        private void InitGrid()
        {
            _grid = new char[_gridSize][];

            for (int i = 0; i < _gridSize; i++)
            {
                _grid[i] = new char[_gridSize];
                _grid[i].Fill(_emptyGrid);
            }
        }

        private bool SolveNQueens(int col)
        {
            if (col >= _gridSize)
            {
                return true;
            }

            for (int row = 0; row < _gridSize; row++)
            {
                if (IsSafe(row, col))
                {
                    PlaceQueen(row, col);

                    if (SolveNQueens(col + 1))
                    {
                        return true;
                    }

                    RemoveQueen(row, col);
                }
            }

            return false;
        }

        private void PlaceQueen(int i, int j)
        {
            _grid[i][j] = _queen;
        }

        private void RemoveQueen(int i, int j)
        {
            _grid[i][j] = _emptyGrid;
        }

        private bool IsSafe(int row, int col)
        {
            int i = 0, j = 0;
            
            for (i = 0; i < _gridSize; i++)
            {
                if (_grid[row][i] == _queen || _grid[i][col] == _queen)
                {
                    return false;
                }
            }

            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (_grid[i][j] == _queen)
                {
                    return false;
                }
            }
            
            for (i = row, j = col; i < _gridSize && j >= 0; i++, j--)
            {
                if (_grid[i][j] == _queen)
                {
                    return false;
                }
            }
            
            return true;
        }

        private void PrintGrid()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    stringBuilder.Append(_grid[i][j] + " ");
                }

                stringBuilder.Append("\n");
            }
            
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}