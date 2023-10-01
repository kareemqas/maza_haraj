using Mazad_Haraj.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mazad_Haraj.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public double LowestPrice { get; set; }
        public string Place { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public double Tax { get; set; }
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
        public AuctionStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Bid> Bids { get; set; }

        [ForeignKey(nameof(Vechile))]
        public int AcutionId { get; set; }
        
        public Vechile Vechile { get; set; }
        
        public bool isprivate { get; set; }
        


        public Auction()
        {
            CreatedAt = DateTime.Now;
        }

    }
}
