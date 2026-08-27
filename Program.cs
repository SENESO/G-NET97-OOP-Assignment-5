using Assignment05OOP.Models.Centers;
using Assignment05OOP.Models.Extensions;
using Assignment05OOP.Models.Helpers;
using Assignment05OOP.Models.Relationships;
using Assignment05OOP.Models.Shipments;
using Assignment05OOP.Models.Utilities;

namespace Assignment05OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01 - Theoretical Questions

            // Q1 a) What happens when you assign one object variable to another object variable?
            // - Only the reference address is copied, so both variables point to the same object in the heap.

            // Q1 b) Does assigning one object to another create a new object? Explain.
            // - No, it just copies the reference pointer; no new object is created in memory.

            // Q1 c) What is the difference between copying an object and copying its reference?
            // - Copying reference: Copies the pointer address; changes made through one variable affect the other.
            // - Copying object: Creates a new object on the heap with copied data; changes do not affect the original.

            // Q2 a) What is a Shallow Copy?
            // - Creates a new object, copies value types directly, and copies references for reference-type members (sharing nested objects).

            // Q2 b) What is a Deep Copy?
            // - Creates a new object and duplicates all nested reference-type objects, making it completely independent.

            // Q2 c) What happens to reference-type members when a Shallow Copy is created?
            // - Their reference addresses are copied, so the original and the copy point to the same inner objects.

            // Q2 d) What happens to reference-type members when a Deep Copy is created?
            // - New instances are created for the inner objects, so they do not share memory with the original.

            // Q2 e) Give one situation where Deep Copy would be safer than Shallow Copy.
            // - When updating nested data (like modifying DeliveryAddress) without wanting to change the original shipment.

            // Q3 a) What is a static field, and how is it different from an instance field?
            // - A static field belongs to the class and is shared by all instances, while an instance field is allocated per object.

            // Q3 b) What is a static method? Can a static method directly access instance members?
            // - A method that belongs to the class and is called using the class name. No, it cannot access instance members directly.

            // Q3 c) What is a static constructor, and when is it executed?
            // - A constructor used for static initialization. It executes automatically once before the first instance is created or any static member is accessed.

            // Q3 d) What is a static class? Can you create an object from a static class?
            // - A class that contains only static members. No, you cannot instantiate it with 'new'.

            // Q4 a) What is an Extension Method?
            // - A static method in a static class that can be called using instance syntax on the extended type.

            // Q4 b) What keyword must be used in the first parameter of an extension method?
            // - The 'this' keyword.

            // Q4 c) Where must an extension method be declared?
            // - In a non-nested static class.

            // Q4 d) Can an extension method access private members of the class it extends?
            // - No, it can only access public and accessible internal members.

            // Q5 a) What is a Partial Class?
            // - A class split across multiple .cs files in the same namespace using the 'partial' keyword.

            // Q5 b) Why would a developer split one class into multiple files?
            // - To organize large classes, enable multiple developers to work without conflicts, or separate auto-generated code.

            // Q5 c) What is a Partial Method?
            // - A method declared in one part of a partial class and optionally implemented in another part.

            // Q5 d) What happens if a declared partial method has no implementation?
            // - The compiler removes the method declaration and all calls to it during compilation, with zero runtime overhead.

            #endregion

            #region Part 02 - Practical

            DeliveryUtilities.PrintSystemTitle();
            Console.WriteLine();

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("1. Demonstration: Reference Assignment vs Actual Copy");
            DeliveryUtilities.PrintSeparator();

            Shipment originalShipment = new StandardShipment("SH100", "Electronics", 3.0, 50m, "10 Tahrir St", "Cairo", "11511");
            Shipment refAssignedShipment = originalShipment;

            Console.WriteLine($"Original Tracking Code : {originalShipment.TrackingCode} (Weight: {originalShipment.Weight} KG)");
            Console.WriteLine($"Ref Assigned Code      : {refAssignedShipment.TrackingCode} (Weight: {refAssignedShipment.Weight} KG)");
            Console.WriteLine($"Same Object in Memory? : {ReferenceEquals(originalShipment, refAssignedShipment)}");

            refAssignedShipment.Weight = 6.0;
            Console.WriteLine("\nAfter modifying refAssignedShipment.Weight = 6.0:");
            Console.WriteLine($"Original Weight        : {originalShipment.Weight} KG");
            Console.WriteLine($"Ref Assigned Weight    : {refAssignedShipment.Weight} KG");

            originalShipment.Weight = 3.0;
            Console.WriteLine();

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("2. Demonstration: Shallow Copy (MemberwiseClone)");
            DeliveryUtilities.PrintSeparator();

            Shipment shallowOriginal = new StandardShipment("SH200", "Books", 2.0, 40m, "10 Tahrir St", "Cairo", "11511");
            Shipment shallowCopied = shallowOriginal.ShallowCopy();

            Console.WriteLine($"Same Shipment Object?        : {ReferenceEquals(shallowOriginal, shallowCopied)}");
            Console.WriteLine($"Same DeliveryAddress Object? : {ReferenceEquals(shallowOriginal.Address, shallowCopied.Address)}");
            Console.WriteLine($"Before change - Original City: {shallowOriginal.Address.City} | Copied City: {shallowCopied.Address.City}");

            shallowCopied.Address.City = "Alexandria";
            Console.WriteLine("--> Changed copied address city to Alexandria");
            Console.WriteLine($"After change  - Original City: {shallowOriginal.Address.City} | Copied City: {shallowCopied.Address.City}\n");

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("3. Demonstration: Deep Copy");
            DeliveryUtilities.PrintSeparator();

            Shipment deepOriginal = new StandardShipment("SH300", "Laptops", 5.0, 90m, "10 Tahrir St", "Cairo", "11511");
            Shipment deepCopied = deepOriginal.DeepCopy();

            Console.WriteLine("Demonstration                     Original             Copied");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Before change                     {deepOriginal.Address.City,-20} {deepCopied.Address.City,-20}");

            deepCopied.Address.City = "Giza";
            Console.WriteLine($"After changing copied address     {deepOriginal.Address.City,-20} {deepCopied.Address.City,-20}");
            Console.WriteLine($"Same DeliveryAddress object?      {ReferenceEquals(deepOriginal.Address, deepCopied.Address),-20} {ReferenceEquals(deepOriginal.Address, deepCopied.Address),-20}\n");

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("4, 5, 6. Static Members");
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}\n");

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("7. Static Class (DeliveryUtilities)");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("DeliveryUtilities.PrintSeparator() and DeliveryUtilities.PrintSystemTitle() used.\n");

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("8. Extension Methods");
            DeliveryUtilities.PrintSeparator();

            Shipment extShipment = new StandardShipment("SH001", "Standard Parcel", 3.0, 50m, "10 Tahrir St", "Cairo", "11511");
            Console.WriteLine($"Summary      : {extShipment.GetSummary()}");
            Console.WriteLine($"Is Delivered?: {extShipment.IsDelivered()}");

            extShipment.TrackingStatus = "Delivered";
            Console.WriteLine($"After Status Update -> Is Delivered?: {extShipment.IsDelivered()}\n");

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("9 & 10. Partial Class & Partial Method");
            DeliveryUtilities.PrintSeparator();

            Shipment partialShipment = new StandardShipment("SH999", "Fragile Package", 2.5, 60m);
            Console.WriteLine($"Current Tracking Status: {partialShipment.GetTrackingStatus()}");
            Console.Write("Updating Tracking Status -> ");
            partialShipment.UpdateTrackingStatus("Out For Delivery");
            Console.WriteLine($"New Tracking Status    : {partialShipment.GetTrackingStatus()}\n");

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Assignment 04 System Functionality");
            DeliveryUtilities.PrintSeparator();

            Driver driver = new Driver(101, "Ahmed Mohamed", "01012345678");
            DeliveryCenter center = new DeliveryCenter(10);
            center.Driver = driver;

            StandardShipment standard = new StandardShipment(
                trackingCode: "SH001",
                description: "Laptop",
                weight: 3.0,
                deliveryFee: 80m,
                street: "10 Tahrir St",
                city: "Cairo",
                postalCode: "11511"
            );

            ExpressShipment express = new ExpressShipment(
                trackingCode: "SH002",
                description: "Mobile Phone",
                weight: 2.0,
                deliveryFee: 60m,
                extraFee: 30m,
                street: "25 Corniche Ave",
                city: "Alexandria",
                postalCode: "21500"
            );

            InternationalShipment international = new InternationalShipment(
                trackingCode: "SH003",
                description: "Television",
                weight: 8.0,
                deliveryFee: 120m,
                destinationCountry: "Germany",
                customsFee: 100m,
                street: "Friedrichstrasse 45",
                city: "Berlin",
                postalCode: "10117"
            );

            center.AddShipment(standard);
            center.AddShipment(express);
            center.AddShipment(international);

            center.PrintAllShipments();

            Console.WriteLine("Printing Using DeliveryHelper...\n");
            DeliveryHelper.PrintShipmentDetails(standard);
            DeliveryHelper.PrintShipmentDetails(express);
            DeliveryHelper.PrintShipmentDetails(international);

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Updating Weight...\n");

            Console.Write("Standard Shipment: ");
            standard.UpdateWeight(4.5);

            Console.Write("Express Shipment : ");
            express.UpdateWeight(2.0, 1.0);

            Console.WriteLine();

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Mixed Shipment Collection (Polymorphism)");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            Shipment[] mixedFleet = new Shipment[]
            {
                standard,
                express,
                international,
                new CompletedShipment("SH004", "Documents", 0.5, 30m, "Al-Ahram St", "Giza", "12556"),
                new PriorityInternationalShipment("SH005", "Medical Equipment", 12.0, 300m, "France", 250m)
            };

            foreach (Shipment s in mixedFleet)
            {
                Console.WriteLine($"-> [{s.TrackingCode}] Type: {s.GetType().Name} | Estimated Cost: {s.EstimatedCost} EGP");
            }
            Console.WriteLine();

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Demonstrating Sealed Class & Sealed Method");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            CompletedShipment completed = new CompletedShipment("SH004", "Medical Records", 1.0, 50m);
            Console.WriteLine($"[Sealed Class] CompletedShipment instantiated: {completed.TrackingCode}");

            PriorityInternationalShipment priority = new PriorityInternationalShipment("SH005", "Precision Tools", 5.0, 200m, "Japan", 180m);
            priority.GenerateCustomsReport();

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine($"Final Total Shipments Created: {Shipment.GetTotalShipmentsCreated()}");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Assignment 05 Executed Successfully!");
            DeliveryUtilities.PrintSeparator();

            #endregion
        }
    }
}
