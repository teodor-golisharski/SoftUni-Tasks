using ForumApp.Data;
using ForumAppMVC.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumAppMVC.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumAppDbContext _data;

        public PostController(ForumAppDbContext data)
        {
            this._data = data;
        }

        public async Task<IActionResult> All()
        {
            var posts = await _data.Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                })
                .ToListAsync();

            return View(posts);
        }
    }
}
