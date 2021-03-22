using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lista2
{
    class JolkaFC
    {
        bool second = false;
        public int count_results = 0;
        public int count_returns = 0;
        public int count_visited = 0;
        int max_visited = 0;
        Stopwatch watch = Stopwatch.StartNew();
        
        Random rand = new Random();

        public bool solver(Jolka jolka)
        {
           

            List<string> poss = new List<string>();
           
         

            if (jolka.notusedZ.Count==0 && jolka.usedZ.Count == jolka.words.Count && jolka.checkAllRestrFC())
            {

                count_results++;

                if (!second)
                {
                   
                    Console.WriteLine(count_returns);
                    Console.WriteLine(count_visited);
                    Console.WriteLine(watch.ElapsedMilliseconds);
                    watch.Stop();
                    //jolka.showGrid();
                }
                second = !second;
                //return true;
            }
         
            jolka.addToPossible();
            if (!(jolka.notusedZ.Count == 0))
            {
                jolka.notusedZ[0].nextValue(); 

             
                foreach(string x in jolka.notusedZ[0].possiblevalues)
                {
                    poss.Add(x);
                }
            }
           
            for (int i = 0; i < poss.Count; i++)
            {
               
                count_visited++;
                jolka.notusedZ[0].value = poss[i];
                jolka.usedZ.Add(jolka.notusedZ[0]);
               
                jolka.notusedZ.RemoveAt(0);
               
                if (!jolka.ifused(jolka.usedZ[jolka.usedZ.Count-1].value) && jolka.checkAllRestr())
                {
                    
                   
                    jolka.used.Add(jolka.usedZ[jolka.usedZ.Count-1].value);
                    if (solver(jolka))
                    {
                       
                        return true;
                        
                    }
                    else
                    {
                       
                        jolka.used.RemoveAt(jolka.used.Count - 1);
                        if (jolka.usedZ.Count>0)
                        {
                            jolka.usedZ[jolka.usedZ.Count - 1].value = "";
                            jolka.notusedZ.Insert(0,jolka.usedZ[jolka.usedZ.Count - 1]);
                            jolka.usedZ.RemoveAt(jolka.usedZ.Count - 1);
                           
                        }
                        count_returns++;
                        
                    }
                }
                else
                {
                   
                    if (jolka.usedZ.Count > 0)
                    {
                        jolka.usedZ[jolka.usedZ.Count - 1].value = "";
                        jolka.notusedZ.Insert(0,jolka.usedZ[jolka.usedZ.Count - 1]);
                        jolka.usedZ.RemoveAt(jolka.usedZ.Count - 1);
                       
                        

                    }
                    count_returns++;
                }

            }


            return false;
        }

    }
}
