namespace DDD.API.Models
{
    public class CustomerCreateDTO
    {
        public CustomerCreateDTO(string firstName, string lastName, string? address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Address { get; set; }

    }
}
