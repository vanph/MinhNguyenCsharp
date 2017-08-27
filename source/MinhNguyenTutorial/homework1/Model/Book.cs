namespace Practice.Homework.Model
{
    public class Book
    {
        public string Name { get; set; }
        public int Grade { get; set; }

        public string GetDetail()
        {
            return $"Name : {Name} - Grade {Grade} ";
        }
    }
}
