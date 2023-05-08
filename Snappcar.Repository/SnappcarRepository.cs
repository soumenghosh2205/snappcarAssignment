using Snappcar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappcar.Repository
{
    public interface ISnappcarRepository
    {
        IEnumerable<Car> GetAllCars();
        Car GetCar(int id);
        IEnumerable<Booking> GetAllBookings();
        IEnumerable<Booking> GetCarBookings(int carId);
    }

    public class SnappcarRepository : ISnappcarRepository
    {
        private readonly SnappcarContext _context;

        public SnappcarRepository(SnappcarContext context)
        {
            _context = context;
            SeedCars();
            SeedBookings();
        }

        public IEnumerable<Car> GetAllCars() => _context.Cars;

        public Car GetCar(int id)
        {
            return _context.Cars.FirstOrDefault(car => car.Id == id);
        }

        public IEnumerable<Booking> GetAllBookings() => _context.Bookings;

        public IEnumerable<Booking> GetCarBookings(int carId)
        {
            return _context.Bookings.Where(b => b.CarId == carId);
        }

        private void SeedCars()
        {
            var cars = new List<Car>
            {
                new Car
                {
                    Id = 1,
                    Name = "VW Golf Plus",
                    PricePerDay = 25,
                    AvailableStartDate = new DateTime(year: 2023 , month: 5, day: 10),
                    AvailableEndDate = new DateTime(year: 2023 , month: 5, day: 17)
                },
                new Car
                {
                    Id = 2,
                    Name = "Skoda Octavia",
                    PricePerDay = 35,
                    AvailableStartDate = new DateTime(year: 2023 , month: 5, day: 8),
                    AvailableEndDate = new DateTime(year: 2023 , month: 8, day: 15)
                },
                new Car
                {
                    Id = 3,
                    Name = "BMW 330e",
                    PricePerDay = 60,
                    AvailableStartDate = new DateTime(year: 2023 , month: 5, day: 12),
                    AvailableEndDate = new DateTime(year: 2023 , month: 12, day: 25)
                }
            };
            _context.Cars.AddRange(cars);
            _context.SaveChanges();
        }

        private void SeedBookings()
        {
            var bookings = new List<Booking>
            {
                new Booking
                {
                    Id = 1,
                    UserId = 1,
                    CarId = 1,
                    BookingStartDate = new DateTime(year: 2023, month: 5, day: 20),
                    BookingEndDate = new DateTime(year: 2023, month: 5, day: 25)
                },

                new Booking
                {
                    Id = 2,
                    UserId = 2,
                    CarId = 2,
                    BookingStartDate = new DateTime(year: 2023, month: 5, day: 25),
                    BookingEndDate = new DateTime(year: 2023, month: 6, day: 5)
                },

                new Booking
                {
                    Id = 3,
                    UserId = 3,
                    CarId = 3,
                    BookingStartDate = new DateTime(year: 2023, month: 6, day: 6),
                    BookingEndDate = new DateTime(year: 2023, month: 6, day: 15)
                }
            };

            _context.Bookings.AddRange(bookings);
            _context.SaveChanges();
        }
    }
}
