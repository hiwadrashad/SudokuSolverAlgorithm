using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolverAlgorithm
{
    class Program
    {
        public SudokuModel SolveSudoku(SudokuModel model)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int a = 0; a < 9; a++)
                {
                    if (model.Sudoku[i][a].value == 0)
                    {
                        var item = model.Sudoku[i][a];
                    }
                }
            }
            return new SudokuModel();
        }

        public CellModel SolveCell(CellModel cellmodel, SudokuModel sudokumodel)
        {
            var row = sudokumodel.Sudoku[cellmodel.row];
            List<CellModel> columns = new List<CellModel>();
            for (int i = 0; i < 9; i++)
            {
               columns.Add(sudokumodel.Sudoku[i][cellmodel.column]);
            }

            List<CellModel> square = new List<CellModel>();
            for (int x = 0; x< 9; x++ )
            {
             
            }
        }


        static void Main(string[] args)
        {
            var SudokuBoard = new SudokuModel() { Sudoku = new System.Collections.Generic.List<System.Collections.Generic.List<CellModel>>()
            {
                new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 0, square = 0  } ,
                    new CellModel { value = 1, column = 1, row = 0, square = 0  },
                    new CellModel { value = 2, column = 2, row = 0, square = 0  },
                    new CellModel { value = 3, column = 3, row = 0, square = 0  },
                    new CellModel { value = 4, column = 4, row = 0, square = 0  },
                    new CellModel { value = 5, column = 5, row = 0, square = 0  },
                    new CellModel { value = 6, column = 6, row = 0, square = 0  },
                    new CellModel { value = 7, column = 7, row = 0, square = 0  },
                    new CellModel { value = 8, column = 8, row = 0, square = 0  },
                },
                        new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 1, square = 0  } ,
                    new CellModel { value = 1, column = 1, row = 1, square = 0  },
                    new CellModel { value = 2, column = 2, row = 1, square = 0  },
                    new CellModel { value = 3, column = 3, row = 1, square = 0  },
                    new CellModel { value = 4, column = 4, row = 1, square = 0  },
                    new CellModel { value = 5, column = 5, row = 1, square = 0  },
                    new CellModel { value = 6, column = 6, row = 1, square = 0  },
                    new CellModel { value = 7, column = 7, row = 1, square = 0  },
                    new CellModel { value = 8, column = 8, row = 1, square = 0  },
                },
                                     new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 2, square = 0  } ,
                    new CellModel { value = 1, column = 1, row = 2, square = 0  },
                    new CellModel { value = 2, column = 2, row = 2, square = 0  },
                    new CellModel { value = 3, column = 3, row = 2, square = 0  },
                    new CellModel { value = 4, column = 4, row = 2, square = 0  },
                    new CellModel { value = 5, column = 5, row = 2, square = 0  },
                    new CellModel { value = 6, column = 6, row = 2, square = 0  },
                    new CellModel { value = 7, column = 7, row = 2, square = 0  },
                    new CellModel { value = 8, column = 8, row = 2, square = 0  },
                },
                                                  new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 3, square = 0  } ,
                    new CellModel { value = 1, column = 1, row = 3, square = 0  },
                    new CellModel { value = 2, column = 2, row = 3, square = 0  },
                    new CellModel { value = 3, column = 3, row = 3, square = 0  },
                    new CellModel { value = 4, column = 4, row = 3, square = 0  },
                    new CellModel { value = 5, column = 5, row = 3, square = 0  },
                    new CellModel { value = 6, column = 6, row = 3, square = 0  },
                    new CellModel { value = 7, column = 7, row = 3, square = 0  },
                    new CellModel { value = 8, column = 8, row = 3, square = 0  },
                },
                                                               new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 4, square = 0  } ,
                    new CellModel { value = 1, column = 1, row = 4, square = 0  },
                    new CellModel { value = 2, column = 2, row = 4, square = 0  },
                    new CellModel { value = 3, column = 3, row = 4, square = 0  },
                    new CellModel { value = 4, column = 4, row = 4, square = 0  },
                    new CellModel { value = 5, column = 5, row = 4, square = 0  },
                    new CellModel { value = 6, column = 6, row = 4, square = 0  },
                    new CellModel { value = 7, column = 7, row = 4, square = 0  },
                    new CellModel { value = 8, column = 8, row = 4, square = 0  },
                },
                                                                            new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 5, square = 0  } ,
                    new CellModel { value = 1, column = 1, row = 5, square = 0  },
                    new CellModel { value = 2, column = 2, row = 5, square = 0  },
                    new CellModel { value = 3, column = 3, row = 5, square = 0  },
                    new CellModel { value = 4, column = 4, row = 5, square = 0  },
                    new CellModel { value = 5, column = 5, row = 5, square = 0  },
                    new CellModel { value = 6, column = 6, row = 5, square = 0  },
                    new CellModel { value = 7, column = 7, row = 5, square = 0  },
                    new CellModel { value = 8, column = 8, row = 5, square = 0  },
                },
                                                                                         new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 6, square = 0  } ,
                    new CellModel { value = 1, column = 1, row = 6, square = 0  },
                    new CellModel { value = 2, column = 2, row = 6, square = 0  },
                    new CellModel { value = 3, column = 3, row = 6, square = 0  },
                    new CellModel { value = 4, column = 4, row = 6, square = 0  },
                    new CellModel { value = 5, column = 5, row = 6, square = 0  },
                    new CellModel { value = 6, column = 6, row = 6, square = 0  },
                    new CellModel { value = 7, column = 7, row = 6, square = 0  },
                    new CellModel { value = 8, column = 8, row = 6, square = 0  },
                },
                                                                                                      new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 7, square = 0  } ,
                    new CellModel { value = 1, column = 1, row = 7, square = 0  },
                    new CellModel { value = 2, column = 2, row = 7, square = 0  },
                    new CellModel { value = 3, column = 3, row = 7, square = 0  },
                    new CellModel { value = 4, column = 4, row = 7, square = 0  },
                    new CellModel { value = 5, column = 5, row = 7, square = 0  },
                    new CellModel { value = 6, column = 6, row = 7, square = 0  },
                    new CellModel { value = 7, column = 7, row = 7, square = 0  },
                    new CellModel { value = 8, column = 8, row = 7, square = 0  },
                },
                                                                                                                   new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 8, square = 0  } ,
                    new CellModel { value = 1, column = 1, row = 8, square = 0  },
                    new CellModel { value = 2, column = 2, row = 8, square = 0  },
                    new CellModel { value = 3, column = 3, row = 8, square = 0  },
                    new CellModel { value = 4, column = 4, row = 8, square = 0  },
                    new CellModel { value = 5, column = 5, row = 8, square = 0  },
                    new CellModel { value = 6, column = 6, row = 8, square = 0  },
                    new CellModel { value = 7, column = 7, row = 8, square = 0  },
                    new CellModel { value = 8, column = 8, row = 8, square = 0  },
                } }

            };


            string firstrow = "";
            for (int i = 0; i < 9; i++)
            {
                firstrow = firstrow + " " + SudokuBoard.Sudoku[0][i].value;
            }
            string secondrow = "";
            for (int i = 0; i < 9; i++)
            {
                secondrow = secondrow + " " + SudokuBoard.Sudoku[1][i].value;
            }
            string thirdrow = "";
            for (int i = 0; i < 9; i++)
            {
                thirdrow = thirdrow + " " + SudokuBoard.Sudoku[2][i].value;
            }
            string fourthrow = "";
            for (int i = 0; i < 9; i++)
            {
                fourthrow = fourthrow + " " + SudokuBoard.Sudoku[3][i].value;
            }
            string fifthrow = "";
            for (int i = 0; i < 9; i++)
            {
                fifthrow = fifthrow + " " + SudokuBoard.Sudoku[4][i].value;
            }
            string sixthrow = "";
            for (int i = 0; i < 9; i++)
            {
                sixthrow = sixthrow + " " + SudokuBoard.Sudoku[5][i].value;
            }
            string seventhrow = "";
            for (int i = 0; i < 9; i++)
            {
                seventhrow = seventhrow + " " + SudokuBoard.Sudoku[6][i].value;
            }
            string eightrow = "";
            for (int i = 0; i < 9; i++)
            {
                eightrow = eightrow + " " + SudokuBoard.Sudoku[7][i].value;
            }
            string ninthrow = "";
            for (int i = 0; i < 9; i++)
            {
                ninthrow = ninthrow + " " + SudokuBoard.Sudoku[8][i].value;
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
