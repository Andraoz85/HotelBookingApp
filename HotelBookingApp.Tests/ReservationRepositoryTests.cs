using FluentAssertions;
using HotelBookingApp.Data;

namespace HotelBookingApp.Tests
{
    public class ReservationRepositoryTests
    {
        public ReservationRepositoryTests()
        {
            // Clear the reservations list before each test
            ReservationRepository.ClearReservations();
        }

        [Fact]
        public void AddReservation_WithValidParameters_ShouldAddReservation()
        {
            // Given
            var roomId = 1;
            var startDate = DateTime.Today.AddDays(10);
            var endDate = startDate.AddDays(3);

            // When
            var result = ReservationRepository.AddReservation(roomId, startDate, endDate);

            // Then
            result.Should().NotBeNull();
            result.RoomId.Should().Be(roomId);
            result.StartDate.Should().Be(startDate);
            result.EndDate.Should().Be(endDate);
            ReservationRepository.GetAllReservations().Should().ContainSingle();
        }

        [Fact]
        public void CancelReservation_WhenReservationExists_ShouldRemoveReservation()
        {
            // Given
            int roomId = 1;
            var startDate = DateTime.Today.AddDays(10);
            var endDate = startDate.AddDays(3);
            var reservation = ReservationRepository.AddReservation(roomId, startDate, endDate);

            // When
            ReservationRepository.CancelReservation(roomId, startDate, endDate);

            // Then
            ReservationRepository.GetAllReservations().Should().NotContain(reservation);
        }

        [Fact]
        public void CancelReservation_WhenReservationDoesNotExist_ShouldThrowException()
        {
            // Given
            int roomId = 1;
            var startDate = DateTime.Today.AddDays(10);
            var endDate = startDate.AddDays(3);
            // No reservation is added

            // When
            Action act = () => ReservationRepository.CancelReservation(roomId, startDate, endDate);

            // Then
            act.Should().Throw<InvalidOperationException>().WithMessage("Reservation not found");
        }

        [Fact]
        public void AddReservation_WhenRoomIsNotAvailable_ShouldThrowException()
        {
            // Given
            int roomId = 1;
            var startDate = DateTime.Today.AddDays(10);
            var endDate = startDate.AddDays(3);
            ReservationRepository.AddReservation(roomId, startDate, endDate);

            // When
            Action act = () => ReservationRepository.AddReservation(roomId, startDate.AddDays(1), endDate.AddDays(1));

            // Then
            act.Should().Throw<InvalidOperationException>().WithMessage("The room is not available for the selected date.");
        }

        [Fact]
        public void IsRoomAvailable_WhenReservationExists_ShouldReturnFalse()
        {
            // Given
            ReservationRepository.ClearReservations();
            int roomId = 1;
            var startDate = DateTime.Today.AddDays(10);
            var endDate = startDate.AddDays(3);
            ReservationRepository.AddReservation(roomId, startDate, endDate);

            // When
            var isAvailable = ReservationRepository.IsRoomAvailable(roomId, startDate, endDate);

            // Then
            isAvailable.Should().BeFalse();
        }

        [Fact]
        public void IsRoomAvailable_WhenReservationDoesNotExist_ShouldReturnFalse()
        {
            // Given
            ReservationRepository.ClearReservations();
            int roomId = 1;
            var startDate = DateTime.Today.AddDays(10);
            var endDate = startDate.AddDays(3);
            // No reservation is added

            // When
            var isAvailable = ReservationRepository.IsRoomAvailable(roomId, startDate, endDate);

            // Then
            isAvailable.Should().BeTrue();
        }
        [Fact]
        public void AddReservation_ForAllreadyBookedRoom_ShouldNotAllowDoubleBooking()
        {
            // Given
            var roomId = 1;
            var startDate = DateTime.Today.AddDays(10);
            var endDate = startDate.AddDays(3);
            ReservationRepository.AddReservation(roomId, startDate, endDate);

            // When
            Action doubleBooking = () => ReservationRepository.AddReservation(roomId, startDate.AddDays(1), endDate.AddDays(1));

            // Then
            doubleBooking.Should().Throw<InvalidOperationException>().WithMessage("The room is not available for the selected date.");

        }

        [Fact]
        public void AddReservation_WhenStartsOnExistingReservationsEndDate_ShouldSucceed()
        {
            // Given
            int roomId = 1;
            var existingReservationEndDate = DateTime.Today.AddDays(10);
            ReservationRepository.AddReservation(roomId, DateTime.Today.AddDays(7), existingReservationEndDate);

            // When
            Action act = () => ReservationRepository.AddReservation(roomId, existingReservationEndDate, existingReservationEndDate.AddDays(3));

            // Then
            act.Should().NotThrow<InvalidOperationException>();
        }

        [Fact]
        public void AddReservation_StartDateAfterEndDate_ShouldThrowArgumentException()
        {
            // Given
            ReservationRepository.ClearReservations();
            int roomId = 1;
            var startDate = new DateTime(2024, 2, 10);
            var endDate = new DateTime(2024, 2, 8);

            // When
            Action act = () => ReservationRepository.AddReservation(roomId, startDate, endDate);

            // Then
            act.Should().Throw<ArgumentException>().WithMessage("End date must be after start date.");
        }
    }
}
