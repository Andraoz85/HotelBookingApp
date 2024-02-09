﻿namespace HotelBookingApp.Data
{
    public static class ReservationRepository
    {
        private static readonly List<Reservation> reservations = [];
        public static IEnumerable<Reservation> GetAllReservations() => reservations;
        public static Reservation AddReservation(int roomId, DateTime startDate, DateTime endDate)
        {
            // Check for overlapping reservations
            if (reservations.Any(r => r.RoomId == roomId &&
                                      startDate < r.EndDate &&
                                      endDate > r.StartDate))
            {
                throw new InvalidOperationException("The room is not available for the selected date.");
            }

            var newReservation = new Reservation(roomId, startDate, endDate);
            reservations.Add(newReservation);
            return newReservation;
        }

        public static void CancelReservation(int roomId, DateTime startDate, DateTime endDate)
        {
            var reservationToRemove = reservations.FirstOrDefault(r => r.RoomId == roomId &&
                                                                      r.StartDate == startDate &&
                                                                      r.EndDate == endDate);

            if (reservationToRemove != null)
            {
                reservations.Remove(reservationToRemove);
            }
            else
            {
                throw new InvalidOperationException("Reservation not found");
            }
        }



        // Method to clear reservations for testing purposes
        public static void ClearReservations()
        {
            reservations.Clear();
        }


        public static bool HasReservation(int roomId, DateTime startDate, DateTime endDate)
        {
            return reservations.Any(r => r.RoomId == roomId && !(endDate < r.StartDate || startDate > r.EndDate));
        }
    }
}
