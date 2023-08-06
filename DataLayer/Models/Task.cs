using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Task
    {
        [Key]
        public int? Id { get; set; }
        public string Title { get; set; }
        public bool Finished { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public int? Priority { get; set; }
        public User User { get; set; }

        public override string ToString()
        {
            return $"{Id.ToString() ?? "null"}: {Title} ({Finished})\n" +
                $"date: {Date?.ToString() ?? "null"}\n" +
                $"description: {Description ?? "null"}\n" +
                $"priority: {Priority?.ToString() ?? "null"}\n" +
                $"user: {User}";
        }
    }
}
