using System.ComponentModel.DataAnnotations;

namespace Mazad.Models
{
    public class Bid
    {
        public int Id { get; set; }

        public int AuctionID { get; set; }
        public Auction Auction { get; set; }

        public decimal BidAmount { get; set; }
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }

        [Required]
        public DateTime BidDateTime { get; set; }
    }
}
