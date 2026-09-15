using System.ComponentModel.DataAnnotations;

namespace UppgiftslistaApi.Models;

public class TodoItem
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; } = "";

    public bool Done { get; set; }
}