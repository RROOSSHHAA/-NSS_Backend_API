using System.ComponentModel.DataAnnotations;

namespace NSS_API.Models
{
    public class ClassRoom
    {
        [Key] // Ye Primary Key hai
        public int Id { get; set; }

        [Required]
        public string ClassName { get; set; } = string.Empty;

        public string Section { get; set; } = string.Empty;

        // Agar tumne Students se connect kiya hai toh:
        // public List<User> Students { get; set; } = new List<User>();
    }
}