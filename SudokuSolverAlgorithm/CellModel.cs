using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolverAlgorithm
{
    [Serializable]
    public class CellModel
    {
        public int value { get; set; }
        public int row { get; set; }
        public int column { get; set; }
        public int square { get; set; }
        public CellModel PreviousCell { get; set; }
    }
}
