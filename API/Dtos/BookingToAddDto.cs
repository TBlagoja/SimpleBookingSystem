using Core.Entities;

namespace API.Dtos
{
    public class BookingToAddDto
    {
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int BookedQuantity { get; set; }
        public Resource Resource { get; set; }
        public int ResourceId { get; set; }
    }
}
