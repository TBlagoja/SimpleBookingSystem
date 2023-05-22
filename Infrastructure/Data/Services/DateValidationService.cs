using Core.Entities;
using Core.Helpers;
using Core.Interface;
using Infrastructure.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Services
{
    public class DateValidationService : IDateValidationService
    {
        private readonly ApplicationContext _context;

        public DateValidationService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<DateValidationResponse> ValidateDate(Booking booking)
        {
            var foundBookings = await _context.Bookings
                               .Include(x => x.Resource)
                               .Where(x => x.ResourceId == booking.ResourceId)
                               .ToListAsync();

            if (foundBookings.Count > 0)
            {
                if (IsDateRangeWithin(booking.DateFrom, booking.DateTo, foundBookings))
                {
                    return new DateValidationResponse
                    {
                        IsValid = false,
                        ValidationErrorMessage = "Choosen time range has already been booked"
                    };
                }
                var bookedResource = await _context.Resources.SingleOrDefaultAsync(x => x.Id == booking.ResourceId);

                if (bookedResource.Quantity >= booking.BookedQuantity && bookedResource.Quantity > 0)
                {
                    bookedResource.Quantity = bookedResource.Quantity - booking.BookedQuantity;
                    _context.SaveChanges();

                    return new DateValidationResponse
                    {
                        IsValid = true,
                        ValidationErrorMessage = ""
                    };
                }
                else
                {
                    return new DateValidationResponse
                    {
                        IsValid = false,
                        ValidationErrorMessage = "There is not enough quantity for resource"
                    };
                }

            }
            else
            {
                var bookedResource = await _context.Resources.SingleOrDefaultAsync(x => x.Id == booking.ResourceId);

                if (bookedResource.Quantity >= booking.BookedQuantity)
                {
                    bookedResource.Quantity = bookedResource.Quantity - booking.BookedQuantity;
                    _context.SaveChanges();

                    return new DateValidationResponse
                    {
                        IsValid = true,
                        ValidationErrorMessage = ""
                    };
                }
                else
                {
                    return new DateValidationResponse
                    {
                        IsValid = false,
                        ValidationErrorMessage = "There is not enough quantity for resource"
                    };
                }
                
            }
        }


        private bool IsDateRangeWithin(DateTime start1, DateTime end1, List<Booking> bookings)
        {
            for (var i = 0; i < bookings.Count; i++)
            {
                if (bookings[i].DateFrom >= start1 && bookings[i].DateTo <= end1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
