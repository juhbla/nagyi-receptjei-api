namespace NagyiReceptjei.API.Resources;

public class GetCommentResponse
{
    public int Id { get; set; }
    public GetUserResponse User { get; set; }
    public string Content { get; set; }
}
