using BlogApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.DBContext
{
    public class BlogAppDBContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BlogAppDBContext(DbContextOptions<BlogAppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
