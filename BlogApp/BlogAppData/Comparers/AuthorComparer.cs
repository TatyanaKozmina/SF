using BlogApp.Data.Models;
using System.Diagnostics.CodeAnalysis;

namespace BlogApp.Data.Comparers
{
    public class AuthorComparer : IEqualityComparer<Author>
    {
        public bool Equals(Author? x, Author? y)
        {
            if (x == null && y == null)
                return true;
            else if ((x != null && y == null) ||
                    (x == null && y != null))
                return false;
            return x.FirstName.Equals(y.FirstName, StringComparison.OrdinalIgnoreCase) &&
               x.LastName.Equals(y.LastName, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode([DisallowNull] Author obj)
        {
            return new { obj.FirstName, obj.LastName }.GetHashCode();
        }
    }
}
