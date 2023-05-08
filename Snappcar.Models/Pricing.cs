namespace Snappcar.Models
{
    public class Pricing
    {
        public int Id { get; private set; }
        public double RentalPrice { get; set; }
        public int TotalDays { get; set; }
        public double Discount { get; set; }
        public double Insurance { get; set; }
        public double ServiceFee { get; set; }
        public double WeekendSurcharge { get; set; }
        public double TotalPrice
        {
            get
            {
                return RentalPrice + Insurance + ServiceFee + WeekendSurcharge - Discount;
            }
        }
    }
}