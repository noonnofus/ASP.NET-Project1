using ASPDotNetProject.Models;
using ASPDotNetProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ASPDotNetProject.Controllers
{
    public class DeleteClassController : Controller
    {
        private readonly IClassRepository _classroomService;

        public DeleteClassController(IClassRepository classroomService)
        {
            _classroomService = classroomService;
        }

        public IActionResult Index(int id)
        {
            var classroom = _classroomService.GetRoomById(id);
            if (classroom == null)
            {
                return NotFound();
            }

            var viewModel = new ClassroomViewModel
            {
                Classroom = classroom
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeleteClass(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid classroom ID");
            }

            var classroom = _classroomService.GetRoomById(id);
            if (classroom == null)
            {
                return NotFound("Classroom not found");
            }

            var currentUserId = 5;
            if (classroom.UserIds != null && classroom.UserIds.Contains(currentUserId))
            {
                classroom.UserIds.Remove(currentUserId);
                _classroomService.UpdateRoom(classroom);
            }

            if (classroom.UserIds == null || !classroom.UserIds.Any())
            {
                _classroomService.DeleteRoom(id);
            }


            return RedirectToAction("Index", "Profile");
        }
    }
}
