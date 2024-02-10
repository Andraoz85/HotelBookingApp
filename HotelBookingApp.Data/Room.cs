namespace HotelBookingApp.Data
{
    public class Room
    {

        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public bool IsAvailable { get; set; }
        public int Price { get; set; }
        public string? RoomType { get; set; }
        public string? Description { get; set; }
        public string? ImageFileName { get; set; }
    }
}
