namespace Crm.Website.Models
{
    public class Registration
    {
        public Guid Id { get; set; }


        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }


        public Admin Admin { get; set; }
    }
}
