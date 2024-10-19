using System.ComponentModel.DataAnnotations;

namespace Unit_test.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
