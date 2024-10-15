using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskboardApp.Data;
using TaskboardApp.Models.Board;
using TaskboardApp.Models.Task;

namespace TaskboardApp.Controllers
{
    public class BoardController : Controller
    {
        private readonly TaskBoardAppDbContext _dbContext;

        public BoardController(TaskBoardAppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IActionResult> All()
        {
            var boards = await _dbContext
                .Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b
                        .Tasks
                        .Select(t => new TaskViewModel()
                        {
                            Id = t.Id,
                            Title = t.Title,
                            Description = t.Description,
                            Owner = t.Owner.UserName
                        })
                })
                .ToListAsync();

            return View(boards);
        }
    }
}
