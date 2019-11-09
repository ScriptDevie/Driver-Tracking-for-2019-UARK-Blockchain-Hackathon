using System;
using System.Collections.Generic;

namespace DriverTracking.Entities
{
    public class TripRecords
    {
        public Guid Id { get; set; }
        public Driver Driver { get; set; }
        public List<AccidentReportRecords> Accidents { get; set; } = new List<AccidentReportRecords>();
        public List<CitationRecords> Citations { get; set; } = new List<CitationRecords>();
        public List<HardBreakRecords> HardBreaks { get; set; } = new List<HardBreakRecords>();
        public DateTimeOffset Departure { get; set; }
        public DateTimeOffset Arrival { get; set; }
        public double MilesDriven { get; set; } = 0;
        public double WeighStationInfo { get; set; } = 0;
        public double CoinsEarned { get; set; } = 0;
    }
}