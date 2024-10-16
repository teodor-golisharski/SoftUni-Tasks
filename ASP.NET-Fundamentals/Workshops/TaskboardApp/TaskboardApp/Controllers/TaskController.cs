using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskboardApp.Data;
using TaskboardApp.Models.Task;
using Task = TaskboardApp.Data.Models.Task;

namespace TaskboardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly TaskBoardAppDbContext _dbContext;

        public TaskController(TaskBoardAppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IActionResult> Create()
        {
            TaskFormModel model = new TaskFormModel()
            {
                Boards = GetBoards()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskModel)
        {
            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            string currentUserId = GetUserId();

            if (!ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();

                return View(taskModel);
            }

            Task task = new Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserId
            };

            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            var boards = _dbContext.Boards;

            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _dbContext.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentId = GetUserId();
            if (currentId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel taskModel = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
        {
            var task = await _dbContext.Tasks.FindAsync(id);

            if(task == null)
            {
                return BadRequest();
            }

            string currentId = GetUserId();
            if (currentId != task.OwnerId)
            {
                return Unauthorized();
            }

            if(!GetBoards().Any(b => b.Id == task.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            if(!ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();

                return View (taskModel);
            }

            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _dbContext.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentId = GetUserId();
            if (currentId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskViewModel taskModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskModel)
        {
            var task = await _dbContext.Tasks.FindAsync(taskModel.Id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentId = GetUserId();
            if (currentId != task.OwnerId)
            {
                return Unauthorized();
            }

            _dbContext.Tasks.Remove(task);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }


        public async Task<IActionResult> Details(int id)
        {
            TaskDetailsViewModel? task = await _dbContext
                .Tasks
                .Select(t => new TaskDetailsViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board!.Name,
                    Owner = t.Owner.UserName
                })
                .FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }


        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);

        private IEnumerable<TaskBoardModel> GetBoards()
            => _dbContext
                .Boards
                .Select(b => new TaskBoardModel
                {
                    Id = b.Id,
                    Name = b.Name
                });
    }
}
