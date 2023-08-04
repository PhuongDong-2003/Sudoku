using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class InputLoader
    {
        internal string[] Load(string v)
        {          
           return File.ReadAllLines(v);
            
        }
    }
}