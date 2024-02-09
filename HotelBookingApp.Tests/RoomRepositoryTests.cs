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
            RoomRepository.ClearRooms();
            RoomRepository.AddRoom(new Room
            {
                Id = 1,
                RoomNumber = 101,
                IsAvailable = true,
                Price = 100,
                RoomType = "Single"
            });

            // When
            var rooms = RoomRepository.GetAllRooms();

            // Then
            rooms.Should().NotBeNullOrEmpty();
            rooms.Should().HaveCount(1);
        }

        [Fact]
        public void GetAvailableRooms_WhenCalled_ReturnsOnlyAvailableRooms()
        {
            // Given
            RoomRepository.ClearRooms();
            RoomRepository.AddRoom(new Room
            {
                Id = 1,
                RoomNumber = 101,
                IsAvailable = true,
                Price = 100,
                RoomType = "Single"
            });
            RoomRepository.AddRoom(new Room
            {
                Id = 2,
                RoomNumber = 102,
                IsAvailable = false,
                Price = 100,
                RoomType = "Double"

            });

            //When
            var availableRooms = RoomRepository.GetAvailableRooms();

            // Then
            availableRooms.Should().HaveCount(1);
            availableRooms.All(r => r.IsAvailable).Should().BeTrue();
        }

        [Fact]
        public void GetSingleRooms_WhenCalled_ReturnsOnlySingleRooms()
        {
            // Given
            RoomRepository.ClearRooms();
            RoomRepository.AddRoom(new Room
            {
                Id = 1,
                RoomNumber = 101,
                IsAvailable = true,
                Price = 100,
                RoomType = "Single"
            });
            RoomRepository.AddRoom(new Room
            {
                Id = 2,
                RoomNumber = 102,
                IsAvailable = true,
                Price = 100,
                RoomType = "Double"
            });

            // When
            var singleRooms = RoomRepository.GetSingleRooms();

            // then
            singleRooms.Should().HaveCount(1);
            singleRooms.All(r => r.RoomType == "Single").Should().BeTrue();
        }

        [Fact]
        public void GetDoubleRooms_WhenCalled_ReturnsOnlyDoubleRooms()
        {
            // Given
            RoomRepository.ClearRooms();
            RoomRepository.AddRoom(new Room
            {
                Id = 1,
                RoomNumber = 101,
                IsAvailable = true,
                Price = 100,
                RoomType = "Double"
            });
            RoomRepository.AddRoom(new Room
            {
                Id = 2,
                RoomNumber = 102,
                IsAvailable = true,
                Price = 100,
                RoomType = "Single"
            });

            //When
            var doubleRooms = RoomRepository.GetDoubleRooms();

            // Then
            doubleRooms.Should().HaveCount(1);
            doubleRooms.All(r => r.RoomType == "Double").Should().BeTrue();
        }

        [Fact]
        public void GetSuiteRooms_WhenCalled_ReturnsOnlySuiteRooms()
        {
            // Given
            RoomRepository.ClearRooms();
            RoomRepository.AddRoom(new Room
            {
                Id = 1,
                RoomNumber = 101,
                IsAvailable = true,
                Price = 100,
                RoomType = "Single"
            });
            RoomRepository.AddRoom(new Room
            {
                Id = 2,
                RoomNumber = 102,
                IsAvailable = true,
                Price = 100,
                RoomType = "Suite"
            });

            // When
            var suiteRooms = RoomRepository.GetSuiteRooms();

            // Then
            suiteRooms.Should().HaveCount(1);
            suiteRooms.All(r => r.RoomType == "Suite").Should().BeTrue();
        }



        [Fact]
        public void GetRoomsByPriceRange_WhenCalledWithValidRange_ReturnsRoomsWithinRange()
        {
            // Given
            RoomRepository.ClearRooms();
            RoomRepository.AddRoom(new Room { Id = 1, Price = 50, RoomType = "Single" });
            RoomRepository.AddRoom(new Room { Id = 2, Price = 150, RoomType = "Double" });
            RoomRepository.AddRoom(new Room { Id = 3, Price = 250, RoomType = "Suite" });

            var lowPrice = 100;
            var highPrice = 200;

            // When
            var roomsWithinRange = RoomRepository.GetRoomsByPriceRange(lowPrice, highPrice);

            // Then
            roomsWithinRange.Should().HaveCount(1);
            roomsWithinRange.All(r => r.Price >= lowPrice && r.Price <= highPrice).Should().BeTrue();
        }


    }
}