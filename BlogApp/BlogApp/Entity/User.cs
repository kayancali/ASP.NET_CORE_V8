using System;

namespace BlogApp.Entity;

public class User
{
    public int UserId { get; set; }

     public String? Image { get; set; }

    public string? UserName { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }


    public List<Post> Posts { get; set; } = new List<Post>();


    public List<Comment> Comments { get; set; } = new List<Comment>();
}