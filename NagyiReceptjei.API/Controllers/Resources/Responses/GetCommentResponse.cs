namespace NagyiReceptjei.API.Controllers.Resources.Responses;

public class GetCommentResponse
{
    public int Id { get; set; }
    public GetUserResponse User { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDateTime { get; set; }
}
