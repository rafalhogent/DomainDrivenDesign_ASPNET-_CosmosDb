
namespace DDD.Core.Entities
{
    public class Customer : BaseEntity
    {
        public Customer() { }

        public Customer(string firstname, string lastname, string? address = null)
        {
            FirstName = firstname;
            LastName = lastname;
            Address = address;
        }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Address { get; set; }

        public ICollection<Contact> Contacts = new List<Contact>();

    }
}