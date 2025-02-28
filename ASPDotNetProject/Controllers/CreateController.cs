using ASPDotNetProject.Models;
using ASPDotNetProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ASPDotNetProject.Controllers
{
    public class CreateController : Controller
    {
        private readonly IClassRepository _roomsRepository;

        public CreateController(IClassRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
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

        [HttpPost]
        public IActionResult CreateClass(string classname, string classtype) 
        {
            if (string.IsNullOrWhiteSpace(classname) || string.IsNullOrWhiteSpace(classtype))
            {
                return BadRequest("Class name and type cannot be empty.");
            }

            var newClassroom = new Classroom
            {
                Id = _roomsRepository.GetAllRooms().Max(r => r.Id) + 1,
                ClassName = classname,
                Type = classtype,
                Password = null,
                UserIds = new List<int> { 5 },
                Messages = new List<Message>()
            };

            _roomsRepository.AddRoom(newClassroom);

            return RedirectToAction("Index", "Classroom");
        }

    }
}