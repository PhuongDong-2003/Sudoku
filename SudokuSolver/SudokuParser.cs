using SudokuSolver.Interface;

namespace SudokuSolver
{
    public class SudokuParser : ISudokuParser 
    {
        public Sudoku Parser(string[] data)
        {
             int[,] board = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                string[] numbers = data[i].Split(' ');

                for (int j = 0; j < 9; j++)
                {
                    int number = int.Parse(numbers[j]);
                    board[i, j] = number;
                }
            }
            return new Sudoku(board);
        }
    }
}