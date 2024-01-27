using System;
using System.ComponentModel.DataAnnotations;
namespace COMP2139_Labs.Models
{
    public class Project
    {
        public Project()
        {
        }

        [Key]
        public int ProjectId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public string? Status { get; set; }

    }


}