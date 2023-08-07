using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SudokuSolver.Interface;

namespace SudokuSolver
{
    public class InputLoader : IInputLoader 
    {
       public string[] Load(string v)
        {          
           return File.ReadAllLines(v);
            
        }
    }
}