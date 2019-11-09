using System;

namespace DriverTracking.Entities
{
    public class AccidentReportRecords
    {
        public Guid Id { get; set; }
        public TripRecords TripRecords { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public Severity Severity { get; set; } = Severity.None;
    }

    public enum Severity
    {
        None,
        Low,
        Medium,
        High,
        Fatal
    }
}