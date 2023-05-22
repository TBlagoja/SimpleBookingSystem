namespace Core.Helpers
{
    public class DateTimeRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTimeRange(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
