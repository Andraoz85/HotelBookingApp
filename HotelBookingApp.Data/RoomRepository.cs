namespace HotelBookingApp.Data
{
    public class RoomRepository
    {
        private static List<Room> Rooms { get; set; } =
        [
            // Dummy data
            new()
            {
                Id = 1,
                RoomNumber = 101,
                Floor = 1,
                IsAvailable = true,
                Price = 75,
                RoomType = "Single"
            },
            new()
            {
                Id = 2,
                RoomNumber = 102,
                Floor = 1,
                IsAvailable = true,
                Price = 130,
                RoomType = "Double"
            },
            new()
            {
                Id = 3,
                RoomNumber = 103,
                Floor = 1,
                IsAvailable = false,
                Price = 75,
                RoomType = "Single"
            },
            new()
            {
                Id = 4,
                RoomNumber = 104,
                Floor = 1,
                IsAvailable = true,
                Price = 80,
                RoomType = "Single"
            },
            new()
            {
                Id = 5,
                RoomNumber = 201,
                Floor = 2,
                IsAvailable = false,
                Price = 140,
                RoomType = "Double"
            },
            new()
            {
                Id = 6,
                RoomNumber = 202,
                Floor = 2,
                IsAvailable = true,
                Price = 135,
                RoomType = "Double"
            },
            new()
            {
                Id = 7,
                RoomNumber = 203,
                Floor = 2,
                IsAvailable = true,
                Price = 90,
                RoomType = "Single"
            },
            new()
            {
                Id = 8,
                RoomNumber = 204,
                Floor = 2,
                IsAvailable = false,
                Price = 85,
                RoomType = "Single"
            },
            new()
            {
                Id = 9,
                RoomNumber = 301,
                Floor = 3,
                IsAvailable = true,
                Price = 250,
                RoomType = "Suite"
            },
            new()
            {
                Id = 10,
                RoomNumber = 302,
                Floor = 3,
                IsAvailable = true,
                Price = 150,
                RoomType = "Double"
            },
            new()
            {
                Id = 11,
                RoomNumber = 303,
                Floor = 3,
                IsAvailable = false,
                Price = 250,
                RoomType = "Deluxe"
            },
            new()
            {
                Id = 12,
                RoomNumber = 304,
                Floor = 3,
                IsAvailable = true,
                Price = 400,
                RoomType = "Presidential Suite"
            },
        ];
        // public static List<Room> Rooms => rooms;
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
            return Rooms.Where(Room => Room.RoomType == "Deluxe").ToList();
        }

        public static List<Room> GetPresidentialSuiteRooms()
        {
            return Rooms.Where(Room => Room.RoomType == "Presidential Suite").ToList();
        }
    }
}
