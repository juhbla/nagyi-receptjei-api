namespace NagyiReceptjei.API.Controllers.Resources.Requests;

public class CreateCommentRequest
{
    public string Content { get; set; }
    public int RecipeId { get; set; }
    public int UserId { get; set; }
}
