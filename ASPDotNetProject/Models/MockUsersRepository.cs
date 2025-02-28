namespace ASPDotNetProject.Models
{
    public class MockUsersRepository : IUsersRepository
    {
        private List<Users> _usersList;
        public MockUsersRepository()
        {
            _usersList = new List<Users>()
            {
                new Users() { Id = 1, Email = "kso51@my.bcit.ca", Password = "1234", Username = "kevin02", Address = "668 citadel prd" },
                new Users() { Id = 2, Email = "hanC@my.bcit.ca", Password = "1234", Username = "Changseung", Address = "668 citadel prd" },
                new Users() { Id = 3, Email = "flora00@my.bcit.ca", Password = "1234", Username = "flora00", Address = "668 citadel prd" },
                new Users() { Id = 4, Email = "jin00@my.bcit.ca", Password = "1234", Username = "jin00", Address = "668 citadel prd"},
                new Users() { Id = 5, Email = "noonnofus@my.bcit.ca", Password = "1234", Username = "noonnofus", Address = "668 citadel prd"},
            };

        }
        public IEnumerable<Users> GetAllUsers()
        {
            return _usersList;
        }

        public Users GetUserById(int Id)
        {
            return _usersList.FirstOrDefault(user => user.Id == Id);
        }
    }
}
