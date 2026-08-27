using Assignment05OOP.Models.Shipments;

namespace Assignment05OOP.Models.Extensions
{
    public static class ShipmentExtensions
    {
        public static string GetSummary(this Shipment shipment)
        {
            if (shipment == null) return string.Empty;

            string shipmentType = shipment switch
            {
                PriorityInternationalShipment => "Priority International",
                InternationalShipment => "International",
                ExpressShipment => "Express",
                StandardShipment => "Standard",
                CompletedShipment => "Completed",
                _ => "Standard"
            };

            return $"{shipment.TrackingCode} | {shipmentType} | {shipment.Weight} KG | {shipment.TrackingStatus}";
        }

        public static bool IsDelivered(this Shipment shipment)
        {
            if (shipment == null) return false;
            return string.Equals(shipment.TrackingStatus, "Delivered", StringComparison.OrdinalIgnoreCase);
        }
    }
}
