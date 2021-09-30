using System;
using System.ComponentModel.DataAnnotations;

namespace GCD0805AppDev.Models
{
  public class Todo
  {
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(255)]
    public string Description { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
  }
}