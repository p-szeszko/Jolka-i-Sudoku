using System;
using System.Collections.Generic;
using System.Text;

namespace Lista2
{
    class Sudoku
    {
        // zmienna jest polem które nie ma wczytanej z góry wartości
        //Dziedzina każdej zmiennej jest z zakresu 1-9
        //Ograniczenie, wartość zmiennej nie powtarza się w wierszu, kolumnie, wyznaczonym polu 3x3

        public List<int> puzzle;
        public int[,] grids = new int[9,9];
       

        public Sudoku()
        {
            puzzle = new List<int>();
            
            
          
        }

        public Sudoku(List <char> puzzle)
        {
            this.puzzle = new List<int>();
            for (int i=0;i<puzzle.Count;i++)
            {
                
                this.puzzle.Add( (int) Char.GetNumericValue(puzzle[i]) );
                
            }
            makeGrid();
        }
        public Sudoku (Sudoku copy)
        {
            puzzle = new List<int>(copy.puzzle);
            copyGrid(copy.grids);
           
        }

        public void showPuzzle()
        {
            foreach (int x in puzzle)
            {
                Console.Write(x);
               
            }
            Console.WriteLine();
        }
        public void showGrids()
        {
            for (int i = 0; i < 9; i++)
            {

                for (int j = 0; j < 9; j++)
                {
                    Console.Write(grids[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
       public void makeGrid()
        {
            //Console.WriteLine(puzzle.Count);
            for (int i=0;i<9;i++)
            {
                
                for( int j=0;j<9;j++)
                {
                    grids[i,j] =puzzle[i * 9 + j];
                }
               
            }
        }

        public void copyGrid(int[,] puzzle)
        {
            for (int i = 0; i < 9; i++)
            {

                for (int j = 0; j < 9; j++)
                {
                    grids[i, j] = puzzle[i, j];
                }
               
            }
            

        }
        

        public bool checkSafe(int row, int col, int num)
        {
            
            for (int i=0;i<9;i++) // ograniczenie nie powtarza się w poziomie
            {
                
                if(grids[row,i]==num)
                {
                    return false;
                }
            }

            for (int i = 0; i < 9; i++) // ograniczenie, że nie powtarza się w pionie
            {
                
                if (grids[i, col] == num)
                {
                    return false;
                }
            }

            int boxRowStart = row - row % 3;
            int boxColStart = col - col % 3;

            for (int r = boxRowStart;  // ograniecznie, że nie powtarza się w swoim kwadracie 3x3
                    r < boxRowStart + 3; r++)
            {
                for (int d = boxColStart;
                        d < boxColStart + 3; d++)
                {
                    
                    if (grids[r, d] == num)
                    {
                        return false;
                    }
                }
            }

            return true;

        }
        public bool checkSolved()
        {
           
            

            for (int i = 0; i < 9; i++)
            {

                for (int j = 0; j < 9; j++)
                {
                    Console.WriteLine(i + " " + j + " " + grids[i, j]);
                    if (!checkSafe(i, j, grids[i, j]))
                    {
                        Console.Write("False");
                        return false;
                        
                    }
                }

            }
            Console.Write("True");
            return true;

        }

        public bool isEmpty()
        {
            for (int i = 0; i < 9; i++)
            {

                for (int j = 0; j < 9; j++)
                {
                    
                    if(grids[i, j] == 0)
                    return false;
                }

            }
            return true;
        }

        
    }
}
