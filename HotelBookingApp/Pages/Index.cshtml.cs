using HotelBookingApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelBookingApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Room>? Rooms { get; set; }


        [BindProperty(SupportsGet = true)]
        public string? RoomType { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }

        public void OnGet()
        {
            Rooms = RoomRepository.GetAllRooms();
        }
    }
}
