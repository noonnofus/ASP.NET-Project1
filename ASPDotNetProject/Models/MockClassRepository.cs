namespace ASPDotNetProject.Models
{
    public class MockClassRepository : IClassRepository
    {
        private List<Classroom> _classroomList;
        public MockClassRepository()
        {
            _classroomList = new List<Classroom>()
            {
                new Classroom 
                { 
                    Id = 1, 
                    ClassName = "Study ASP.NET", 
                    Type = "ASP.NET", 
                    Password = null, 
                    UserIds = new List<int> {1,2,3,4},
                    Messages = new List<Message>
                    {
                        new Message { Id = 1, UserId = 1, Content = "Hello everyone!" },
                        new Message { Id = 2, UserId = 2, Content = "Let's start studying ASP.NET." }
                    }
                },
                new Classroom 
                { 
                    Id = 2, 
                    ClassName = "Who want to study React with me?", 
                    Type = "React", 
                    Password = "1234", 
                    UserIds = new List<int> {1,3},
                    Messages = new List<Message>
                    {
                        new Message { Id = 3, UserId = 3, Content = "React is fun!" }
                    }
                }
            };
        }
        public IEnumerable<Classroom> GetAllRooms()
        {
            return _classroomList;
        }
        public Classroom GetRoomById(int Id)
        {
            return _classroomList.FirstOrDefault(room => room.Id == Id);
        }
        public Classroom GetRoomByType(string type)
        {
            return _classroomList.FirstOrDefault(room => room.Type == type);
        }
        public void UpdateRoom(Classroom updatedRoom)
        {
            var existingRoom = _classroomList.FirstOrDefault(r => r.Id == updatedRoom.Id);
            if (existingRoom != null)
            {
                foreach (var userId in updatedRoom.UserIds)
                {
                    if (!existingRoom.UserIds.Contains(userId))
                    {
                        existingRoom.UserIds.Add(userId);
                    }
                }  
            }
        }
        public void AddRoom(Classroom classroom)
        {
            if (classroom == null)
            {
                throw new ArgumentNullException(nameof(classroom), "Classroom cannot be null.");
            }

            int newId = _classroomList.Any() ? _classroomList.Max(r => r.Id) + 1 : 1;
            classroom.Id = newId;

            _classroomList.Add(classroom);
        }
        public void DeleteRoom(int id)
        {
            var roomToDelete = _classroomList.FirstOrDefault(r => r.Id == id);
            if (roomToDelete != null)
            {
                _classroomList.Remove(roomToDelete);
            }
        }

    }
}
