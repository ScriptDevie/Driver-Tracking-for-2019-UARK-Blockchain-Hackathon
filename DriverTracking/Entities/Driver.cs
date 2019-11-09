using System;
using System.Collections.Generic;

namespace DriverTracking.Entities
{
    public class Driver
    {
        public Guid Id { get; set; }
        public List<TripRecords> TripRecords { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double TotalCoins { get; set; }
    }
}