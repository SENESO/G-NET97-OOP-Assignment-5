using Assignment05OOP.Models.Shipments;

namespace Assignment05OOP.Models.Helpers
{
    public static class DeliveryHelper
    {
        public static void PrintShipmentDetails(Shipment shipment)
        {
            if (shipment == null) return;

            string shipmentType = shipment switch
            {
                PriorityInternationalShipment => "Priority International Shipment",
                InternationalShipment => "International Shipment",
                ExpressShipment => "Express Shipment",
                StandardShipment => "Standard Shipment",
                CompletedShipment => "Completed Shipment",
                _ => "Shipment"
            };

            Console.WriteLine($"{shipmentType} Printed Successfully.\n");
        }
    }
}
