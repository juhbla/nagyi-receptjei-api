namespace NagyiReceptjei.API.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
    public string Unit { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
}
