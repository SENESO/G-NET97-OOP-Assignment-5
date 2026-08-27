using Assignment05OOP.Models.Relationships;

namespace Assignment05OOP.Models.Shipments
{
    public class InternationalShipment : Shipment
    {
        public string DestinationCountry { get; set; }
        public decimal CustomsFee { get; set; }

        public override decimal EstimatedCost => base.EstimatedCost + CustomsFee;

        public InternationalShipment(string trackingCode, string description, double weight, decimal deliveryFee, string destinationCountry, decimal customsFee, DeliveryAddress address)
            : base(trackingCode, description, weight, deliveryFee, address)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        public InternationalShipment(string trackingCode, string description, double weight, decimal deliveryFee, string destinationCountry, decimal customsFee, string street = "Airport Rd", string city = "Berlin", string postalCode = "10115")
            : base(trackingCode, description, weight, deliveryFee, street, city, postalCode)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment\n");
            base.PrintShipment();
            Console.WriteLine($"Destination     : {DestinationCountry}");
            Console.WriteLine($"Customs Fee     : {CustomsFee} EGP");
        }

        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine($"[Customs Report] Shipment {TrackingCode} destined for {DestinationCountry} | Customs Fee: {CustomsFee} EGP");
        }
    }
}
