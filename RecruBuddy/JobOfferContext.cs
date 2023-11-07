using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruBuddy
{
    public class JobOfferContext : DbContext
    {
        //    public JobOfferContext(DbContextOptions<JobOfferContext> options)
        //: base(options) { }

        public DbSet<JobOffer> JobOffers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=JobOfferDb;Trusted_Connection=True;"
            );
        }
    }
}
