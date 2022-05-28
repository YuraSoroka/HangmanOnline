using System.ComponentModel.DataAnnotations;

namespace HangmanOnline.Models
{
    public class Room
    {
        [Key]
        public string Id { get; set; }
        public string Word { get; set; }
        public Player? PlayerOne { get; set; }
        public Player? PlayerTwo { get; set; }
    }
}
