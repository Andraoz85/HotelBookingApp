namespace HotelBookingApp.Data
{
    public static class ReservationRepository
    {
        public static List<Reservation> Reservations = new();
        public static IEnumerable<Reservation> GetAllReservations() => Reservations;
        public static void AddReservation(int roomId, DateTime startDate, DateTime endDate)
        {
            var newReservation = new Reservation
            {
                RoomId = roomId,
                StartDate = startDate,
                EndDate = endDate
            };

            // Check if the room is available
            foreach (var reservation in Reservations)
            {
                if (reservation.RoomId == roomId &&
                    startDate < reservation.EndDate &&
                    endDate > reservation.StartDate)
                {
                    throw new InvalidOperationException("The room is not available for the selected date.");
                }
            }

            Reservations.Add(newReservation);
        }
        public static void CancelReservation(int roomId, DateTime startDate, DateTime endDate)
        {
            var reservationToRemove = Reservations.FirstOrDefault(r => r.RoomId == roomId &&
            r.StartDate == startDate &&
            r.EndDate == endDate);

            if (reservationToRemove != null)
            {
                Reservations.Remove(reservationToRemove);
            }
            else
            {
                throw new InvalidOperationException("Reservation not found");
            }
        }
    }
}
