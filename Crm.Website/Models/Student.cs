using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Website.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        [Column("MiddleName")]
        public string MiddleName { get; set; }

        //[Required(ErrorMessage = "Phone number is required to confirm")]
        //[MinLength(12, ErrorMessage = "Minimum and maximum length should be 12 length like '998901234567'")]
        //[MaxLength(12, ErrorMessage = "Minimum and maximum length should be 12 length like '998901234567'")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required to confirm")]
        public string Email { get; set; }

        public Gender Gender { get; set; }

        public DateTimeOffset BirthDate { get; set; }
    }

}
