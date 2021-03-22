using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lista2
{
    class JolkaSolver
    {

        bool second = false;
        public int count_results = 0;
        public int count_returns = 0;
        public int count_visited = 0;
        Stopwatch watch = Stopwatch.StartNew();

        public bool solver(Jolka jolka)
        {
           
               
            int next_zmienna = 0 ;
            
            for (int i = 0; i < jolka.zmienne.Count; i++)
            {
                
                if(jolka.zmienne[i].value.Equals(""))
                {
                    next_zmienna = i;                  
                    break;
                }
            }
           
            if (jolka.used.Count==jolka.words.Count && jolka.checkAllRestr())
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

            jolka.zmienne[next_zmienna].nextValueBT();
            for (int i=0;i<jolka.zmienne[next_zmienna].values.Count;i++)
            {

               
               /* if (second && jolka.used.Count==0 )
                {
                   // Console.Write("Used: ");
                    foreach (string s in jolka.used)
                    {
                        Console.Write(s + ", ");
                    }
                }*/
                count_visited++;
                jolka.zmienne[next_zmienna].value = jolka.zmienne[next_zmienna].values[i];
              
                if(!jolka.used.Contains(jolka.zmienne[next_zmienna].value) && jolka.checkAllRestr())
                {
                    jolka.used.Add(jolka.zmienne[next_zmienna].values[i]);
                   
                    if (solver(jolka))
                    {                      
                        return true;
                    }
                    else
                    {
                        jolka.used.RemoveAt(jolka.used.Count-1);                     
                        jolka.zmienne[next_zmienna].value = "";
                        count_returns++;
                    }
                    
                }
                else
                {
                   
                    jolka.zmienne[next_zmienna].value = "";
                   // Console.WriteLine("Ima here");
                    count_returns++;
                    
                }
               

            }
            
            
            return false;
        }

       

    }
}
