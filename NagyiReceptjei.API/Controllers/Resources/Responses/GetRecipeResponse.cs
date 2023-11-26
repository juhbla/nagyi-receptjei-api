namespace NagyiReceptjei.API.Controllers.Resources.Responses;

public class GetRecipeResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int PrepTime { get; set; }
    public int Portion { get; set; }
    public string? PhotoFileName { get; set; } = null;
    public IEnumerable<GetCommentResponse> Comments { get; set; }
    public IEnumerable<GetIngredientResponse> Ingredients { get; set; }
}
