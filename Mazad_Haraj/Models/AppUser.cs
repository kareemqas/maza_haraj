using Microsoft.AspNetCore.Identity;

namespace Mazad.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string City { get; set; }
        public string Bio { get; set; }
        public string Type { get; set; }
        public string IdNumber { get; set; }
        public string IdPhoto { get; set; }
        public string BankNumber { get; set; }
        public string WhatsAppNumber { get; set; }
        public List<Bid> Bids { get; set; }
        public List<Auction> Auctions { get; set; }
        

    }
}
