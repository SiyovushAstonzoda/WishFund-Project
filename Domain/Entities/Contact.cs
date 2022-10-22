using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;

public class Contact
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string? Name { get; set; }
    [Required, MaxLength(100)]
    public string? Subject { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [Required, MaxLength(13)]
    public string? Phone { get; set; }
    [Required, MaxLength(500)]
    public string? Message { get; set; }
}