using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Username} ({Password})";
        }
    }
}
