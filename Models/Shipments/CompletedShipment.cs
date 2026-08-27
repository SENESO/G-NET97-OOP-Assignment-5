using Assignment05OOP.Models.Relationships;

namespace Assignment05OOP.Models.Shipments
{
    public sealed class CompletedShipment : Shipment
    {
        public DateTime CompletionDate { get; set; }

        public CompletedShipment(string trackingCode, string description, double weight, decimal deliveryFee, DeliveryAddress address, DateTime completionDate)
            : base(trackingCode, description, weight, deliveryFee, address)
        {
            CompletionDate = completionDate;
        }

        public CompletedShipment(string trackingCode, string description, double weight, decimal deliveryFee, string street = "Delivered Ave", string city = "Cairo", string postalCode = "11511")
            : base(trackingCode, description, weight, deliveryFee, street, city, postalCode)
        {
            CompletionDate = DateTime.Now;
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Completed Shipment (SEALED)\n");
            base.PrintShipment();
            Console.WriteLine($"Delivered On    : {CompletionDate:yyyy-MM-dd HH:mm:ss}");
        }
    }
}
