using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Entity;

public class Post
{   
    [Key]
    public int PostId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }
    public String? Content { get; set; }
    public String? Url { get; set; }
    public String? Image { get; set; }

    public DateTime PublishedOn { get; set; }

    public bool IsActive { get; set; }

    public int UserId { get; set; }

    public User User { get; set; } =null!;

    public List<Tag> Tags { get; set; } = new List<Tag>();

    public List<Comment> Comments { get; set; } = new List<Comment>();
}
