using FluentAssertions;
using HotelBookingApp.Data;

namespace HotelBookingApp.Tests
{
    public class RoomRepositoryTests
    {

        [Fact]
        public void GetAllRooms_WhenCalled_ReturnsAllRooms()
        {
            // Given
            var room = RoomRepository.GetAllRooms();

            room.Should().NotBeNullOrEmpty();
            room.Should().HaveCount(12);
        }

        [Fact]
        public void GetAvailableRooms_WhenCalled_ReturnsOnlyAvailableRooms()
        {
            // Given
            var availableRooms = RoomRepository.GetAvailableRooms();

            // When and Then
            availableRooms.Should().OnlyContain(Room => Room.IsAvailable == true);
        }

        [Fact]
        public void GetSingleRooms_WhenCalled_ReturnsOnlySingleRooms()
        {
            var singleRooms = RoomRepository.GetSingleRooms();
            singleRooms.Should().OnlyContain(Room => Room.RoomType == "Single");
        }

        [Fact]
        public void GetDoubleRooms_WhenCalled_ReturnsOnlyDoubleRooms()
        {
            var room = RoomRepository.GetDoubleRooms();
            room.Should().OnlyContain(Room => Room.RoomType == "Double");
        }

        [Fact]
        public void GetSuiteRooms_WhenCalled_ReturnsOnlySuiteRooms()
        {
            var room = RoomRepository.GetSuiteRooms();
            room.Should().OnlyContain(Room => Room.RoomType == "Suite");
        }
    }
}