namespace HotelBookingApp.Logic
{
    public static class RoomRepository
    {
        private static List<Room> Rooms { get; set; } =
        [
            // Static list of rooms
            // Images and descriptions are generated with DALL-E to avoid copyright
            new()
            {
                Id = 1,
                RoomNumber = 101,
                IsAvailable = true,
                Price = 75,
                RoomType = "Single",
                Description = "A modern single room with a vibrant and fresh design, " +
                "featuring a single bed with colorful, patterned bedding",
                ImageFileName = "room101.webp"
            },
            new()
            {
                Id = 2,
                RoomNumber = 102,
                IsAvailable = true,
                Price = 130,
                RoomType = "Double",
                Description = "A modern double room that emphasizes natural light and organic elements. " +
                "The room offers a peaceful garden view through panoramic windows, " +
                "and it's decorated with natural wood finishes, neutral colors, and indoor greenery.",
                ImageFileName = "room102.webp"
            },
            new()
            {
                Id = 3,
                RoomNumber = 103,
                IsAvailable = true,
                Price = 95,
                RoomType = "Single",
                Description = "A contemporary hotel room with a dynamic and stylish design. " +
                "This room features a single bed with geometric-patterned bedding",
                ImageFileName = "room103.webp"
            },
            new()
            {
                Id = 4,
                RoomNumber = 104,
                IsAvailable = true,
                Price = 85,
                RoomType = "Single",
                Description = "A modern single room, embodying a clean and efficient design. " +
                "The room includes a single bed with a designer headboard, crisp white bedding, " +
                "and a lovely view to the canal",
                ImageFileName = "room104.webp"
            },
            new()
            {
                Id = 5,
                RoomNumber = 201,
                IsAvailable = true,
                Price = 140,
                RoomType = "Double",
                Description = "A modern double room with a city skyline view through large, floor-to-ceiling windows. " +
                "The room features a contemporary design with a cool color scheme and modern amenities.",
                ImageFileName = "room201.webp"
            },
            new()
            {
                Id = 6,
                RoomNumber = 202,
                IsAvailable = true,
                Price = 135,
                RoomType = "Double",
                Description = "A modern double room with a sophisticated urban design and an industrial twist. " +
                "The room features high ceilings, large windows with a cityscape view, exposed brick walls, " +
                "and sleek metal finishes, creating a chic, loft-like atmosphere.",
                ImageFileName = "room202.webp"
            },
            new()
            {
                Id = 7,
                RoomNumber = 203,
                IsAvailable = true,
                Price = 95,
                RoomType = "Single",
                Description = "A modern single room with a sleek, minimalist design. " +
                "The room features a comfortable bed with high-quality linens, a compact workspace, " +
                "and a beautiful view of the city",
                ImageFileName = "room203.webp"
            },
            new()
            {
                Id = 8,
                RoomNumber = 204,
                IsAvailable = true,
                Price = 145,
                RoomType = "Single",
                Description = "A sleek, contemporary single room with a high-end minimalist design. " +
                "The room features a luxurious single bed with high-quality linens, big-screen TV, " +
                "and a view over city centre",
                ImageFileName = "room204.webp"
            },
            new()
            {
                Id = 9,
                RoomNumber = 301,
                IsAvailable = true,
                Price = 1299,
                RoomType = "Suite",
                Description = "A luxurious suite, designed to offer the ultimate in opulence and comfort. " +
                "The suite features panoramic views through floor-to-ceiling windows, high-end materials, " +
                "a king-sized bed with premium bedding, a spacious living area, an elegant dining space, " +
                "a fully-equipped kitchenette, and a sumptuous bathroom, creating a sophisticated and inviting atmosphere",
                ImageFileName = "room301.webp"
            },
            new()
            {
                Id = 10,
                RoomNumber = 302,
                IsAvailable = true,
                Price = 150,
                RoomType = "Double",
                Description = "A modern double room designed with an emphasis on elegance and comfort. " +
                "The room features a large bay window with panoramic views of the ocean or a serene lake, " +
                "soft pastel colors, delicate fabrics, and luxurious linens, creating a tranquil and inviting atmosphere.",
                ImageFileName = "room302.webp"
            },
            new()
            {
                Id = 11,
                RoomNumber = 303,
                IsAvailable = true,
                Price = 1499,
                RoomType = "Suite",
                Description = "A grand presidential suite, embodying the highest standard of luxury and exclusivity. " +
                "The suite boasts panoramic views, a blend of classic and contemporary decor, " +
                "a master bedroom with a king-sized bed, a lavish bathroom with a jacuzzi, " +
                "an opulent living area with a grand piano, a private office, a dining room, and a gourmet kitchen, " +
                "providing an unparalleled experience for guests.",
                ImageFileName = "room303.webp"
            },
            new()
            {
                Id = 12,
                RoomNumber = 304,
                IsAvailable = true,
                Price = 155,
                RoomType = "Single",
                Description = "A modern single hotel room with an elegant and refined design. " +
                "The room includes a luxurious single bed with plush bedding and an upholstered headboard, " +
                "and a view of the vibrating city centre",
                ImageFileName = "room304.webp"
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

        public static IEnumerable<Room> GetRoomsByPriceRange(int lowPrice, int highPrice)
        {
            return Rooms.Where(r => r.Price >= lowPrice && r.Price <= highPrice).ToList();
        }

        // For testing purposes
        public static void ClearRooms()
        {
            Rooms.Clear();
        }
    }
}
