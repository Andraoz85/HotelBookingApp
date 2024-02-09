using HotelBookingApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelBookingApp.Pages
{
    public class IndexModel : PageModel
    {

        public List<Room>? Rooms { get; set; } = [];

        [BindProperty]
        public int RoomId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? RoomType { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime? StartDate { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime? EndDate { get; set; }


        public void OnGet()
        {
            bool hasSearched = StartDate.HasValue && EndDate.HasValue;

            if (hasSearched)
            {
                Rooms = RoomRepository.GetAllRooms();

                //Filter on room type
                if (!string.IsNullOrEmpty(RoomType) && RoomType != "All")
                {
                    Rooms = Rooms.Where(r => r.RoomType.Equals(RoomType, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                // Filter on availability
                Rooms = Rooms.Where(r => ReservationRepository.IsRoomAvailable(r.Id, StartDate.Value, EndDate.Value)).ToList();
            }
            else
            {
                Rooms = []; // start with an empty list of rooms until the user has searched
            }
        }
        public IActionResult OnPostBookRoom(int roomId, DateTime startDate, DateTime endDate)
        {
            try
            {
                // Check if the dates are valid
                if (endDate <= startDate)
                {
                    ModelState.AddModelError("", "End date must be after start date.");
                    return Page();
                }
                // Check if the room is available for the selected dates
                if (!ReservationRepository.IsRoomAvailable(roomId, startDate, endDate))
                {
                    ModelState.AddModelError("", "The room is not available for the selected dates.");
                    return Page();
                }

                // Add the reservation
                var reservation = ReservationRepository.AddReservation(roomId, startDate, endDate);

                Rooms = RoomRepository.GetAllRooms();
                if (!string.IsNullOrEmpty(RoomType))
                {
                    Rooms = Rooms.Where(r => r.RoomType == RoomType).ToList();
                }

                // Use TempData to show a success message after redirecting
                TempData["Message"] = "Room booked successfully!";
                return Page();
            }
            catch (InvalidOperationException ex)
            {
                Rooms = RoomRepository.GetAllRooms();
                if (!string.IsNullOrEmpty(RoomType))
                {
                    Rooms = Rooms.Where(r => r.RoomType == RoomType).ToList();
                }
                ModelState.AddModelError("", ex.Message);
                return Page();
            }
        }
    }
}
