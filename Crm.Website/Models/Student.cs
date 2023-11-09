namespace Crm.Website.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string MiddeName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Gender Gender { get; set; }

        public DateTimeOffset BirthDate { get; set; }
    }

}
