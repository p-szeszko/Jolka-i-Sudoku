using System;
using System.Collections.Generic;
using System.Text;

namespace Lista2
{
    class JolkaZmienna
    {
        public int row_start;
        public int col_start;
        public int size;
        public bool vertical;
        public string value="";
       public List<string> values = new List<string>();
       public List<string> possiblevalues = new List<string>();
        public List<JolkaOgraniczenie> ograniczenia = new List<JolkaOgraniczenie>();


        public JolkaZmienna()
        {

        }
        public JolkaZmienna(int r, int c, int size,bool vertical)
        {
            row_start = r;
            col_start = c;
            this.size = size;
            this.vertical = vertical;
            

        }
      
       public void nextValue()
        {
            possiblevalues.Sort();
            possiblevalues.Reverse();
        }
        public void nextValueBT()
        {
            values.Sort();
            values.Reverse();
        }

        public bool checkRestr()
        {
            foreach(JolkaOgraniczenie restr in ograniczenia)
            {
                if(restr.check()==false)
                {
                    return false;
                }
            }
           return true;
        }
    }
}
