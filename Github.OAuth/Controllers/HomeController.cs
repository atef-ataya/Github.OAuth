using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var userModel = new IndexModel();

            if (User.Identity.IsAuthenticated)
            {
                userModel.GitHubName = User.FindFirst(c => c.Type == ClaimTypes.Name)?.Value;
                userModel.GitHubLogin = User.FindFirst(c => c.Type == "urn:github:login")?.Value;
                userModel.GitHubUrl = User.FindFirst(c => c.Type == "urn:github:url")?.Value;
                userModel.GitHubAvatar = User.FindFirst(c => c.Type == "urn:github:avatar")?.Value;

            }
            return View(userModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
