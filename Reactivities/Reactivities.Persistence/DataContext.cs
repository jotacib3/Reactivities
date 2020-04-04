using Microsoft.EntityFrameworkCore;
using Reactivities.Domain;
using System;

namespace Reactivities.Persistence
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options): base(options) { }

        public DbSet<Value> Values { get; set; }
    }
}
