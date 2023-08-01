using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Sudoku
    {
        public int[,] Board { get; set; }

        public Sudoku(int[,] board)
        {
            Board = board;
        }
    }
}