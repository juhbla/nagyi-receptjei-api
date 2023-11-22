namespace NagyiReceptjei.API.Resources.Requests;

public class CreateRecipeRequest
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int PrepTime { get; set; }
    public int Portion { get; set; }
    public IEnumerable<CreateIngredientRequest> Ingredients { get; set; }
}
