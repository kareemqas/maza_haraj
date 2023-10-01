namespace Mazad_Haraj.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int VechileId { get; set; }
        public Vechile Vechile { get; set; }

    }
}
