using ASPDotNetProject.Models;
using ASPDotNetProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ASPDotNetProject.Controllers
{
    public class ClassroomDetailController : Controller
    {
        private readonly IClassRepository _roomsRepository;

        public ClassroomDetailController(IClassRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }

        public IActionResult Index(int id)
        {
            var classroom = _roomsRepository.GetRoomById(id);

            if (classroom == null)
            {
                return NotFound("Classroom not found");
            }

            if (classroom.Messages == null)
            {
                classroom.Messages = new List<Message>();
            }

            var currentUserId = 5;

            var viewModel = new ClassroomDetailViewModel
            {
                Classroom = classroom,
                UserId = currentUserId,
                IsUserJoined = classroom.UserIds != null && classroom.UserIds.Contains(currentUserId)
            };

            return View(viewModel);
        }


        public IActionResult JoinClass(int id)
        {
            var classroom = _roomsRepository.GetRoomById(id);

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

            return RedirectToAction("Index", new { id });
        }

        [HttpPost]
        public IActionResult SendMessage(int classroomId, string messageContent)
        {
           Console.WriteLine($"Classroom ID: {classroomId}, Message: {messageContent}");

            var classroom = _roomsRepository.GetRoomById(classroomId);

            if (classroom == null)
            {
                return NotFound("Classroom not found");
            }

            var currentUserId = 5;

            if (string.IsNullOrWhiteSpace(messageContent))
            {
                return BadRequest("Message cannot be empty");
            }

            if (classroom.Messages == null)
            {
                classroom.Messages = new List<Message>();
            }

            var newMessage = new Message
            {
                Id = classroom.Messages.Count + 1,
                UserId = currentUserId,
                Content = messageContent
            };

            classroom.Messages.Add(newMessage);
            _roomsRepository.UpdateRoom(classroom);

            return RedirectToAction("Index", new { id = classroomId });
        }
    }
}
