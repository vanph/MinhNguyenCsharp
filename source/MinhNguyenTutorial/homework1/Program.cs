using System;
using System.Collections.Generic;
using Practice.Homework.Model;

namespace Practice.Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            
            //bai 2 min,max,avg of grade of book
            Console.WriteLine("Task 2 :");
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
            Console.WriteLine("Book List:");
            PrintBook(books);

            var minGrade = Min(books);
            var maxGrade = Max(books);

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

            Console.ReadLine();
        }


        private static void Task1()
        {
            Console.WriteLine("Input n = ");
            var input = Console.ReadLine();
            var n = int.Parse(input);
            var calculation = new Calculation();
            var sum = calculation.SumMultiplesOf3Or5(n);
            Console.WriteLine("Sum : " + sum);
        }
        
        private static void PrintBook(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book.GetDetail()); 
            }
        }

        
       private static int Min(List<Book> books)
        {
            if (books.Count == 0)
            {
                throw  new Exception("Cannot find min of empty book.");
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

        private static int Max(List<Book> books)
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
