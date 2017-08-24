using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApp
{
    public class Book
    {
        //Auto-Propery

        public string Name { get; set; }
        

        public int Grade { get; set; }

        //Method
        //public int CalculatePrice(int unitPrice)
        //{
        //    return unitPrice * Grade;
        //}

        public int CalculatePrice(int unitPrice) => unitPrice * Grade;

        public string GetDetail()
        {
            //return "Name: " + Name + " Grade: " + Grade;
            //return string.Format("Name: {0} Grade: {1}", Name, Grade);
            return $"Name: {Name} - Grade: {Grade}";
        }
    }
}
