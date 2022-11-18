using DDD.Core.Entities;

namespace DDD.API.Models
{
    public class AddContactToCustomerDTO
    {
        public string CustomerID { get; set; } = null!;
        public ContactType Type { get; set; }
        public string Value { get; set; } = string.Empty;

    }
}
