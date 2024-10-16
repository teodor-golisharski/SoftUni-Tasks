using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TaskboardApp.Data;
using TaskboardApp.Models;

namespace TaskboardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskBoardAppDbContext _data;

        public HomeController(TaskBoardAppDbContext context)
        {
            _data = context;   
        }

        public IActionResult Index()
        {
            var taskBoards = _data
                .Boards
                .Select(b=>b.Name)
                .Distinct();

            var tasksCount = new List<HomeBoardModel>();
            foreach (var BoardName in taskBoards)
            {
                var tasksInBoard = _data.Tasks.Where(t => t.Board.Name == BoardName).Count();
                tasksCount.Add(new HomeBoardModel
                {
                    BoardName = BoardName,
                    TaskCount = tasksInBoard
                });
            }

            var userTaskCount = -1;
            if(User.Identity.IsAuthenticated)
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                userTaskCount = _data.Tasks.Where(x => x.OwnerId == currentUserId).Count();
            }

            var homeModel = new HomeViewModel()
            {
                AllTaskCount = _data.Tasks.Count(),
                BoardsWithTasksCount = tasksCount,
                UserTasksCount = userTaskCount
            };

            return View (homeModel);
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