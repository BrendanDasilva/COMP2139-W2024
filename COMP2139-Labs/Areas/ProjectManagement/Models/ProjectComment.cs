﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace COMP2139_Labs.Areas.ProjectManagement.Models
{
  public class ProjectComment
  {
    [Key]
    public int ProjectCommentId { get; set; }

    [Required]
    [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
    public string? Content { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime CreatedDate { get; set; }

    // Foreign Key for Project
    public int ProjectId { get; set; }

    // Navigation Property to Project
    public Project? Project { get; set; }
  }
}
