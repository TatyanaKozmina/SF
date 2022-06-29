﻿namespace FirstApp
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }     
        public DateTime? HireDate { get; set; }

        //Навигационное свойство для книги
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
