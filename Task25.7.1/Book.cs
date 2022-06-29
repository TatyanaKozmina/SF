﻿namespace FirstApp
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string? Genre { get; set; }
        public int? Year { get; set; }
        public int? Quantity { get; set; }

        // Внешний ключ пользователя
        public int? UserId { get; set; }
        // Навигационное свойство
        public User User { get; set; }
    }
}
