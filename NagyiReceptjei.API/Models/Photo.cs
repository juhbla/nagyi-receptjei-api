namespace NagyiReceptjei.API.Models;

public class Photo
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
}
