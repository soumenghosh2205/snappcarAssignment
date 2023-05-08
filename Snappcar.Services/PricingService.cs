using Snappcar.Models;
using Snappcar.Repository;
using Snappcar.Services.Extensions;

namespace Snappcar.Services
{
    public interface IPricingService
    {
        Pricing GetPricings(Car car, DateTime startDate, DateTime endDate);
    }

    public class PricingService : IPricingService
    {
        private readonly ISnappcarRepository _snappcarRepository;

        public PricingService(ISnappcarRepository snappcarRepository)
        {
            _snappcarRepository = snappcarRepository;
        }

        public Pricing GetPricings(Car car, DateTime startDate, DateTime endDate)
        {
            var carDetails = _snappcarRepository.GetCar(car.Id);
            if (carDetails == null)
            {
                throw new Exception("Car does not exist");
            }

            if (!IsCarAvailableForGivenDates(carDetails, startDate, endDate))
            {
                throw new Exception("Car is not available on the provided dates");
            }

            // pricing details
            var totalDays = ((int)(endDate - startDate).TotalDays);
            var rentalPrice = carDetails.PricePerDay * totalDays;
            var insurance = rentalPrice * Constants.INSURANCE_PERCENTAGE / 100;
            var serviceFee = rentalPrice * Constants.SERVICE_FEE_PERCENTAGE / 100;
            var totalWeekendDays = Constants.CalculateWeekends(startDate, endDate);
            var weekendSurcharge = carDetails.PricePerDay * Constants.WEEKEND_SURCHARGE_PERCENTAGE / 100 * totalWeekendDays;
            var discount = totalDays > 3 ? rentalPrice * Constants.DISCOUNT_PERCENTAGE / 100 : 0;

            return new Pricing
            {
                RentalPrice = rentalPrice,
                TotalDays = totalDays,
                Insurance = insurance,
                ServiceFee = serviceFee,
                WeekendSurcharge = weekendSurcharge,
                Discount = discount
            };
        }

        private bool IsCarAvailableForGivenDates(Car carDetails, DateTime startDate, DateTime endDate)
        {
            var areDatesInValidRange = startDate.InRange(carDetails.AvailableStartDate, carDetails.AvailableEndDate)
                && endDate.InRange(carDetails.AvailableStartDate, carDetails.AvailableEndDate);

            if (!areDatesInValidRange)
            {
                return false;
            }

            var carBookings = _snappcarRepository.GetCarBookings(carDetails.Id);
            var isCarAlreadyBooked = carBookings.Any(carBooking =>
            startDate.InRange(carBooking.BookingStartDate, carBooking.BookingEndDate)
            ||
            endDate.InRange(carBooking.BookingStartDate, carBooking.BookingEndDate));

            return !isCarAlreadyBooked;
        }
    }
}
