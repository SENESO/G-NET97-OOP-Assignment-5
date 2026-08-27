using Assignment05OOP.Models.Relationships;

namespace Assignment05OOP.Models.Shipments
{
    public class PriorityInternationalShipment : InternationalShipment
    {
        public PriorityInternationalShipment(string trackingCode, string description, double weight, decimal deliveryFee, string destinationCountry, decimal customsFee, DeliveryAddress address)
            : base(trackingCode, description, weight, deliveryFee, destinationCountry, customsFee, address)
        {
        }

        public PriorityInternationalShipment(string trackingCode, string description, double weight, decimal deliveryFee, string destinationCountry, decimal customsFee, string street = "Diplomatic Quarter", string city = "London", string postalCode = "SW1A 1AA")
            : base(trackingCode, description, weight, deliveryFee, destinationCountry, customsFee, street, city, postalCode)
        {
        }

        public sealed override void GenerateCustomsReport()
        {
            Console.WriteLine($"[PRIORITY Customs Report - SEALED] Fast-Track customs cleared for {TrackingCode} to {DestinationCountry} | Priority Fee included.");
        }
    }
}
