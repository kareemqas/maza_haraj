using Mazad_Haraj.Enums;

namespace Mazad_Haraj.Models
{
    public class Vechile
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public string Regional { get; set; }
        public TransmissionType Transmission { get; set; }
        public FuleType Fule { get; set; }
        public string Color { get; set; }
        public double Customs { get; set; }
        public string Licensim { get; set; }
        public InsuranceType Insurance { get; set; }
        public string Number { get; set; }
        public string Distance { get; set; }
        public string PreviousOwners { get; set; }
        public VechileStatus Status { get; set; }
        public string AccidentHistory { get; set; }
        public List<Image> Images { get; set; }
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }

    }
}