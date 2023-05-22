using Core.Entities;
using Infrastructure.Data.Helpers;

namespace Core.Interface
{
    public interface IEmailService
    {
        public Task SendEmail(Booking booking);
    }
}
