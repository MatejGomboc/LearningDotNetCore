using System.ComponentModel.DataAnnotations;

namespace WebAppApi.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(128)]
        public string Name { get; set; } = string.Empty;
    }
}