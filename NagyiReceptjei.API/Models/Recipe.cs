namespace NagyiReceptjei.API.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int PrepTime { get; set; }
    public int Portion { get; set; }
    public string Image { get; set; }
    public IEnumerable<Comment> Comments { get; set; }
    public IEnumerable<Ingredient> Ingredients { get; set; }
}
