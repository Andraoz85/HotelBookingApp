namespace HotelBookingApp.Data
{
    public static class RoomRepository
    {
        private static List<Room> Rooms { get; set; } =
        [
            // Dummy data - Static list of rooms
            new()
            {
                Id = 1,
                RoomNumber = 101,
                IsAvailable = true,
                Price = 75,
                RoomType = "Single"
            },
            new()
            {
                Id = 2,
                RoomNumber = 102,
                IsAvailable = true,
                Price = 130,
                RoomType = "Double"
            },
            new()
            {
                Id = 3,
                RoomNumber = 103,
                IsAvailable = true,
                Price = 75,
                RoomType = "Single"
            },
            new()
            {
                Id = 4,
                RoomNumber = 104,
                IsAvailable = true,
                Price = 80,
                RoomType = "Single"
            },
            new()
            {
                Id = 5,
                RoomNumber = 201,
                IsAvailable = true,
                Price = 140,
                RoomType = "Double"
            },
            new()
            {
                Id = 6,
                RoomNumber = 202,
                IsAvailable = true,
                Price = 135,
                RoomType = "Double"
            },
            new()
            {
                Id = 7,
                RoomNumber = 203,
                IsAvailable = true,
                Price = 90,
                RoomType = "Single"
            },
            new()
            {
                Id = 8,
                RoomNumber = 204,
                IsAvailable = true,
                Price = 85,
                RoomType = "Single"
            },
            new()
            {
                Id = 9,
                RoomNumber = 301,
                IsAvailable = true,
                Price = 250,
                RoomType = "Suite"
            },
            new()
            {
                Id = 10,
                RoomNumber = 302,
                IsAvailable = true,
                Price = 150,
                RoomType = "Double"
            },
            new()
            {
                Id = 11,
                RoomNumber = 303,
                IsAvailable = true,
                Price = 250,
                RoomType = "Suite"
            },
            new()
            {
                Id = 12,
                RoomNumber = 304,
                IsAvailable = true,
                Price = 400,
                RoomType = "Single"
            },
        ];

        public static void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public static List<Room> GetAllRooms()
        {
            return Rooms;
        }

        public static List<Room> GetAvailableRooms()
        {
            return Rooms.Where(room => room.IsAvailable == true).ToList();
        }

        public static List<Room> GetSingleRooms()
        {
            return Rooms.Where(room => room.RoomType == "Single").ToList();
        }


        public static List<Room> GetDoubleRooms()
        {
            return Rooms.Where(Room => Room.RoomType == "Double").ToList();
        }

        public static List<Room> GetSuiteRooms()
        {
            return Rooms.Where(Room => Room.RoomType == "Suite").ToList();
        }
        /*
        public static bool IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate)
        {
            // make sure that the start date is before the end date
            if (startDate >= endDate)
            {
                throw new InvalidOperationException("Start date must be before end date!");
            }

            // Get all reservations to check for overlapping dates
            var allReservations = ReservationRepository.GetAllReservations();

            // check if the room is available for the selected dates
            var overlappingReservation = allReservations.Any(r =>
            r.RoomId == roomId &&
            r.StartDate < endDate &&
            r.EndDate > startDate);

            // The room is available if there are no overlapping reservations
            return !overlappingReservation;
        }
        */

        // For testing
        public static void ClearRooms()
        {
            Rooms.Clear();
        }

        public static IEnumerable<Room> GetRoomsByPriceRange(int lowPrice, int highPrice)
        {
            return Rooms.Where(r => r.Price >= lowPrice && r.Price <= highPrice).ToList();
        }
    }
}
