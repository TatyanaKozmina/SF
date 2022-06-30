using FirstApp;

namespace FirstApp
{
    public class BookRepository
    {
        private static AppContext db;

        public BookRepository(AppContext context)
        {
            db = context;
        }

        public Book? GetById(int id)
        {
            return db.Books.Where(book => book.Id == id).FirstOrDefault();
        }

        public Book? GetByAuthorTitle(string author, string title)
        {
            return db.Books.Where(book => book.Author == author && book.Title == title).FirstOrDefault();
        }

        // Выдать книгу
        public void GiveBook(User user, Book book)
        {
            if (user == null || book == null)
                return;
            user.Books.Add(book);
        }

        public List<Book> GetAllBooks()
        {
            return db.Books.ToList();
        }

        async public void AddBookAsync(Book book)
        {
            await db.AddAsync(book);
            await db.SaveChangesAsync();
        }

        async public void DeleteBookAsync(Book book)
        {
            db.Remove(book);
            await db.SaveChangesAsync();
        }

        async public void ChangeYearAsync(int id, int year)
        {
            var book = db.Books.FirstOrDefault(book => book.Id == id);
            book.Year = year;
            await db.SaveChangesAsync();
        }

        // 1. Получить список книг определенного жанра и вышедших между определенными годами.
        public List<Book> GetBooksGenreYearRange(string genre, int minYear, int maxYear)
        {
            return db.Books.Where(b => b.Genre == genre && b.Year >= minYear && b.Year <= maxYear).ToList();
        }

        // 2. Получить количество книг определенного автора в библиотеке.
        public int GetBooksNumAuthor(string author)
        {
            return db.Books.Where(b => b.Author == author).Count();
        }

        // 3. Получить количество книг определенного жанра в библиотеке.
        public int GetBooksNumGenre(string genre)
        {
            return db.Books.Where(b => b.Genre == genre).Count();
        }

        // 4. Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        public bool BookExistsAuthorTitle(string author, string title)
        {
            return db.Books.Where(b => b.Author == author && b.Title == title).Any();
        }

        // 5. Получить булевый флаг о том, есть ли определенная книга на руках у пользователя.
        public bool BookTaken(Book book)
        {
            if(book == null)
                return false;
            else
                return db.Users.Where(u => u.Books.Contains(book)).Any();
        }

        // 6. Получить количество книг на руках у пользователя.
        public int UserBooksNum(User user)
        {
            if(user == null)
                return 0;
            else
                return db.Books.Where(b => b.UserId == user.Id).Count();            
        }

        // 7. Получить последнюю вышедшую книгу.
        public Book GetLastIssuedBook()
        {
            return db.Books.OrderBy(b => b.Year).Last();
        }

        // 8. Получить список всех книг, отсортированный в алфавитном порядке по названию.
        public List<Book> GetBooksSortedTitle()
        { 
            return db.Books.OrderBy(b => b.Title).ToList();
        }

        // 9. Получить список всех книг, отсортированный в порядке убывания года их выхода.
        public List<Book> GetBooksSortedYearDesc()
        {
            return db.Books.OrderByDescending(b => b.Year).ToList();
        }
    }
}
