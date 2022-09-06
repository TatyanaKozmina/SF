using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Queries
{
    public class UpdateTagQuery
    {
        public string NewText { get; }

        public UpdateTagQuery(string newText = null)
        {
            NewText = newText;
        }
    }
}
