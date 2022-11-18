namespace DDD.Core.Entities
{
    public enum ContactType
    {
        Email, GSM
    }
    public class Contact : BaseEntity
    {
        public Contact() { }

        public Contact(ContactType type, string contactValue) : base()
        {
            Type = type;
            Value = contactValue;
        }

        public ContactType Type { get; set; }
        public string Value { get; set; } = null!;




    }
}