using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using SQLite.Net;

namespace Uangku_UWP
{
    class DBHelper : DbContext
     {
        
        public DbSet<Item> ListItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlite("Filename = DataUangku.db");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
          
            modelBuilder.Entity<Item>()
                .Property(b => b.itemId)
                .IsRequired();
        }
        
    }
}
