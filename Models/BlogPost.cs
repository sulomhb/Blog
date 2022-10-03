using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace assignment_4.Models;

public class BlogPost
{
    public BlogPost() {}

    [Key]
    [Required]
    [DisplayName("ID")]
    public int? ID { get; set; }
    
    [Required]
    [DisplayName("Title")]
    public string? Title { get; set; } = string.Empty;

    [Required]
    [DisplayName("Summary")]
    public string? Summary { get; set; } = string.Empty;

    [Required]
    [DisplayName("Content")]
    public string? Content { get; set; } = string.Empty;

    [Required]
    [DisplayName("Content")]
    public string? Nickname { get; set; } = string.Empty;

    [Required]
    [DisplayName("Time")]
    public DateTime Now { get; set; }
}
