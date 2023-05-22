using Core.Entities;

namespace API.Dtos
{
    public class BookingToAddDto
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BookedQuantity { get; set; }
        public Resource Resource { get; set; }
        public int ResourceId { get; set; }
    }
}
