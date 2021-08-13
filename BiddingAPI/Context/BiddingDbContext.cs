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
        public DbSet<Alias> Aliases { get; set; }
        public DbSet<BidPrice> BidPrices { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CurrentValue>().HasData
             (               
                new CurrentValue { Id = 1, ProdId = 1, CurrentPrice = 1000 },
                new CurrentValue { Id = 2, ProdId = 2, CurrentPrice = 2000 },
                new CurrentValue { Id = 3, ProdId = 3, CurrentPrice = 150 },
                new CurrentValue { Id = 4, ProdId = 4, CurrentPrice = 5000 },
                new CurrentValue { Id = 5, ProdId = 5, CurrentPrice = 200 },
                new CurrentValue { Id = 6, ProdId = 1, CurrentPrice = 1500 },
                new CurrentValue { Id = 7, ProdId = 1, CurrentPrice = 2000 },
                new CurrentValue { Id = 8, ProdId = 2, CurrentPrice = 2100 },
                new CurrentValue { Id = 9, ProdId = 3, CurrentPrice = 160 },
                new CurrentValue { Id = 10, ProdId = 4, CurrentPrice = 5200 },
                new CurrentValue { Id = 11, ProdId = 3, CurrentPrice = 165 },
                new CurrentValue { Id = 12, ProdId = 1, CurrentPrice = 3000 }

             );

            builder.Entity<Alias>().HasData
             (
                new Alias { Id = 1, ProdId = 1, AliasId = 1, UserId = new Guid("facab1fe-5e83-4301-bd85-015ede8c9458") },
                new Alias { Id = 2, ProdId = 1, AliasId = 2, UserId = new Guid("0c278933-2e38-4e0a-ae31-c26b6769c869") },
                new Alias { Id = 3, ProdId = 2, AliasId = 1, UserId = new Guid("facab1fe-5e83-4301-bd85-015ede8c9458") },
                new Alias { Id = 4, ProdId = 3, AliasId = 1, UserId = new Guid("0933a144-762a-4290-af1a-435e19511232") },
                new Alias { Id = 5, ProdId = 4, AliasId = 1, UserId = new Guid("facab1fe-5e83-4301-bd85-015ede8c9458") },
                new Alias { Id = 6, ProdId = 3, AliasId = 2, UserId = new Guid("0c278933-2e38-4e0a-ae31-c26b6769c869") },
                new Alias { Id = 7, ProdId = 1, AliasId = 1, UserId = new Guid("facab1fe-5e83-4301-bd85-015ede8c9458") }

             );

            builder.Entity<BidPrice>().HasData
            (
                new BidPrice { Id = 1, ProdId = 1, BidValue = 500, AliasId = 1 },
                new BidPrice { Id = 2, ProdId = 1, BidValue = 500, AliasId = 2 },
                new BidPrice { Id = 3, ProdId = 2, BidValue = 100, AliasId = 1 },
                new BidPrice { Id = 4, ProdId = 3, BidValue = 10, AliasId = 1 },
                new BidPrice { Id = 5, ProdId = 4, BidValue = 200, AliasId = 1 },
                new BidPrice { Id = 6, ProdId = 3, BidValue = 5, AliasId = 2 },
                new BidPrice { Id = 7, ProdId = 1, BidValue = 1000, AliasId = 1 }

            );
        }
    }
}
