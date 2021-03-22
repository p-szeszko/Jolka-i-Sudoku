using System;
using System.Collections.Generic;
using System.Text;

namespace Lista2
{
    class JolkaOgraniczenie
    {
     public   JolkaZmienna horizontal;
      public JolkaZmienna vertical;
       public int row_shift; //vertical
       public int col_shift; //horizontal
      public  bool vert;
        public  JolkaOgraniczenie(  JolkaZmienna h,  JolkaZmienna v , int r, int c, bool vert)
            {
            horizontal = h;
            vertical = v;
            row_shift = r;
            col_shift = c;
            this.vert = vert;
            //Console.WriteLine("Horyzontalna:"+h.row_start + " " + h.col_start + " " + col_shift);
           // Console.WriteLine("Wertykalna: "+v.row_start + " " + v.col_start + " " + row_shift);
            }

        public bool check()
        {

            if(horizontal.value.Equals("") || vertical.value.Equals(""))
            {
                
                return true;
            }
            //Console.WriteLine(horizontal.row_start + " " + horizontal.col_start);
            //Console.WriteLine(vertical.row_start + " " + vertical.col_start);
           // Console.WriteLine(horizontal.value + " " + col_shift + ":" + vertical.value + " " + row_shift);
            //Console.WriteLine(horizontal.value+" "+horizontal.value[col_shift]+ ":"+ vertical.value +" "+vertical.value[row_shift]);
            return horizontal.value[col_shift] == vertical.value[row_shift];
        }


    }
}
