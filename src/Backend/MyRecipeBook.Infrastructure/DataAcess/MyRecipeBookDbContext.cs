using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Infrastructure.DataAcess
{
    public class MyRecipeBookDbContext : DbContext
    {
        public MyRecipeBookDbContext(DbContextOptions options) : base(options)
        { 
        
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyRecipeBookDbContext).Assembly);
        }
    }
}
