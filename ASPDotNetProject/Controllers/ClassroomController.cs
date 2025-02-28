using ASPDotNetProject.Models;
using ASPDotNetProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ASPDotNetProject.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly IClassRepository _roomsRepository;

        public ClassroomController(IClassRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }
        [HttpPost]
        public IActionResult JoinClass(int classroomId)
        {
            var classroom = _roomsRepository.GetRoomById(classroomId);

            if (classroom == null)
            {
                return NotFound("Classroom not found");
            }

            var currentUserId = 5;

            if (classroom.UserIds == null)
            {
                classroom.UserIds = new List<int>();
            }

            if (!classroom.UserIds.Contains(currentUserId))
            {
                classroom.UserIds.Add(currentUserId);
                _roomsRepository.UpdateRoom(classroom);
            }

            return RedirectToAction("Index");
        }
        public ViewResult Index()
        {
            ClassroomViewModel classroomViewModel = new ClassroomViewModel()
            {
                UserId = 5,
                Rooms = _roomsRepository.GetAllRooms(),
            };
            return View(classroomViewModel);
        }
    }
}
