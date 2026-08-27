using Assignment05OOP.Models.Relationships;

namespace Assignment05OOP.Models.Shipments
{
    public class ExpressShipment : Shipment
    {
        public decimal ExtraFee { get; set; }

        public override decimal EstimatedCost => base.EstimatedCost + ExtraFee;

        public ExpressShipment(string trackingCode, string description, double weight, decimal deliveryFee, decimal extraFee, DeliveryAddress address)
            : base(trackingCode, description, weight, deliveryFee, address)
        {
            ExtraFee = extraFee;
        }

        public ExpressShipment(string trackingCode, string description, double weight, decimal deliveryFee, decimal extraFee, string street = "Express Way", string city = "Alexandria", string postalCode = "21500")
            : base(trackingCode, description, weight, deliveryFee, street, city, postalCode)
        {
            ExtraFee = extraFee;
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment\n");
            base.PrintShipment();
            Console.WriteLine($"Extra Fee       : {ExtraFee} EGP");
        }
    }
}
