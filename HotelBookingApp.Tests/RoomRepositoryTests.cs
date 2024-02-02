using FluentAssertions;
using HotelBookingApp.Data;

namespace HotelBookingApp.Tests
{
    public class RoomRepositoryTests
    {

        [Fact]
        public void GetAllRooms_WhenCalled_ReturnsAllRooms()
        {
            var result = RoomRepository.GetAllRooms();

            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(12);
        }

        [Fact]
        public void GetAvailableRooms_WhenCalled_ReturnsOnlyAvailableRooms()
        {
            var result = RoomRepository.GetAvailableRooms();
            result.Should().OnlyContain(Room => Room.IsAvailable == true);
        }

        [Fact]
        public void GetSingleRooms_WhenCalled_ReturnsOnlySingleRooms()
        {
            var result = RoomRepository.GetSingleRooms();
            result.Should().OnlyContain(Room => Room.RoomType == "Single");
        }

        [Fact]
        public void GetDoubleRooms_WhenCalled_ReturnsOnlyDoubleRooms()
        {
            var result = RoomRepository.GetDoubleRooms();
            result.Should().OnlyContain(Room => Room.RoomType == "Double");
        }

        [Fact]
        public void GetSuiteRooms_WhenCalled_ReturnsOnlySuiteRooms()
        {
            var result = RoomRepository.GetSuiteRooms();
            result.Should().OnlyContain(Room => Room.RoomType == "Deluxe");
        }

        [Fact]
        public void GetPresidentialSuiteRooms_WhenCalled_ReturnsOnlyPresidentialSuiteRooms()
        {
            var result = RoomRepository.GetPresidentialSuiteRooms();
            result.Should().OnlyContain(Room => Room.RoomType == "Presidential Suite");
        }
    }
}