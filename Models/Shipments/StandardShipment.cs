using Assignment05OOP.Models.Relationships;

namespace Assignment05OOP.Models.Shipments
{
    public class StandardShipment : Shipment
    {
        public StandardShipment(string trackingCode, string description, double weight, decimal deliveryFee, DeliveryAddress address)
            : base(trackingCode, description, weight, deliveryFee, address)
        {
        }

        public StandardShipment(string trackingCode, string description, double weight, decimal deliveryFee, string street = "Main St", string city = "Cairo", string postalCode = "11511")
            : base(trackingCode, description, weight, deliveryFee, street, city, postalCode)
        {
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipment\n");
            base.PrintShipment();
        }
    }
}
