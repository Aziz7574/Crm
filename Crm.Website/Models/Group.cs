namespace Crm.Website.Models
{
    public class Group
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset EndAt { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
