namespace HotelBookingApp.Data
{
    public class Reservation
    {

        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Reservation(int roomId, DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
            {
                throw new ArgumentException("End date must be after start date.");
            }

            RoomId = roomId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
