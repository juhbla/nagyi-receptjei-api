namespace NagyiReceptjei.API.Models;

public class Comment
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDateTime { get; set; }
}
