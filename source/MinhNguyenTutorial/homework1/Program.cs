using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Practice.Homework.Model;

namespace Practice.Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            // Task2Ver1();
            //Task2Ver2();
            
            var book1 = new Book { Name = "html", Grade = 4, Publisher = "NXB KHKT"};
            var book2 = new Book { Name = "css", Grade = 4, Publisher = ""};
            var lst = new List<Book> {book1, book2};

            PrintBooks(lst);
            
            Console.ReadLine();
        }

        private static void Task1()
        {
            Console.WriteLine("Input n = ");
            var input = Console.ReadLine();
            int number;
            bool success = int.TryParse(input, out number);
            if (!success)
            {
                Console.WriteLine("The input is not valid.");
            }
            else
            {
                var calculation = new Calculation();
                var sum = calculation.SumMultiplesOf3Or5(number);
                Console.WriteLine("Sum : " + sum);
            }           
        }
        private static void Task2Ver1()
        {
            Console.WriteLine("Task 2 :");
            var books = GetBooks();
            Console.WriteLine("Book List:");
            PrintBooks(books);

            var minGrade = MinBooks(books);
            var maxGrade = MaxBooks(books);

            Console.WriteLine($"Min: {minGrade}");
            Console.WriteLine($"Max:{maxGrade}");

            Console.WriteLine("Books have min grade:");
            foreach (var book in books)
            {
                if (book.Grade == minGrade)
                {
                    Console.WriteLine(book.GetDetail());
                }
            }
        }

        private static void Task2Ver2()
        {
            Console.WriteLine("Task 2 :");
            var books = GetBooks();
            Console.WriteLine("Book List:");
            PrintBooks(books);

            // var minGrade = books.Min(x => x.Grade);
            // Console.WriteLine($"Min: {minGrade}");
            // // LINQ to objects
            //var minBooks1 = books.Where(x => x.Grade == minGrade).ToList();
            // PrintBooks(minBooks1);
            // var minBooks2 = (from b in books where b.Grade == minGrade select b).ToList();
            // PrintBooks(minBooks2);

            var maxGrade = books.Max(c => c.Grade);
            Console.WriteLine($"Max : {maxGrade}");
            var maxBooks3 = books.Where(c => c.Grade == maxGrade).ToList();
            var maxBooks4 = (from d in books where d.Grade == maxGrade select d).ToList();
            PrintBooks(maxBooks3);
            PrintBooks(maxBooks4);
            //Order
            //Console.WriteLine("Books order by Grade Desc:");
            //PrintBooks(books.OrderByDescending(x => x.Grade).ThenBy(x=>x.Name).ToList());

            var avgGrade = books.Average(f => f.Grade);
            
            Console.WriteLine($"Avg :{avgGrade}");
            Console.WriteLine("list book > avg :");
            var list = books.Where(g => g.Grade > avgGrade).ToList();
            PrintBooks(list);

            Console.WriteLine(books.Sum(x => x.Grade)*1.0 / (books.Count));
        }

        private static List<Book> GetBooks()
        {
            var book1 = new Book { Name = "html", Grade = 4 };
            var book2 = new Book { Name = "css", Grade = 7 };
            var book3 = new Book { Name = "java", Grade = 9 };
            var book4 = new Book { Name = "c#", Grade = 7 };
            var book5 = new Book { Name = "sql", Grade = 6 };
            var book6 = new Book { Name = "matlap", Grade = 5 };
            var book7 = new Book { Name = "c", Grade = 9 };
            var book8 = new Book { Name = "c++", Grade = 3 };
            var book9 = new Book { Name = "engish", Grade = 7 };
            var book10 = new Book { Name = "asp", Grade = 3 };

            var books = new List<Book> { book1, book2, book3, book4, book5, book6, book7, book8, book9, book10};

            return books;
        }


        private static void PrintBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book.GetDetail());
            }
        }


        private static int MinBooks(List<Book> books)
        {
            if (books.Count == 0)
            {
                throw new Exception("Cannot find min of empty book.");
            }

            int imin = books[0].Grade;

            foreach (var book in books)
            {
                if (book.Grade < imin)
                {
                    imin = book.Grade;
                }
            }

            return imin;
        }

        private static int MaxBooks(List<Book> books)
        {
            if (books.Count == 0)
            {
                throw new Exception("Cannot find max of empty book.");
            }

            int max = books[0].Grade;

            foreach (var book in books)
            {
                if (book.Grade > max)
                {
                    max = book.Grade;
                }
            }

            return max;
        }

    }
}
