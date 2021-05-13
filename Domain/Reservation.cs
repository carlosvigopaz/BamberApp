using System;

namespace Domain
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public string House { get; set; }
        public string Guests { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}