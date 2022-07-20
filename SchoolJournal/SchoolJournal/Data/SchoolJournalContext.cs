using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolJournal.Models;

namespace SchoolJournal.Data
{
    public class SchoolJournalContext : DbContext
    {
        public SchoolJournalContext (DbContextOptions<SchoolJournalContext> options)
            : base(options)
        {
        }

        public DbSet<SchoolJournal.Models.Stream> Stream { get; set; } = default!;
    }
}
