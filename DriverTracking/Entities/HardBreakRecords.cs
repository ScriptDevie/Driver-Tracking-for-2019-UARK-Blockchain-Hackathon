using System;

namespace DriverTracking.Entities
{
    public class HardBreakRecords
    {
        public Guid Id { get; set; }
        public TripRecords TripRecords { get; set; }
        public int NumberOfHardBreaks { get; set; } = 0;
    }
}