using SudokuSolver.Interface;

namespace SudokuSolver
{
    public class SudokuPrinter : ISudokuPrinter
    {
        public void Print(Sudoku result)
        {
        
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(result.Board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}