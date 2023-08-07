using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuSolver.Interface
{
    public interface ISudokuParser
    {
        public Sudoku Parser(string[] data);
        
    }
}