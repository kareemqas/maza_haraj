using Mazad.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mazad.Data
{
    public class HarajDbContext : IdentityDbContext<AppUser>
    {
        public HarajDbContext(DbContextOptions<HarajDbContext> options)
            : base(options)
        {
        }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Vechile> Vechiles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Message> Messages { get; set; }


    }
}