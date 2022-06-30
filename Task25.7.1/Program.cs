using FirstApp;

using (var db = new FirstApp.AppContext())
{
    #region Create Data
    await db.Users.AddRangeAsync(new User { Name = "Kate", Email = "kate@example.com", Role = "admin" },
                           new User { Name = "Mike", Email = "mike@example.com", Role = "user" },
                           new User { Name = "Alex", Email = "alex@example.com" },
                           new User { Name = "Olga", Email = "olga@example.com", Role = "user" },
                           new User { Name = "Max", Email = "max@example.com" },
                           new User { Name = "Lena", Email = "lena@example.com", Role = "user" });
    await db.SaveChangesAsync();

    await db.Books.AddRangeAsync(new Book { Author = "King", Title = "Misery", Genre = "horror", Year = 1987 },
                           new Book { Author = "King", Title = "Firestarter", Year = 1980 },
                           new Book { Author = "King", Title = "It", Genre = "horror", Year = 1986 },
                           new Book { Author = "Chandler", Title = "The big sleep", Genre = "crime", Year = 1939 },
                           new Book { Author = "Chandler", Title = "Playback", Genre = "crime" },
                           new Book { Author = "Shekley", Title = "Mindswap", Genre = "scifi", Year = 1965 },
                           new Book { Author = "Shekley", Title = "Dimension of Miracles", Genre = "scifi", Year = 1968 },
                           new Book { Author = "Иванов", Title = "Золото бунта", Genre = "приключения", Year = 2006 },
                           new Book { Author = "Иванов", Title = "Сердце пармы", Year = 2000 });
    await db.SaveChangesAsync();

    BookRepository br = new BookRepository(db);
    UserRepository ur = new UserRepository(db);

    // Пользователям выдают книжки
    br.GiveBook(ur.GetByName("Mike"), br.GetByAuthorTitle("King", "Misery"));
    br.GiveBook(ur.GetByName("Mike"), br.GetByAuthorTitle("Chandler", "Playback"));
    br.GiveBook(ur.GetByName("Mike"), br.GetByAuthorTitle("Иванов", "Сердце пармы"));
    br.GiveBook(ur.GetByName("Alex"), br.GetByAuthorTitle("King", "It"));
    br.GiveBook(ur.GetByName("Olga"), br.GetByAuthorTitle("Shekley", "Mindswap"));
    await db.SaveChangesAsync();

    #endregion Create Data

    #region Process Data
    // 1. Получить список книг определенного жанра и вышедших между определенными годами.
    var books = br.GetBooksGenreYearRange("horror", 1986, 2000);

    // 2. Получить количество книг определенного автора в библиотеке.
    int booksNum = br.GetBooksNumAuthor("Иванов");
    booksNum = br.GetBooksNumAuthor("sfsfwrtw");

    // 3. Получить количество книг определенного жанра в библиотеке.
    booksNum = br.GetBooksNumGenre("scifi");
    booksNum = br.GetBooksNumGenre("324253g34tg");

    // 4. Получить булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
    bool bookExists = br.BookExistsAuthorTitle("Chandler", "Playback");
    bookExists = br.BookExistsAuthorTitle("Chandler", "fdgegrhhj");

    // 5. Получить булевый флаг о том, есть ли определенная книга на руках у пользователя.
    bool bookTaken = br.BookTaken(br.GetByAuthorTitle("King", "Misery"));
    bookTaken = br.BookTaken(br.GetByAuthorTitle("sfwrwt", "Shining"));

    // 6. Получить количество книг на руках у пользователя.
    int userBooksNum = br.UserBooksNum(ur.GetByName("Alex"));
    userBooksNum = br.UserBooksNum(ur.GetByName("qwerty"));

    // 7. Получить последнюю вышедшую книгу.
    Book lastIssuedBook = br.GetLastIssuedBook();

    // 8. Получить список всех книг, отсортированный в алфавитном порядке по названию.
    var booksSortedTitle = br.GetBooksSortedTitle();

    // 9. Получить список всех книг, отсортированный в порядке убывания года их выхода.
    var booksSortedYear = br.GetBooksSortedYearDesc();

    #endregion Process Data
}