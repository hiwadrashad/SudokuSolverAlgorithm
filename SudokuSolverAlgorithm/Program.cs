using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolverAlgorithm
{
    public class Program
    {


        //layer 2
        private static bool SolveSudokuLogical2(SudokuModel model)
        {
            for (int i = 0; i < model.Sudoku.Count; i++)
            {
                for (int j = 0; j <model.Sudoku[0].Count; j++)
                {
                    if (model.Sudoku[i][j].value == 0)
                    {
                        for (int c = 1; c <= 9; c++)
                        {
                            if (CheckConstraints(model, i, j, c))
                            {
                                model.Sudoku[i][j].value = c;

                                if (SolveSudokuLogical2(model))
                                    return true;
                                else

                                    model.Sudoku[i][j].value = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
        private static bool SolveSudokuGuessing(SudokuModel model)
        {
            Random rnd = new Random();
            CalculateListOfOptions(model);
            for (int i = 0; i < model.Sudoku.Count; i++)
            {
                for (int j = 0; j < model.Sudoku[0].Count; j++)
                {
                    if (model.Sudoku[i][j].value == 0)
                    {
                        if (model.Sudoku[i][j].amountofoptions == 1)
                        {
                            var randomnumber = rnd.Next(1, 10);
                            do
                            {
                                if (CheckConstraints(model, i, j, randomnumber))
                                {
                                    model.Sudoku[i][j].value = randomnumber;
                                    goto SolveSudoku;
                                }
                            }
                            while (CheckConstraints(model, i, j, randomnumber) == false);
                            for (int c = 1; c <= 9; c++)
                             {
                                if (CheckConstraints(model, i, j, c))
                                {
                                    model.Sudoku[i][j].value = c;
                                    goto SolveSudoku;
                                }
                            }
                        }
                    }
                }
            }

            SolveSudoku:

            for (int i = 0; i < model.Sudoku.Count; i++)
            {
                for (int j = 0; j < model.Sudoku[0].Count; j++)
                {
                    if (model.Sudoku[i][j].value == 0)
                    {
                        for (int c = 1; c <= 9; c++)
                        {
                            if (CheckConstraints(model, i, j, c))
                            {
                                model.Sudoku[i][j].value = c;

                                if (SolveSudokuLogical2(model))
                                    return true;
                                else

                                    model.Sudoku[i][j].value = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool SolveSudokuGuessing2(SudokuModel model)
        {
            List<CellModel> PreviousChosenRandomNumbers = new List<CellModel>();

            goto GuessNumber;

            GuessNumber:

            Random rnd = new Random();
            CalculateListOfOptions(model);
            for (int i = 0; i < model.Sudoku.Count; i++)
            {
                for (int j = 0; j < model.Sudoku[0].Count; j++)
                {
                    if (model.Sudoku[i][j].value == 0)
                    {
                        if (model.Sudoku[i][j].amountofoptions == 1)
                        {
                            var randomnumber = rnd.Next(1, 10);
                            do
                            {
                                if (CheckConstraints(model, i, j, randomnumber))
                                {
                                    if (!PreviousChosenRandomNumbers.Contains(model.Sudoku[i][j]))
                                    {

                                        model.Sudoku[i][j].value = randomnumber;
                                        PreviousChosenRandomNumbers.Add(model.Sudoku[i][j]);
                                        goto SolveSudoku;
                                    }
                                }
                            }
                            while (CheckConstraints(model, i, j, randomnumber) == false);
                            for (int c = 1; c <= 9; c++)
                            {
                                if (CheckConstraints(model, i, j, c))
                                {
                                    model.Sudoku[i][j].value = c;
                                    goto SolveSudoku;
                                }
                            }
                        }
                    }
                }
            }

            SolveSudoku:


            for (int i = 0; i < model.Sudoku.Count; i++)
            {
                for (int j = 0; j < model.Sudoku[0].Count; j++)
                {
                    if (model.Sudoku[i][j].value == 0)
                    {
                        for (int c = 1; c <= 9; c++)
                        {
                            if (CheckConstraints(model, i, j, c))
                            {

                                model.Sudoku[i][j].value = c;

                                if (SolveSudokuGuessing2(model))
                                    return true;
                                else
                                    model.Sudoku[i][j].value = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool CheckConstraints(SudokuModel model, int row, int col, int c)
        {
            for (int i = 0; i < 9; i++)
            {
                if (model.Sudoku[i][col].value != 0 && model.Sudoku[i][col].value == c)
                    return false;
                if (model.Sudoku[row][i].value != 0 && model.Sudoku[row][i].value == c)
                    return false;
                if (model.Sudoku[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3].value != 0 && model.Sudoku[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3].value == c)
                    return false;
            }
            return true;
        }

        private static bool SolveSudokuLogical3(SudokuModel model)
        {
            bool? solves = null;
            while (solves == null)
            {

                for (int i = 0; i < model.Sudoku.Count; i++)
                {
                    for (int j = 0; j < model.Sudoku[0].Count; j++)
                    {
                        if (model.Sudoku[i][j].value == 0)
                        {
                            for (int c = 1; c <= 9; c++)
                            {
                                CalculateListOfOptions(model);
                                if (model.Sudoku[i][j].amountofoptions == 1)
                                {
                                    if (CheckConstraints(model, i, j, c))
                                    {
                                        model.Sudoku[i][j].value = c;

                                        if (SolveSudokuLogical3(model))
                                            solves = true;
                                        else
                                            model.Sudoku[i][j].value = 0;
                                    }
                                }
                            }
                            solves = false;
                        }
                    }
                }
                solves = true;
            }
            return true;
        }
        private static bool CalculateListOfOptions(SudokuModel model)
        {
            List<CellModel> listofoptions = new List<CellModel>();
            for (int i = 0; i < model.Sudoku.Count; i++)
            {
                for (int j = 0; j < model.Sudoku[0].Count; j++)
                {
                    if (model.Sudoku[i][j].value == 0)
                    {
                        for (int c = 1; c <= 9; c++)
                        {
                            model.Sudoku[i][j].amountofoptions = CheckOptions(model,i,j,c);                               
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private static int CheckOptions(SudokuModel model, int row, int col, int c)
        {
            int amounofoptions = 0;
            for (int i = 0; i < 9; i++)
            {
                if (model.Sudoku[i][col].value != 0 && model.Sudoku[i][col].value == c)
                    continue;
                if (model.Sudoku[row][i].value != 0 && model.Sudoku[row][i].value == c)
                    continue;
                if (model.Sudoku[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3].value != 0 && model.Sudoku[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3].value == c)
                    continue;
                else
                {
                    amounofoptions++;
                }
            }
            return amounofoptions;
        }
        public static SudokuModel SolveSudokuLayeredVariations(SudokuModel model)
        {
            SudokuModel returnmodel = new SudokuModel();
            for (int i = 0; i < 9; i++)
            {
                for (int a = 0; a < 9; a++)
                {
                    if (model.Sudoku[i][a].value == 0)
                    {
                        returnmodel = SolveCellLogical(model.Sudoku[i][a], model);
                        //if (returnmodel.FaultyBoard == true)
                        //{
                        //    return returnmodel;
                        //}
                    }
                    if (i == 8 && a == 8)
                    {
                        return returnmodel;
                    }
                }
            }
            return returnmodel;
        }

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
                        //if (returnmodel.FaultyBoard == true)
                        //{
                        //    return returnmodel;
                        //}
                    }
                    if (i == 8 && a == 8)
                    {
                        return returnmodel;
                    }
                }
            }
            return returnmodel;
        }
        public static SudokuModel SolveSudokuHierArchical(SudokuModel model)
        {
            var hierarchy = GenerateSudokuCellsHierarchical(model);

            for (int a = 1; a < 10; a++)
            {

                List<CellModel> ascendingoptionscellvalues = hierarchy.Where(x => x.amountofoptions == a).ToList();
                if (ascendingoptionscellvalues.Any())
                {
                    for (int x = 0; x < ascendingoptionscellvalues.Count; x++)
                    {
                       SolveCellLogical(ascendingoptionscellvalues[x], model);
                    }
                }
            }
            return model;
        }

        public static SudokuModel SolveSudokuHierArchical2(SudokuModel model)
        {

            for (int i = 0; i < 99; i++)
            {
                var hierarchy = GenerateSudokuCellsHierarchical(model);



                List<CellModel> ascendingoptionscellvalues = hierarchy.Where(x => x.amountofoptions == 1).ToList();
                if (ascendingoptionscellvalues.Any())
                {
                    for (int x = 0; x < ascendingoptionscellvalues.Count; x++)
                    {
                        SolveCellLogical(ascendingoptionscellvalues[x], model);
                    }
                    continue;
                }
                //if (hierarchy.Where(x => x.amountofoptions == 2).ToList().Any())
                //{ 
                // List<CellModel> ascendingoptionscellvalues2 = hierarchy.Where(x => x.amountofoptions == 2).ToList();
                //    for (int x = 0; x < ascendingoptionscellvalues2.Count; x++)
                //    {
                //        SolveCellLogical(ascendingoptionscellvalues2[x], model);
                //    }
                //    continue;
                //}
                //if (hierarchy.Where(x => x.amountofoptions == 3).ToList().Any())
                //{
                //    List<CellModel> ascendingoptionscellvalues3 = hierarchy.Where(x => x.amountofoptions == 3).ToList();
                //    for (int x = 0; x < ascendingoptionscellvalues3.Count; x++)
                //    {
                //        SolveCellLogical(ascendingoptionscellvalues3[x], model);
                //    }
                //    continue;
                //}
                //if (hierarchy.Where(x => x.amountofoptions == 4).ToList().Any())
                //{
                //    List<CellModel> ascendingoptionscellvalues4 = hierarchy.Where(x => x.amountofoptions == 4).ToList();
                //    for (int x = 0; x < ascendingoptionscellvalues4.Count; x++)
                //    {
                //        SolveCellLogical(ascendingoptionscellvalues4[x], model);
                //    }
                //    continue;
                //}
                //if (hierarchy.Where(x => x.amountofoptions == 5).ToList().Any())
                //{
                //    List<CellModel> ascendingoptionscellvalues5 = hierarchy.Where(x => x.amountofoptions == 5).ToList();
                //    for (int x = 0; x < ascendingoptionscellvalues5.Count; x++)
                //    {
                //        SolveCellLogical(ascendingoptionscellvalues5[x], model);
                //    }
                //    continue;
                //}
                //if (hierarchy.Where(x => x.amountofoptions == 6).ToList().Any())
                //{
                //    List<CellModel> ascendingoptionscellvalues6 = hierarchy.Where(x => x.amountofoptions == 6).ToList();
                //    for (int x = 0; x < ascendingoptionscellvalues6.Count; x++)
                //    {
                //        SolveCellLogical(ascendingoptionscellvalues6[x], model);
                //    }
                //    continue;
                //}
                //if (hierarchy.Where(x => x.amountofoptions == 7).ToList().Any())
                //{
                //    List<CellModel> ascendingoptionscellvalues7 = hierarchy.Where(x => x.amountofoptions == 7).ToList();
                //    for (int x = 0; x < ascendingoptionscellvalues7.Count; x++)
                //    {
                //        SolveCellLogical(ascendingoptionscellvalues7[x], model);
                //    }
                //    continue;
                //}
                //if (hierarchy.Where(x => x.amountofoptions == 8).ToList().Any())
                //{
                //    List<CellModel> ascendingoptionscellvalues8 = hierarchy.Where(x => x.amountofoptions == 8).ToList();
                //    for (int x = 0; x < ascendingoptionscellvalues8.Count; x++)
                //    {
                //        SolveCellLogical(ascendingoptionscellvalues8[x], model);
                //    }
                //    continue;
                //}
                //if (hierarchy.Where(x => x.amountofoptions == 9).ToList().Any())
                //{
                //    List<CellModel> ascendingoptionscellvalues9 = hierarchy.Where(x => x.amountofoptions == 9).ToList();
                //    for (int x = 0; x < ascendingoptionscellvalues9.Count; x++)
                //    {
                //        SolveCellLogical(ascendingoptionscellvalues9[x], model);
                //    }
                //    continue;
                //}
                else
                {
                    break;
                }
            }
            
            return model;
        }

        public static List<CellModel> GenerateSudokuCellsHierarchical(SudokuModel model)
        {
            SudokuModel returnmodel = new SudokuModel();
            List<CellModel> emptycells = new List<CellModel>();
            for (int i = 0; i < 9; i++)
            {
                for (int a = 0; a < 9; a++)
                {
                    if (model.Sudoku[i][a].value == 0)
                    {
                        emptycells.Add(CountOptionsCellHierarchical(model.Sudoku[i][a], model));
                        //if (returnmodel.FaultyBoard == true)
                        //{
                        //    return returnmodel;
                        //}
                    }
                    //if (i == 8 && a == 8)
                    //{
                    //    return returnmodel;
                    //} 
                }
            }
            return emptycells;
        }

        public static CellModel CountOptionsCellHierarchical(CellModel cellmodel, SudokuModel sudokumodel)
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

                cellmodel.amountofoptions++;

            }
            //if (sudokumodel.Sudoku[cellmodel.row][cellmodel.column].value == 0)
            //{
            //    sudokumodel.FaultyBoard = true;
            //}
            return cellmodel;
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
                    new CellModel { value = 5, column = 0, row = 0, square = 0  } ,
                    new CellModel { value = 3, column = 1, row = 0, square = 0  },
                    new CellModel { value = 0, column = 2, row = 0, square = 0  },
                    new CellModel { value = 0, column = 3, row = 0, square = 1  },
                    new CellModel { value = 7, column = 4, row = 0, square = 1  },
                    new CellModel { value = 0, column = 5, row = 0, square = 1  },
                    new CellModel { value = 0, column = 6, row = 0, square = 2  },
                    new CellModel { value = 0, column = 7, row = 0, square = 2  },
                    new CellModel { value = 0, column = 8, row = 0, square = 2  },
                },
                        new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 6, column = 0, row = 1, square = 0  } ,
                    new CellModel { value = 0, column = 1, row = 1, square = 0  },
                    new CellModel { value = 0, column = 2, row = 1, square = 0  },
                    new CellModel { value = 1, column = 3, row = 1, square = 1  },
                    new CellModel { value = 9, column = 4, row = 1, square = 1  },
                    new CellModel { value = 5, column = 5, row = 1, square = 1  },
                    new CellModel { value = 0, column = 6, row = 1, square = 2  },
                    new CellModel { value = 0, column = 7, row = 1, square = 2  },
                    new CellModel { value = 0, column = 8, row = 1, square = 2  },
                },
                                     new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 2, square = 0  } ,
                    new CellModel { value = 9, column = 1, row = 2, square = 0  },
                    new CellModel { value = 8, column = 2, row = 2, square = 0  },
                    new CellModel { value = 0, column = 3, row = 2, square = 1  },
                    new CellModel { value = 0, column = 4, row = 2, square = 1  },
                    new CellModel { value = 0, column = 5, row = 2, square = 1  },
                    new CellModel { value = 0, column = 6, row = 2, square = 2  },
                    new CellModel { value = 6, column = 7, row = 2, square = 2  },
                    new CellModel { value = 0, column = 8, row = 2, square = 2  },
                },
                                                  new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 8, column = 0, row = 3, square = 3  } ,
                    new CellModel { value = 0, column = 1, row = 3, square = 3  },
                    new CellModel { value = 0, column = 2, row = 3, square = 3  },
                    new CellModel { value = 0, column = 3, row = 3, square = 4  },
                    new CellModel { value = 6, column = 4, row = 3, square = 4 },
                    new CellModel { value = 0, column = 5, row = 3, square = 4  },
                    new CellModel { value = 0, column = 6, row = 3, square = 5  },
                    new CellModel { value = 0, column = 7, row = 3, square = 5  },
                    new CellModel { value = 3, column = 8, row = 3, square = 5  },
                },
                                                               new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 4, column = 0, row = 4, square = 3  } ,
                    new CellModel { value = 0, column = 1, row = 4, square = 3  },
                    new CellModel { value = 0, column = 2, row = 4, square = 3  },
                    new CellModel { value = 8, column = 3, row = 4, square = 4  },
                    new CellModel { value = 0, column = 4, row = 4, square = 4  },
                    new CellModel { value = 3, column = 5, row = 4, square = 4  },
                    new CellModel { value = 0, column = 6, row = 4, square = 5  },
                    new CellModel { value = 0, column = 7, row = 4, square = 5  },
                    new CellModel { value = 1, column = 8, row = 4, square = 5  },
                },
                                                                            new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 7, column = 0, row = 5, square = 3  } ,
                    new CellModel { value = 0, column = 1, row = 5, square = 3  },
                    new CellModel { value = 0, column = 2, row = 5, square = 3  },
                    new CellModel { value = 0, column = 3, row = 5, square = 4  },
                    new CellModel { value = 2, column = 4, row = 5, square = 4  },
                    new CellModel { value = 0, column = 5, row = 5, square = 4  },
                    new CellModel { value = 0, column = 6, row = 5, square = 5  },
                    new CellModel { value = 0, column = 7, row = 5, square = 5  },
                    new CellModel { value = 6, column = 8, row = 5, square = 5  },
                },
                                                                                         new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 6, square = 6  } ,
                    new CellModel { value = 6, column = 1, row = 6, square = 6  },
                    new CellModel { value = 0, column = 2, row = 6, square = 6  },
                    new CellModel { value = 0, column = 3, row = 6, square = 7  },
                    new CellModel { value = 0, column = 4, row = 6, square = 7  },
                    new CellModel { value = 0, column = 5, row = 6, square = 7  },
                    new CellModel { value = 2, column = 6, row = 6, square = 8  },
                    new CellModel { value = 8, column = 7, row = 6, square = 8  },
                    new CellModel { value = 0, column = 8, row = 6, square = 8  },
                },
                                                                                                      new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 7, square = 6  } ,
                    new CellModel { value = 0, column = 1, row = 7, square = 6  },
                    new CellModel { value = 0, column = 2, row = 7, square = 6  },
                    new CellModel { value = 4, column = 3, row = 7, square = 7  },
                    new CellModel { value = 1, column = 4, row = 7, square = 7  },
                    new CellModel { value = 9, column = 5, row = 7, square = 7  },
                    new CellModel { value = 0, column = 6, row = 7, square = 8  },
                    new CellModel { value = 0, column = 7, row = 7, square = 8  },
                    new CellModel { value = 5, column = 8, row = 7, square = 8  },
                },
                                                                                                                   new System.Collections.Generic.List<CellModel>
                {
                    new CellModel { value = 0, column = 0, row = 8, square = 6  } ,
                    new CellModel { value = 0, column = 1, row = 8, square = 6  },
                    new CellModel { value = 0, column = 2, row = 8, square = 6  },
                    new CellModel { value = 0, column = 3, row = 8, square = 7  },
                    new CellModel { value = 8, column = 4, row = 8, square = 7  },
                    new CellModel { value = 0, column = 5, row = 8, square = 7  },
                    new CellModel { value = 0, column = 6, row = 8, square = 8  },
                    new CellModel { value = 7, column = 7, row = 8, square = 8  },
                    new CellModel { value = 9, column = 8, row = 8, square = 8  },
                } }

            };
            SolveSudokuGuessing2(SudokuBoard);
            var solvedboard = SudokuBoard;

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
