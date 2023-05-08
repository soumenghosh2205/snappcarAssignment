﻿namespace Snappcar.API.RequestModels
{
    public class PricingRequest
    {
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
