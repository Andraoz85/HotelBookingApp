using FluentAssertions;
using HotelBookingApp.Data;

namespace HotelBookingApp.Tests
{
    public class ReservationRepositoryTests
    {
        public ReservationRepositoryTests()
        {
            // Clear the reservations list before each test
            ReservationRepository.Reservations.Clear();
        }

        [Fact]
        public void AddReservation_WithValidParameters_ShouldAddReservation()
        {
            // Given
            var roomId = 1;
            var startDate = DateTime.Today.AddDays(10);
            var endDate = startDate.AddDays(3);

            // When
            ReservationRepository.AddReservation(roomId, startDate, endDate);

            // Then
            var reservation = ReservationRepository.Reservations.Single(r => r.RoomId == roomId);
            reservation.Should().NotBeNull();
            reservation.StartDate.Should().Be(startDate);
            reservation.EndDate.Should().Be(endDate);
        }

        [Fact]
        public void CancelReservation_WhenReservationExists_ShouldRemoveReservation()
        {
            // Given
            int roomId = 1;
            var startDate = DateTime.Today.AddDays(10);
            var endDate = startDate.AddDays(3);
            ReservationRepository.AddReservation(roomId, startDate, endDate);

            // When
            ReservationRepository.CancelReservation(roomId, startDate, endDate);

            // Then
            ReservationRepository.Reservations.Should().NotContain(reservation =>
            reservation.RoomId == roomId &&
            reservation.StartDate == startDate &&
            reservation.EndDate == endDate);
        }

        [Fact]
        public void AddReservation_WhenRoomIsNotAvailable_ShouldThrowException()
        {
            // Given
            int roomId = 1;
            var startDate = DateTime.Today.AddDays(10);
            var endDate = startDate.AddDays(3);

            // Room 1 is already booked for these dates
            ReservationRepository.Reservations.Add(new Reservation { RoomId = roomId, StartDate = startDate, EndDate = endDate });

            // When
            Action act = () => ReservationRepository.AddReservation(roomId, startDate.AddDays(1), endDate.AddDays(1));

            // Then
            act.Should().Throw<InvalidOperationException>().WithMessage("*The room is not available for the selected date.*");
        }

    }
}
