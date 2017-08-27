using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    class Book
    {
        public string Name { get; set; }

        public int Grade { get ; set ;}
          public string GetDetail()
        {
            return $"Name : {Name} - Grade {Grade} ";
        }
    }
}
