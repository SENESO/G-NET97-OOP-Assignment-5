namespace Assignment05OOP.Models.Relationships
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public Driver(int driverId, string fullName, string phoneNumber)
        {
            DriverId = driverId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"Driver ID: {DriverId} | Name: {FullName} | Phone: {PhoneNumber}";
        }
    }
}
