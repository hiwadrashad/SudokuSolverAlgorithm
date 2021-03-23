using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolverAlgorithm
{
    class Program
    {
        //public SudokuModel SolveSudoku(SudokuModel model)
        //{
        //    for (int i = 0; i < 9; i++)
        //    {
        //        for (int a = 0; a < 9; a++)
        //        {
        //            if (model.Sudoku[i][a].value == 0)
        //            {
        //                var item = model.Sudoku[i][a];
        //            }
        //        }
        //    }
        //    return new SudokuModel();
        //}

        //public CellModel SolveCell(CellModel cellmodel, SudokuModel sudokumodel)
        //{
        //    var row = sudokumodel.Sudoku[cellmodel.row];
        //    List<CellModel> columns = new List<CellModel>();
        //    for (int i = 0; i < 9; i++)
        //    {
        //       columns.Add(sudokumodel.Sudoku[i][cellmodel.column]);
        //    }

        //    List<CellModel> square = new List<CellModel>();
        //    for (int x = 0; x< 9; x++ )
        //    {

        //    }
        //}
        public static void solveSudoku(char[,] board)
        {
            if (board == null || board.Length == 0)
                return;
            solve(board);
        }
        private static bool solve(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '.')
                    {
                        for (char c = '1'; c <= '9'; c++)
                        {
                            if (isValid(board, i, j, c))
                            {
                                board[i, j] = c;

                                if (solve(board))
                                    return true;
                                else
                                    board[i, j] = '.';
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
        private static bool isValid(char[,] board, int row, int col, char c)
        {
            for (int i = 0; i < 9; i++)
            {
                //check row  
                if (board[i, col] != '.' && board[i, col] == c)
                    return false;
                //check column  
                if (board[row, i] != '.' && board[row, i] == c)
                    return false;
                //check 3*3 block  
                if (board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] != '.' && board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == c)
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            //var SudokuBoard = new SudokuModel() { Sudoku = new System.Collections.Generic.List<System.Collections.Generic.List<CellModel>>()
            //{
            //    new System.Collections.Generic.List<CellModel>
            //    {
            //        new CellModel { value = 0, column = 0, row = 0, square = 0  } ,
            //        new CellModel { value = 1, column = 1, row = 0, square = 0  },
            //        new CellModel { value = 2, column = 2, row = 0, square = 0  },
            //        new CellModel { value = 3, column = 3, row = 0, square = 0  },
            //        new CellModel { value = 4, column = 4, row = 0, square = 0  },
            //        new CellModel { value = 5, column = 5, row = 0, square = 0  },
            //        new CellModel { value = 6, column = 6, row = 0, square = 0  },
            //        new CellModel { value = 7, column = 7, row = 0, square = 0  },
            //        new CellModel { value = 8, column = 8, row = 0, square = 0  },
            //    },
            //            new System.Collections.Generic.List<CellModel>
            //    {
            //        new CellModel { value = 0, column = 0, row = 1, square = 0  } ,
            //        new CellModel { value = 1, column = 1, row = 1, square = 0  },
            //        new CellModel { value = 2, column = 2, row = 1, square = 0  },
            //        new CellModel { value = 3, column = 3, row = 1, square = 0  },
            //        new CellModel { value = 4, column = 4, row = 1, square = 0  },
            //        new CellModel { value = 5, column = 5, row = 1, square = 0  },
            //        new CellModel { value = 6, column = 6, row = 1, square = 0  },
            //        new CellModel { value = 7, column = 7, row = 1, square = 0  },
            //        new CellModel { value = 8, column = 8, row = 1, square = 0  },
            //    },
            //                         new System.Collections.Generic.List<CellModel>
            //    {
            //        new CellModel { value = 0, column = 0, row = 2, square = 0  } ,
            //        new CellModel { value = 1, column = 1, row = 2, square = 0  },
            //        new CellModel { value = 2, column = 2, row = 2, square = 0  },
            //        new CellModel { value = 3, column = 3, row = 2, square = 0  },
            //        new CellModel { value = 4, column = 4, row = 2, square = 0  },
            //        new CellModel { value = 5, column = 5, row = 2, square = 0  },
            //        new CellModel { value = 6, column = 6, row = 2, square = 0  },
            //        new CellModel { value = 7, column = 7, row = 2, square = 0  },
            //        new CellModel { value = 8, column = 8, row = 2, square = 0  },
            //    },
            //                                      new System.Collections.Generic.List<CellModel>
            //    {
            //        new CellModel { value = 0, column = 0, row = 3, square = 0  } ,
            //        new CellModel { value = 1, column = 1, row = 3, square = 0  },
            //        new CellModel { value = 2, column = 2, row = 3, square = 0  },
            //        new CellModel { value = 3, column = 3, row = 3, square = 0  },
            //        new CellModel { value = 4, column = 4, row = 3, square = 0  },
            //        new CellModel { value = 5, column = 5, row = 3, square = 0  },
            //        new CellModel { value = 6, column = 6, row = 3, square = 0  },
            //        new CellModel { value = 7, column = 7, row = 3, square = 0  },
            //        new CellModel { value = 8, column = 8, row = 3, square = 0  },
            //    },
            //                                                   new System.Collections.Generic.List<CellModel>
            //    {
            //        new CellModel { value = 0, column = 0, row = 4, square = 0  } ,
            //        new CellModel { value = 1, column = 1, row = 4, square = 0  },
            //        new CellModel { value = 2, column = 2, row = 4, square = 0  },
            //        new CellModel { value = 3, column = 3, row = 4, square = 0  },
            //        new CellModel { value = 4, column = 4, row = 4, square = 0  },
            //        new CellModel { value = 5, column = 5, row = 4, square = 0  },
            //        new CellModel { value = 6, column = 6, row = 4, square = 0  },
            //        new CellModel { value = 7, column = 7, row = 4, square = 0  },
            //        new CellModel { value = 8, column = 8, row = 4, square = 0  },
            //    },
            //                                                                new System.Collections.Generic.List<CellModel>
            //    {
            //        new CellModel { value = 0, column = 0, row = 5, square = 0  } ,
            //        new CellModel { value = 1, column = 1, row = 5, square = 0  },
            //        new CellModel { value = 2, column = 2, row = 5, square = 0  },
            //        new CellModel { value = 3, column = 3, row = 5, square = 0  },
            //        new CellModel { value = 4, column = 4, row = 5, square = 0  },
            //        new CellModel { value = 5, column = 5, row = 5, square = 0  },
            //        new CellModel { value = 6, column = 6, row = 5, square = 0  },
            //        new CellModel { value = 7, column = 7, row = 5, square = 0  },
            //        new CellModel { value = 8, column = 8, row = 5, square = 0  },
            //    },
            //                                                                             new System.Collections.Generic.List<CellModel>
            //    {
            //        new CellModel { value = 0, column = 0, row = 6, square = 0  } ,
            //        new CellModel { value = 1, column = 1, row = 6, square = 0  },
            //        new CellModel { value = 2, column = 2, row = 6, square = 0  },
            //        new CellModel { value = 3, column = 3, row = 6, square = 0  },
            //        new CellModel { value = 4, column = 4, row = 6, square = 0  },
            //        new CellModel { value = 5, column = 5, row = 6, square = 0  },
            //        new CellModel { value = 6, column = 6, row = 6, square = 0  },
            //        new CellModel { value = 7, column = 7, row = 6, square = 0  },
            //        new CellModel { value = 8, column = 8, row = 6, square = 0  },
            //    },
            //                                                                                          new System.Collections.Generic.List<CellModel>
            //    {
            //        new CellModel { value = 0, column = 0, row = 7, square = 0  } ,
            //        new CellModel { value = 1, column = 1, row = 7, square = 0  },
            //        new CellModel { value = 2, column = 2, row = 7, square = 0  },
            //        new CellModel { value = 3, column = 3, row = 7, square = 0  },
            //        new CellModel { value = 4, column = 4, row = 7, square = 0  },
            //        new CellModel { value = 5, column = 5, row = 7, square = 0  },
            //        new CellModel { value = 6, column = 6, row = 7, square = 0  },
            //        new CellModel { value = 7, column = 7, row = 7, square = 0  },
            //        new CellModel { value = 8, column = 8, row = 7, square = 0  },
            //    },
            //                                                                                                       new System.Collections.Generic.List<CellModel>
            //    {
            //        new CellModel { value = 0, column = 0, row = 8, square = 0  } ,
            //        new CellModel { value = 1, column = 1, row = 8, square = 0  },
            //        new CellModel { value = 2, column = 2, row = 8, square = 0  },
            //        new CellModel { value = 3, column = 3, row = 8, square = 0  },
            //        new CellModel { value = 4, column = 4, row = 8, square = 0  },
            //        new CellModel { value = 5, column = 5, row = 8, square = 0  },
            //        new CellModel { value = 6, column = 6, row = 8, square = 0  },
            //        new CellModel { value = 7, column = 7, row = 8, square = 0  },
            //        new CellModel { value = 8, column = 8, row = 8, square = 0  },
            //    } }

            //};
            var sudoku = new char[,]
        {
        { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
        { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
        { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
        { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
        { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
        { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
        { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
        { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
        { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
        };
            solveSudoku(sudoku);

            string firstrow = "";
            for (int i = 0; i < 9; i++)
            {
                firstrow = firstrow + " " + sudoku[0, i];
            }
            string secondrow = "";
            for (int i = 0; i < 9; i++)
            {
                secondrow = secondrow + " " + sudoku[1, i];
            }
            string thirdrow = "";
            for (int i = 0; i < 9; i++)
            {
                thirdrow = thirdrow + " " + sudoku[2, i];
            }
            string fourthrow = "";
            for (int i = 0; i < 9; i++)
            {
                fourthrow = fourthrow + " " + sudoku[3, i];
            }
                string fifthrow = "";
            for (int i = 0; i < 9; i++)
            {
                fifthrow = fifthrow + " " + sudoku[4, i];
                }
            string sixthrow = "";
            for (int i = 0; i < 9; i++)
            {
                sixthrow = sixthrow + " " + sudoku[5, i];
            }
                    string seventhrow = "";
            for (int i = 0; i < 9; i++)
            {
                seventhrow = seventhrow + " " + sudoku[6, i];
                    }
            string eightrow = "";
            for (int i = 0; i < 9; i++)
            {
                eightrow = eightrow + " " + sudoku[7, i];
                    }
            string ninthrow = "";
            for (int i = 0; i < 9; i++)
            {
                ninthrow = ninthrow + " " + sudoku[8, i];
                    }
            Console.WriteLine(firstrow);
            Console.WriteLine(secondrow);
            Console.WriteLine(thirdrow);
            Console.WriteLine(fourthrow);
            Console.WriteLine(fifthrow);
            Console.WriteLine(sixthrow);
            Console.WriteLine(seventhrow);
            Console.WriteLine(eightrow);
            Console.WriteLine(ninthrow);

        }
    }
}
