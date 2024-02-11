using HotelBookingApp.Logic;
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
            Rooms = [];

            bool hasSearched = StartDate.HasValue && EndDate.HasValue;
            bool validDateRange = StartDate.HasValue && EndDate.HasValue && EndDate.Value > StartDate.Value;

            if (hasSearched && validDateRange)
            {
                //Filter on room type
                if (!string.IsNullOrEmpty(RoomType) && RoomType != "All")
                {
                    Rooms = RoomRepository.GetAllRooms()
                    .Where(r => r.RoomType.Equals(RoomType, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                }
                else
                {
                    Rooms = RoomRepository.GetAllRooms();
                }
                // Filter on availability
                if (StartDate.HasValue && EndDate.HasValue)
                {
                    Rooms = Rooms.Where(r => ReservationRepository.IsRoomAvailable(r.Id, StartDate.Value, EndDate.Value)).ToList();
                }
            }
            else if (hasSearched && !validDateRange)
            {
                // Tempdata to display error message
                TempData["ErrorMessage"] = "End date must be after start date.";
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

                // TempData to show a success message
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
