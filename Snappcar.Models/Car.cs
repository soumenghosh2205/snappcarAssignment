namespace Snappcar.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
        public double PricePerDay { get; set; }
        public DateTime AvailableStartDate { get; set; }
        public DateTime AvailableEndDate { get; set; }
    }
}
