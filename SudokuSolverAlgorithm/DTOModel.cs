using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolverAlgorithm
{
    public class DTOModel
    {
        public int RandomNumber {get;set;}
        public Dictionary<int, CellModel> PreviousCell { get; set; } = new Dictionary<int, CellModel>();
        public List<int> PreviousChosenNumbers { get; set; } = new List<int>();
    }
}
