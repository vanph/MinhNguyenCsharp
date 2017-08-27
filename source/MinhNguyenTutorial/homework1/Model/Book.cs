namespace Practice.Homework.Model
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
