namespace SoftUniBazar.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public class BaseController : Controller
    {
        protected string GetUserId()
        {
            string id = string.Empty;

            if (User != null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return id;
        }
    }
}
