using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mazad.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Name { get; set; }

        public string MessageContent { get; set; }

        
    }
}
