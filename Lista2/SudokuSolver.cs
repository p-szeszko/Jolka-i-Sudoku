using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lista2
{
    class SudokuSolver
    {
        
        public int count_results = 0;
        public int count_returns = 0;
        public int count_visited = 0;
        bool second = false;
       public List<Sudoku> result=new List<Sudoku>();
        Stopwatch watch = Stopwatch.StartNew();
        public SudokuSolver()
        {
            
        }

        public bool solveSudoku(Sudoku puzzle)
        {
            Sudoku next_data;
            int row = -1;
            int col = -1;
            bool isEmpty = true;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j <9; j++)
                {
                    if (puzzle.grids[i, j] == 0)
                    {
                        row = i;
                        col = j;

                        
                        isEmpty = false;
                        break;
                    }
                    else
                    {
                        row = 0;
                        col = 0;
                    }
                }
                if (!isEmpty)
                {
                    break;
                }
            }          
            if (puzzle.isEmpty())
            {
                if (!second)
                {
                    puzzle.showGrids();
                    Console.WriteLine("Czas do znalezienia pierwszego: " + watch.ElapsedMilliseconds);
                    watch.Stop();
                    Console.WriteLine("Pierwsze rozw powroty: " + count_returns);
                    Console.WriteLine("Pierwsze rozw odwiedzone: " + count_visited);
                }
                second = !second;
                count_results++;
                //result.Add(new Sudoku (puzzle));
                //result[0].showGrids();
                //return true;

            }
            for (int num = 1; num <= 9; num++)  // wybór zmiennej od 1 do 9 po kolei, późniejsze sprawdzenie, czy po przypisaniu spełnia warunek poprawności.
            {
                count_visited++;
                if (puzzle.checkSafe(row,col,num)) // sprawdzenie poprawności
                {
                    
                    puzzle.grids[row,col] = (char)num;
                    next_data = new Sudoku(puzzle);
                    if (solveSudoku(next_data))
                    {
                        
                        
                        return true;
                    }
                    else
                    {
                        count_returns++;
                        puzzle.grids[row,col] = 0; // cofnięcie przypisania (backtracking)                                               
                    }
                   
                }
                else
                {
                    count_returns++;
                }
               
            }
            
            return false;


        }
            
    }
}
