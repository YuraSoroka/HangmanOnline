using System.ComponentModel.DataAnnotations;

namespace HangmanOnline.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public byte Health { get; set; }
    }
}
