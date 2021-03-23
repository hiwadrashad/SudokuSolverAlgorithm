using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolverAlgorithm
{
    public class Program
    {

        public static SudokuModel SolveSudokuLogical(SudokuModel model)
        {
            SudokuModel returnmodel = new SudokuModel();
            for (int i = 0; i < 9; i++)
            {
                for (int a = 0; a < 9; a++)
                {
                    if (model.Sudoku[i][a].value == 0)
                    {
                        returnmodel = SolveCellLogical(model.Sudoku[i][a], model);
                        if (returnmodel.FaultyBoard == true)
                        {
                            return returnmodel;
                        }
                    }
                    if (i == 8 && a == 8)
                    {
                        return returnmodel;
                    }
                }
            }
            return new SudokuModel();
        }
        public static SudokuModel SolveCellLogical(CellModel cellmodel, SudokuModel sudokumodel)
        {
            var row = sudokumodel.Sudoku[cellmodel.row];
            List<CellModel> columns = new List<CellModel>();
            for (int i = 0; i < 9; i++)
            {
                columns.Add(DeepClone.DeepCloner(sudokumodel.Sudoku[i][cellmodel.column]));
            }

            List<CellModel> square = new List<CellModel>();
            for (int x = 0; x < 9; x++)
            {
                List<CellModel> squarerow = sudokumodel.Sudoku[x].Where(a => a.square == cellmodel.square).ToList();
                square.AddRange(DeepClone.DeepCloner(squarerow));
            }
            for (int ab = 1; ab < 10; ab++)
            {
                if (row.Where(a => a.value == ab).Any())
                {
          
                    continue;
                }
                if (columns.Where(a => a.value == ab).Any())
                {
    
                    continue;
                }
                if (square.Where(a => a.value == ab).Any())
                {
          
                    continue;
                }
               
                sudokumodel.Sudoku[cellmodel.row][cellmodel.column].value = ab;
          
            }
            if (sudokumodel.Sudoku[cellmodel.row][cellmodel.column].value == 0)
            {
                sudokumodel.FaultyBoard = true;
            }
            return sudokumodel;
        }

        static void Main(string[] args)
        {
            var SudokuBoard = new SudokuModel()
            {
                Sudoku = new System.Collections.Generic.List<System.Collections.Generic.List<CellModel>>()
            {
                new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 1, column = 0, row = 0, square = 0  } ,
                    new CellModel { value = 0, column = 1, row = 0, square = 0  },
                    new CellModel { value = 0, column = 2, row = 0, square = 0  },
                    new CellModel { value = 0, column = 3, row = 0, square = 1  },
                    new CellModel { value = 0, column = 4, row = 0, square = 1  },
                    new CellModel { value = 0, column = 5, row = 0, square = 1  },
                    new CellModel { value = 0, column = 6, row = 0, square = 2  },
                    new CellModel { value = 0, column = 7, row = 0, square = 2  },
                    new CellModel { value = 6, column = 8, row = 0, square = 2  },
                },
                        new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 1, square = 0  } ,
                    new CellModel { value = 0, column = 1, row = 1, square = 0  },
                    new CellModel { value = 6, column = 2, row = 1, square = 0  },
                    new CellModel { value = 0, column = 3, row = 1, square = 1  },
                    new CellModel { value = 2, column = 4, row = 1, square = 1  },
                    new CellModel { value = 0, column = 5, row = 1, square = 1  },
                    new CellModel { value = 7, column = 6, row = 1, square = 2  },
                    new CellModel { value = 0, column = 7, row = 1, square = 2  },
                    new CellModel { value = 0, column = 8, row = 1, square = 2  },
                },
                                     new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 7, column = 0, row = 2, square = 0  } ,
                    new CellModel { value = 8, column = 1, row = 2, square = 0  },
                    new CellModel { value = 9, column = 2, row = 2, square = 0  },
                    new CellModel { value = 4, column = 3, row = 2, square = 1  },
                    new CellModel { value = 5, column = 4, row = 2, square = 1  },
                    new CellModel { value = 0, column = 5, row = 2, square = 1  },
                    new CellModel { value = 1, column = 6, row = 2, square = 2  },
                    new CellModel { value = 0, column = 7, row = 2, square = 2  },
                    new CellModel { value = 3, column = 8, row = 2, square = 2  },
                },
                                                  new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 3, square = 3  } ,
                    new CellModel { value = 0, column = 1, row = 3, square = 3  },
                    new CellModel { value = 0, column = 2, row = 3, square = 3  },
                    new CellModel { value = 8, column = 3, row = 3, square = 4  },
                    new CellModel { value = 0, column = 4, row = 3, square = 4 },
                    new CellModel { value = 7, column = 5, row = 3, square = 4  },
                    new CellModel { value = 0, column = 6, row = 3, square = 5  },
                    new CellModel { value = 0, column = 7, row = 3, square = 5  },
                    new CellModel { value = 4, column = 8, row = 3, square = 5  },
                },
                                                               new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 4, square = 3  } ,
                    new CellModel { value = 0, column = 1, row = 4, square = 3  },
                    new CellModel { value = 0, column = 2, row = 4, square = 3  },
                    new CellModel { value = 0, column = 3, row = 4, square = 4  },
                    new CellModel { value = 3, column = 4, row = 4, square = 4  },
                    new CellModel { value = 0, column = 5, row = 4, square = 4  },
                    new CellModel { value = 0, column = 6, row = 4, square = 5  },
                    new CellModel { value = 0, column = 7, row = 4, square = 5  },
                    new CellModel { value = 0, column = 8, row = 4, square = 5  },
                },
                                                                            new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 5, square = 3  } ,
                    new CellModel { value = 9, column = 1, row = 5, square = 3  },
                    new CellModel { value = 0, column = 2, row = 5, square = 3  },
                    new CellModel { value = 0, column = 3, row = 5, square = 4  },
                    new CellModel { value = 0, column = 4, row = 5, square = 4  },
                    new CellModel { value = 4, column = 5, row = 5, square = 4  },
                    new CellModel { value = 2, column = 6, row = 5, square = 5  },
                    new CellModel { value = 0, column = 7, row = 5, square = 5  },
                    new CellModel { value = 1, column = 8, row = 5, square = 5  },
                },
                                                                                         new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 3, column = 0, row = 6, square = 6  } ,
                    new CellModel { value = 1, column = 1, row = 6, square = 6  },
                    new CellModel { value = 2, column = 2, row = 6, square = 6  },
                    new CellModel { value = 9, column = 3, row = 6, square = 7  },
                    new CellModel { value = 7, column = 4, row = 6, square = 7  },
                    new CellModel { value = 0, column = 5, row = 6, square = 7  },
                    new CellModel { value = 0, column = 6, row = 6, square = 8  },
                    new CellModel { value = 4, column = 7, row = 6, square = 8  },
                    new CellModel { value = 0, column = 8, row = 6, square = 8  },
                },
                                                                                                      new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 7, square = 6  } ,
                    new CellModel { value = 4, column = 1, row = 7, square = 6  },
                    new CellModel { value = 0, column = 2, row = 7, square = 6  },
                    new CellModel { value = 0, column = 3, row = 7, square = 7  },
                    new CellModel { value = 1, column = 4, row = 7, square = 7  },
                    new CellModel { value = 2, column = 5, row = 7, square = 7  },
                    new CellModel { value = 0, column = 6, row = 7, square = 8  },
                    new CellModel { value = 7, column = 7, row = 7, square = 8  },
                    new CellModel { value = 8, column = 8, row = 7, square = 8  },
                },
                                                                                                                   new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 9, column = 0, row = 8, square = 6  } ,
                    new CellModel { value = 0, column = 1, row = 8, square = 6  },
                    new CellModel { value = 8, column = 2, row = 8, square = 6  },
                    new CellModel { value = 0, column = 3, row = 8, square = 7  },
                    new CellModel { value = 0, column = 4, row = 8, square = 7  },
                    new CellModel { value = 0, column = 5, row = 8, square = 7  },
                    new CellModel { value = 0, column = 6, row = 8, square = 8  },
                    new CellModel { value = 0, column = 7, row = 8, square = 8  },
                    new CellModel { value = 0, column = 8, row = 8, square = 8  },
                } }

            };

            var solvedboard = SolveSudokuLogical(SudokuBoard);

            string firstrow = "";
            for (int i = 0; i < 9; i++)
            {
                firstrow = firstrow + " " + solvedboard.Sudoku[0][i].value;
            }
            string secondrow = "";
            for (int i = 0; i < 9; i++)
            {
                secondrow = secondrow + " " + solvedboard.Sudoku[1][i].value;
            }
            string thirdrow = "";
            for (int i = 0; i < 9; i++)
            {
                thirdrow = thirdrow + " " + solvedboard.Sudoku[2][i].value;
            }
                string fourthrow = "";

            for (int i = 0; i < 9; i++)
            {
                fourthrow = fourthrow + " " + solvedboard.Sudoku[3][i].value;
            }
            string fifthrow = "";
            for (int i = 0; i < 9; i++)
            {
                fifthrow = fifthrow + " " + solvedboard.Sudoku[4][i].value;
            }
                    string sixthrow = "";
            for (int i = 0; i < 9; i++)
            {
                sixthrow = sixthrow + " " + solvedboard.Sudoku[5][i].value;
            }
                        string seventhrow = "";
            for (int i = 0; i < 9; i++)
            {
                seventhrow = seventhrow + " " + solvedboard.Sudoku[6][i].value;
            }
                            string eightrow = "";
            for (int i = 0; i < 9; i++)
            {
                eightrow = eightrow + " " + solvedboard.Sudoku[7][i].value;
            }
            string ninthrow = "";
            for (int i = 0; i < 9; i++)
            {
                ninthrow = ninthrow + " " + solvedboard.Sudoku[8][i].value;
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
