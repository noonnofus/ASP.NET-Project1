using ASPDotNetProject.Models;
using ASPDotNetProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ASPDotNetProject.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IClassRepository _roomsRepository;
        public ProfileController(IClassRepository roomsRepository)
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
    }
}
