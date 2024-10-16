using System.ComponentModel.DataAnnotations;

namespace TaskboardApp.Models.Task
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(TaskboardApp.Data.DataConstants.Task.TaskMaxTitle, 
            MinimumLength = TaskboardApp.Data.DataConstants.Task.TaskMinTitle,
            ErrorMessage = "Title should be at least {2} characters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(TaskboardApp.Data.DataConstants.Task.TaskMaxDescription,
            MinimumLength = TaskboardApp.Data.DataConstants.Task.TaskMinDescription,
            ErrorMessage = "Description should be at least {2} characters long.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        [Required]
        public IEnumerable<TaskBoardModel> Boards { get; set; } = new List<TaskBoardModel>();
    }
}
