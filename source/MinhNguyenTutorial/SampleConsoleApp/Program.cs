using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = a;
            b = 15;
            ////a? b?
            //Console.WriteLine(a);
            //Console.WriteLine(b);
            //Console.WriteLine("Sum:" + Add(a,100));

            
            var book1 = new Book {Name = "CSharp", Grade = 5};

            var book2 = new Book { Name = "Java", Grade = 6 };

            var book3 = new Book { Name = "C++", Grade = 8 };

            var books = new List<Book> {book1, book2, book3 };

            Console.WriteLine("Original:");

            PrintBooks(books);
            Console.WriteLine("After Changed:");

            foreach (var book in books)
            {
                book.Name = "Minh";
            }

            Console.WriteLine(book1.Name);

            Console.ReadLine();
        }

        private static void PrintBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book.GetDetail());
            }
        }

        //Method
        private static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
