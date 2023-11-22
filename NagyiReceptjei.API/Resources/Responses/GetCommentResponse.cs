namespace NagyiReceptjei.API.Resources.Responses;

public class GetCommentResponse
{
    public int Id { get; set; }
    public GetUserResponse User { get; set; }
    public string Content { get; set; }
}
