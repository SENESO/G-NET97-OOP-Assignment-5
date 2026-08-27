namespace Assignment05OOP.Models.Relationships
{
    public class DeliveryAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public DeliveryAddress(string street, string city, string postalCode)
        {
            Street = street;
            City = city;
            PostalCode = postalCode;
        }

        public override string ToString()
        {
            return $"{Street}, {City}, {PostalCode}";
        }
    }
}
