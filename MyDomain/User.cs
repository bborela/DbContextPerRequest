using System.ComponentModel.DataAnnotations;
using DataContext.Interfaces;

namespace MyDomain
{
    public class User : BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
