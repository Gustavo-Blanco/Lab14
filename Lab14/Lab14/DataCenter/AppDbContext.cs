using Lab14.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab14.DataCenter
{
    public class AppDbContext : DbContext
    {
        readonly string _dbPath;

        public AppDbContext(string dbPath)
        {
            this._dbPath = dbPath;
        }     

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }

    }
}