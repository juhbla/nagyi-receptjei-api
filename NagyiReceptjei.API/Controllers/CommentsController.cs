using Microsoft.AspNetCore.Mvc;

namespace NagyiReceptjei.API.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class CommentsController
{
    // POST: api/comments/1
    [HttpPost("{recipeId:int}")]
    public IResult CreateComment(int recipeId, [FromBody] string content)
    {
        return null;
    }

    // DELETE: api/comments/1
    [HttpDelete("{id:int}")]
    public IResult DeleteComment(int id)
    {
        return null;
    }
}
