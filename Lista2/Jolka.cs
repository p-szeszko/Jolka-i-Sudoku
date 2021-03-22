using System;
using System.Collections.Generic;
using System.Text;

namespace Lista2
{
    class Jolka
    {
       public List<string> words;
       public List<string> cross;
       public List<JolkaZmienna> zmienneH = new List<JolkaZmienna>();
       public List<JolkaZmienna> zmienneV = new List<JolkaZmienna>();
       public List<JolkaZmienna> zmienne = new List<JolkaZmienna>();
        
       public List<string> used = new List<string>();
        public List<JolkaZmienna> usedZ = new List<JolkaZmienna>();
        public List<JolkaZmienna> notusedZ = new List<JolkaZmienna>();

        public Jolka(List<string> words, List<string> cross)
        {
            this.words = words;
            this.cross = cross;

            tworzZmienne();
            restrictions();
        }

        // public Jolka(Jolka copy)

            public bool ifused(string word)
        {
            return used.Contains(word);
        }


        public void addToPossible()
        {
            
            foreach (JolkaZmienna x in notusedZ)
            {
                x.possiblevalues.Clear();
                
                foreach (string z in x.values)
                {
                    if(!used.Contains(z))
                    {
                        x.value = z;
                        {
                            if(x.checkRestr())
                            {
                                x.possiblevalues.Add(z);
                            }
                        }
                        x.value = "";
                    }                  
                }
            }
        }

        public void tworzZmienne() 
        {
           
            for (int i=0; i<cross[0].Length;i++)
            {
                int size = 0;
                for (int j=0; j<cross.Count;j++)
                {
                    if (cross[j][i].Equals('_')) 
                    {
                        size++;
                       
                    }

                    if (cross[j][i].Equals('#')||j== cross.Count-1)
                    {
                        if (size>1)
                        {
                            JolkaZmienna zm = new JolkaZmienna();
                            for (int z=0; z<words.Count;z++)
                            {
                                if(words[z].Length==size)
                                {
                                   
                                    zm.values.Add(words[z]);
                                    zm.possiblevalues.Add(words[z]);
                                }
                            }

                            zm.col_start = i;

                            zm.vertical = true;
                           
                            if (cross[j][i].Equals('#'))
                            {
                                zm.row_start = j - size;
                            }
                            else
                            {
                                zm.row_start = j + 1 -size;
                            }
                            zm.size = size;
                            zmienneV.Add(zm);
                            zmienne.Add(zm);
                            notusedZ.Add(zm);
                        }
                        size = 0;
                    }
                   
                }
                
            }


            for (int i = 0; i < cross.Count; i++)
            {
                int size = 0;
                for (int j = 0; j < cross[0].Length; j++)
                {
                    if (cross[i][j].Equals('_')) 
                    {
                        size++;
                    }

                    if (cross[i][j].Equals('#') || j == cross[0].Length - 1)
                    {
                        if (size > 1)
                        {
                            
                            JolkaZmienna zm = new JolkaZmienna();
                            foreach(String w in words)
                            {
                                if(w.Length==size)
                                {
                                    zm.values.Add(w);
                                    zm.possiblevalues.Add(w);
                                }



                            }
                            zm.row_start = i;
                            zm.vertical = false;
                            //Console.WriteLine("Ile danych: " + zm.values.Count);
                            if (cross[i][j].Equals('#'))
                            {
                                zm.col_start = j - size;
                            }
                            else
                            {
                                zm.col_start = j + 1 - size;
                            }
                            zm.size = size;
                            zmienneH.Add(zm);
                            zmienne.Add(zm);
                            notusedZ.Add(zm);
                        }
                        size = 0;
                    }
                   
                }
            }


           
        }

      
        public void restrictions() // restrykcje, zmienne, w krzyżujacych się miejsach muszą mieć te same litery
        {
            for (int i=0;i<zmienneH.Count;i++)
            {
                for(int j=0;j<zmienneV.Count;j++)
                {
                   if(zmienneH[i].row_start>=zmienneV[j].row_start &&  (zmienneV[j].row_start+zmienneV[j].size-1)>=zmienneH[i].row_start)
                    {
                        if(zmienneH[i].col_start<=zmienneV[j].col_start && zmienneV[j].col_start<=(zmienneH[i].col_start+zmienneH[i].size))
                        {
                           //Console.WriteLine("Horizontal " + zmienneH[i].row_start + " " + zmienneH[i].col_start + " " + (zmienneV[j].col_start - zmienneH[i].col_start));
                           // Console.WriteLine("Vertical " + zmienneV[j].row_start + " " + zmienneV[j].col_start + " " + (zmienneH[i].row_start - zmienneV[j].row_start));
                            zmienneH[i].ograniczenia.Add(new JolkaOgraniczenie(  zmienneH[i], zmienneV[j], zmienneH[i].row_start - zmienneV[j].row_start, zmienneV[j].col_start - zmienneH[i].col_start, false));
                           // Console.WriteLine("tutaj" +i +" "+j);
                            zmienneV[j].ograniczenia.Add(new JolkaOgraniczenie( zmienneH[i], zmienneV[j], zmienneH[i].row_start - zmienneV[j].row_start, zmienneV[j].col_start - zmienneH[i].col_start, true));


                        }
                    }
                   
                    


                }
            }

            notusedZ.Sort((x,y)=> y.ograniczenia.Count.CompareTo(x.ograniczenia.Count));

            //notusedZ.Shuffle();
            //notusedZ.Sort((x, y) => y.values.Count.CompareTo(x.values.Count));

            zmienne.Sort((x, y) => y.ograniczenia.Count.CompareTo(x.ograniczenia.Count));
            //zmienne.Shuffle();
            //zmienne.Sort((x, y) => y.values.Count.CompareTo(x.values.Count));

        }
        public bool checkAllRestr()
        {
            foreach(JolkaZmienna j in zmienne)
            {
                if(j.checkRestr()==false)
                {
                    return false;
                }
            }
            return true;
        }
        public bool checkAllRestrFC()
        {
            foreach (JolkaZmienna j in usedZ)
            {
                if (j.checkRestr() == false)
                {
                    return false;
                }
            }
            return true;
        }
        public void showZmienne()
        {
            foreach(JolkaZmienna z in zmienneH)
            {
                Console.WriteLine(z.size + " "+z.row_start+" "+z.col_start+ " " + z.vertical+" "+z.values.Count);
            }
            foreach (JolkaZmienna z in zmienneV)
            {
                Console.WriteLine(z.size+" "+z.row_start + " " + z.col_start + " "  +" " + z.vertical+" "+z.values.Count);
            }
        }

        public void showGrid()
        {
            char[,] grid=new char[cross.Count,cross[0].Length];
           for(int i=0; i<cross.Count;i++)
            {
                for (int j=0;j<cross[0].Length;j++)
                {
                    grid[i, j]= cross[i][j];
                }
            }

           foreach(JolkaZmienna h in zmienneH)
            {
                for (int i=0;i<h.size; i++)
                {
                    grid[h.row_start, h.col_start + i] = h.value[i];
                }
            }
            foreach (JolkaZmienna v in zmienneV)
            {
                for (int i = 0; i < v.size; i++)
                {
                    grid[v.row_start + i, v.col_start] = v.value[i];
                }
            }

            for (int i = 0; i < cross.Count; i++)
            {
                for (int j = 0; j < cross[0].Length; j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine();
            }

        }

    }
}
