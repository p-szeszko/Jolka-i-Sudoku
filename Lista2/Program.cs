using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lista2
{
    class Program
    {
        static void Main(string[] args)
        {
           /* Console.WriteLine("Sudoku");
            List<Sudoku> puzzles = readSudoku(@"E:\Semestr 6\SI\ai-lab2-2020-dane\Sudoku.csv");        
             //Sudoku s = new Sudoku();
            // s.puzzle=new List<int>{2,9,5,7,4,3,8,6,1,4,3,1,8,6,5,9,0,0,8,7,6,1,9,2,5,4,3,3,8,7,4,5,9,2,1,6,6,1,2,3,8,7,4,9,5,5,4,9,2,1,6,7,3,8,7,6,3,5,2,4,1,8,9,9,2,8,6,7,1,3,5,4,1,5,4,9,3,8,6,0,0 };
            // s.makeGrid();
             SudokuSolver solver = new SudokuSolver();
            Stopwatch watch2 = Stopwatch.StartNew();
            solver.solveSudoku(puzzles[42]); // w celu zmiany wykonywanego sudoku, należy wpisać wybrany numer zagadki
            Console.WriteLine("Czas całkowity sudoku: " + watch2.ElapsedMilliseconds);
             //solver.solveSudoku(s); // sprawdzenie znajdowania dwóch rozwiązań 
            // s.showGrids();
             Console.WriteLine("Znalezione rozwiązania: "+solver.count_results);
             Console.WriteLine("Wejść łącznie: "+solver.count_returns);
             Console.WriteLine("Pwrotów łącznie: "+solver.count_visited);*/
            /* foreach (Sudoku z in solver.result)
              {
                  z.showGrids();
              }*/


            //etap sudoku
            /*Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Jolki");
            */
           List<string> crosses = readCrossword(@"E:\Semestr 6\SI\ai-lab2-2020-dane\Jolka\puzzle4"); // do wyboru zagadki: należy zmienić nazwę pliku w obu linijkach
            List<string> words = readCrossword(@"E:\Semestr 6\SI\ai-lab2-2020-dane\Jolka\words4");
            for (int i = 0; i < 10; i++)
            {
                Jolka j = new Jolka(words, crosses);
                JolkaSolver solverJ = new JolkaSolver();
                Stopwatch watch = Stopwatch.StartNew();
                solverJ.solver(j);
               
                Console.WriteLine(solverJ.count_returns);
                Console.WriteLine(solverJ.count_visited);
                Console.WriteLine(watch.ElapsedMilliseconds);
                watch.Stop();
                Console.WriteLine();
            }

           /* Console.WriteLine("Jolki2");
           */
           
            for (int i = 0; i < 10; i++)
            {
                Jolka z = new Jolka(words, crosses);
                JolkaFC solverF = new JolkaFC();
                Stopwatch watch3 = Stopwatch.StartNew();

                solverF.solver(z);

                //Console.WriteLine("Znalezione rozwiązania: " + solverF.count_results);
                Console.WriteLine(solverF.count_returns);
                Console.WriteLine(solverF.count_visited);
                Console.WriteLine(watch3.ElapsedMilliseconds);
                watch3.Stop();
                Console.WriteLine();
            }
            //j.showGrid();
            

        }



        public static List<Sudoku> readSudoku(string filePath)
        {
            {
                List<Sudoku> puzzles = new List<Sudoku>();
                List<string> content = new List<string>();
                using (StreamReader file = new StreamReader(filePath))
                {
                    string ln=file.ReadLine();
                    while ((ln = file.ReadLine()) != null)
                    {
                        content.Add(ln.Replace(".","0"));
                    }

                    for (int i=0; i<content.Count;i++)
                    {
                        string[] chars = content[i].Split(';');
                       
                        puzzles.Add(new Sudoku(chars[2].ToList<char>()));
                    }


                    return puzzles;

                }
                
            }

        }

        public static List<string> readCrossword(string fileSpace)
        {     
                StreamReader Space = new StreamReader(fileSpace);               
                List<string> crosses = new List<string>();             
                string ln;
                while((ln=Space.ReadLine()) !=null )
                {
                    crosses.Add(ln);
                }
            return crosses;
        }

       



    }



} 
