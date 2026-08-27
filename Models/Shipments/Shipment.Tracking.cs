namespace Assignment05OOP.Models.Shipments
{
    public partial class Shipment
    {
        public string TrackingStatus { get; set; } = "In Transit";

        public string GetTrackingStatus()
        {
            return TrackingStatus;
        }

        public void UpdateTrackingStatus(string newStatus)
        {
            TrackingStatus = newStatus;
            OnTrackingStatusChanged(newStatus);
        }

        partial void OnTrackingStatusChanged(string newStatus);
    }
}
