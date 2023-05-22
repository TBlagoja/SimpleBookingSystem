using Core.Entities;
using Core.Interface;

namespace Infrastructure.Data.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmail(Booking booking)
        {
            string email = $"Email SENT TO admin@admin.com FOR CREATED BOOKING WITH ID  {booking.Id}";
            await Console.Out.WriteLineAsync(email);
        }
    }
}
