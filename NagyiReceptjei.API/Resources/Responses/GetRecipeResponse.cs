namespace NagyiReceptjei.API.Resources.Responses;

public class GetRecipeResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int PrepTime { get; set; }
    public int Portion { get; set; }
    public string Image { get; set; }
    public IEnumerable<GetCommentResponse> Comments { get; set; }
    public IEnumerable<GetIngredientResponse> Ingredients { get; set; }
}
