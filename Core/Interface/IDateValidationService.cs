using Core.Entities;
using Infrastructure.Data.Helpers;

namespace Core.Interface
{
    public interface IDateValidationService
    {
        Task<DateValidationResponse> ValidateDate(Booking booking);
    }
}
