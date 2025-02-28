using System.Diagnostics;
using ASPDotNetProject.Models;
using ASPDotNetProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ASPDotNetProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersRepository _usersRepository;

        public HomeController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public ViewResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {
                //Users = _usersRepository.GetEmployee(1),
                PageTitle = "Login to Discover!"
            };
            return View(homeIndexViewModel);
        }
    }
}
