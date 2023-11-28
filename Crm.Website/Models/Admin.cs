using System.ComponentModel.DataAnnotations;

namespace Crm.Website.Models
{
    public class Admin
    {
        [Required]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        [StringLengthAttribute(10, ErrorMessage = "Length should fall into 10 length")]
        public string PhoneNumber { get; set; }

        public string AdditionalPhoneNumber { get; set; }

        public Role Role { get; set; }

        [EmailAddress]
        public string Email { get; set; }


    }
}