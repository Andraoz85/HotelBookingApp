using HotelBookingApp.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelBookingApp.Pages
{
    public class AvailableRoomsModel : PageModel
    {
        public List<Room>? Rooms { get; set; }
        public void OnGet()
        {
            Rooms = RoomRepository.GetAvailableRooms();
        }
    }
}
