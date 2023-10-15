namespace NagyiReceptjei.API.Models;

public class Recipe
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public string Ingredients { get; set; }
    public string Content { get; set; }
    public int PrepTime { get; set; }
    public int Portion { get; set; }
    public string Image { get; set; }
}
