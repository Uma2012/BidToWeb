using BiddingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingAPI.Context
{
    public class BiddingDbContext:DbContext
    {
        public BiddingDbContext(DbContextOptions<BiddingDbContext> options):base(options)
        {
            base.Database.Migrate();
        }
        public DbSet<CurrentValue> Currentvalue { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CurrentValue>().HasData
             (               
                new CurrentValue { Id = 1, ProdId = 1, CurrentPrice = 1000 },
                new CurrentValue { Id = 2, ProdId = 2, CurrentPrice = 2000 },
                new CurrentValue { Id = 3, ProdId = 3, CurrentPrice = 150 },
                new CurrentValue { Id = 4, ProdId = 4, CurrentPrice = 5000 },
                new CurrentValue { Id = 5, ProdId = 5, CurrentPrice = 200 }

             );
        }
    }
}
