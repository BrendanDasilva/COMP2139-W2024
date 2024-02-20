using System.ComponentModel.DataAnnotations;
namespace COMP2139_Labs.Areas.ProjectManagement.Models

{
    public class ProjectTask
    {
        [Key]
        public int ProjectTaskId { get; set; }

        [Required]
        [Display(Name = "Task Name")]
        [StringLength(100, ErrorMessage = "Task name cannot exceed 100 characters.")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        public int ProjectId { get; set; }

        public Project? Project { get; set; }
    }
}
