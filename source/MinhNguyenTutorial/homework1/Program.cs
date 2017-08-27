using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {// gioi han trong 1000
            Console.WriteLine("sum number : ");
            int tong = 0;
            for ( int i = 0; i < 1000; i++)
            {
                if (i % 5 == 0 || i % 3 == 0)
                {
                    tong = tong + i;
                }
            }
            Console.WriteLine("tong la : "+ tong);
            //tham so dau vao n
            Console.WriteLine("Nhap n = ");
            int n = int.Parse(Console.ReadLine());
            int tong1 = 0;
            for (int i = 0; i < n; i++)
            {
                if  (i % 5 == 0 || i % 3 == 0)
                {
         
                    tong1 = tong1 + i;
                }
            }
            Console.WriteLine("tong la : "+tong1);
           

            //bai 2 min,max,avg of grade of book
            Console.WriteLine("bai 2 :");
            var book1 = new Book { Name = "html", Grade = 4 };
            var book2 = new Book { Name = "css", Grade = 2 };
            var book3 = new Book { Name = "java", Grade = 9 };
            var book4 = new Book { Name = "c#", Grade = 2 };
            var book5 = new Book { Name = "sql", Grade = 6 };
            var book6 = new Book { Name = "matlap", Grade = 5 };
            var book7 = new Book { Name = "c", Grade = 9 };
            var book8 = new Book { Name = "c++", Grade = 3 };
            var book9 = new Book { Name = "engish", Grade = 7 };
            var book10 = new Book { Name = "asp", Grade = 3 };

            var books = new List<Book> { book1, book2, book3, book4, book5, book6, book7, book8, book9, book10 };
            Console.WriteLine("ban dau:");
            printbook(books);

            Console.ReadLine();
        }
        private static void printbook(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book.GetDetail()); 
            
            }
        }

        int imin = int.MaxValue;
       private static void min(List<Book> books)
        {
            foreach(var book in books)
            {
             
            }
        }

    }
}
