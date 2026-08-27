using Assignment05OOP.Models.Relationships;
using Assignment05OOP.Models.Shipments;
using Assignment05OOP.Models.Utilities;

namespace Assignment05OOP.Models.Centers
{
    public class DeliveryCenter
    {
        private Shipment[] _shipments;
        private int _count;

        public Driver? Driver { get; set; }
        public int Count => _count;
        public int Capacity => _shipments.Length;

        public DeliveryCenter(int capacity = 10)
        {
            _shipments = new Shipment[capacity > 0 ? capacity : 10];
            _count = 0;
        }

        public Shipment? this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    return null;
                return _shipments[index];
            }
            set
            {
                if (index >= 0 && index < _count && value != null)
                {
                    _shipments[index] = value;
                }
            }
        }

        public Shipment? this[string trackingCode]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(trackingCode))
                    return null;

                for (int i = 0; i < _count; i++)
                {
                    if (string.Equals(_shipments[i].TrackingCode, trackingCode, StringComparison.OrdinalIgnoreCase))
                        return _shipments[i];
                }
                return null;
            }
        }

        public void AddShipment(Shipment? shipment)
        {
            if (shipment == null) return;

            if (_count == _shipments.Length)
            {
                Array.Resize(ref _shipments, _shipments.Length * 2);
            }

            _shipments[_count++] = shipment;
        }

        public bool RemoveShipment(string trackingCode)
        {
            if (string.IsNullOrWhiteSpace(trackingCode)) return false;

            int foundIndex = -1;
            for (int i = 0; i < _count; i++)
            {
                if (string.Equals(_shipments[i].TrackingCode, trackingCode, StringComparison.OrdinalIgnoreCase))
                {
                    foundIndex = i;
                    break;
                }
            }

            if (foundIndex == -1) return false;

            for (int i = foundIndex; i < _count - 1; i++)
            {
                _shipments[i] = _shipments[i + 1];
            }

            _shipments[--_count] = null!;
            return true;
        }

        public void PrintAllShipments()
        {
            DeliveryUtilities.PrintSystemTitle();
            Console.WriteLine();

            if (Driver != null)
            {
                Console.WriteLine($"Driver : {Driver.FullName}\n");
            }
            else
            {
                Console.WriteLine("Driver : [No Driver Assigned]\n");
            }

            Console.WriteLine("-----------------------------------------\n");

            for (int i = 0; i < _count; i++)
            {
                _shipments[i].PrintShipment();
                Console.WriteLine("\n-----------------------------------------\n");
            }
        }
    }
}
