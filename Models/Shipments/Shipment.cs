using Assignment05OOP.Models.Relationships;

namespace Assignment05OOP.Models.Shipments
{
    public partial class Shipment : ICloneable
    {
        public static int TotalShipmentsCreated;

        public string TrackingCode { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public decimal DeliveryFee { get; set; }
        public DeliveryAddress Address { get; set; }

        public virtual decimal EstimatedCost => DeliveryFee + ((decimal)Weight * 5m);

        static Shipment()
        {
            TotalShipmentsCreated = 0;
            Console.WriteLine("Shipment System Initialized");
        }

        public Shipment(string trackingCode, string description, double weight, decimal deliveryFee, DeliveryAddress address)
        {
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Address = address;

            TotalShipmentsCreated++;
        }

        public Shipment(string trackingCode, string description, double weight, decimal deliveryFee, string street = "Main St", string city = "Cairo", string postalCode = "11511")
            : this(trackingCode, description, weight, deliveryFee, new DeliveryAddress(street, city, postalCode))
        {
        }

        public Shipment(Shipment other)
        {
            TrackingCode = other.TrackingCode;
            Description = other.Description;
            Weight = other.Weight;
            DeliveryFee = other.DeliveryFee;
            Address = other.Address != null ? new DeliveryAddress(other.Address.Street, other.Address.City, other.Address.PostalCode) : null!;
            TotalShipmentsCreated++;
        }

        public static int GetTotalShipmentsCreated()
        {
            return TotalShipmentsCreated;
        }

        public Shipment CopyShipment()
        {
            return (Shipment)MemberwiseClone();
        }

        public Shipment ShallowCopy()
        {
            return (Shipment)MemberwiseClone();
        }

        public Shipment DeepCopy()
        {
            Shipment copy = (Shipment)MemberwiseClone();
            if (Address != null)
            {
                copy.Address = new DeliveryAddress(Address.Street, Address.City, Address.PostalCode);
            }
            return copy;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        partial void OnTrackingStatusChanged(string newStatus)
        {
            Console.WriteLine($"Tracking status changed to: {newStatus}");
        }

        public void UpdateWeight(double newWeight)
        {
            Weight = newWeight;
            Console.WriteLine($"Weight updated to {Weight} KG.");
        }

        public void UpdateWeight(double newWeight, double extraPackingWeight)
        {
            Weight = newWeight + extraPackingWeight;
            Console.WriteLine($"Weight updated to {Weight} KG (Base: {newWeight} KG + Packing: {extraPackingWeight} KG).");
        }

        public virtual void PrintShipment()
        {
            Console.WriteLine($"Tracking Code   : {TrackingCode}");
            Console.WriteLine($"Description     : {Description}");
            Console.WriteLine($"Weight          : {Weight} KG");
            Console.WriteLine($"Delivery Fee    : {DeliveryFee} EGP");
            Console.WriteLine($"Estimated Cost  : {EstimatedCost} EGP");
            Console.WriteLine($"Address         : {Address}");
            Console.WriteLine($"Tracking Status : {TrackingStatus}");
        }

        public override string ToString()
        {
            return $"{TrackingCode} - {Description} ({Weight} KG) -> {Address} [{TrackingStatus}]";
        }
    }
}
