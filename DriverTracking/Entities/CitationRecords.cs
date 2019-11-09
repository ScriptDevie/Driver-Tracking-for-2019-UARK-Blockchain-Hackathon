using System;

namespace DriverTracking.Entities
{
    public class CitationRecords
    {
        public Guid Id { get; set; }
        public TripRecords TripRecords { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}