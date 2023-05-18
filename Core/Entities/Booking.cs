
namespace Core.Entities
{
    public class Booking : BaseEntity
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BookedQuantity { get; set; }
        public Resource Resource { get; set; }
        public int ResourceId { get; set; }
    }
}
