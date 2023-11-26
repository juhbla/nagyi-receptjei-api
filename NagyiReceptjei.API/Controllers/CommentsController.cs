using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NagyiReceptjei.API.Controllers.Resources.Requests;
using NagyiReceptjei.API.Controllers.Resources.Responses;
using NagyiReceptjei.API.Models;
using NagyiReceptjei.API.Repositories;

namespace NagyiReceptjei.API.Controllers;

[ApiController]
[EnableCors("DefaultCorsPolicy")]
[Route("api/[controller]/")]
public class CommentsController
{
    private readonly CommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentsController(
        CommentRepository commentRepository,
        IMapper mapper
    )
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    // POST: api/comments/1
    [HttpPost]
    public IResult CreateComment([FromBody] CreateCommentRequest request)
    {
        var comment = _mapper.Map<CreateCommentRequest, Comment>(request);
        var newComment = _commentRepository.Add(comment);
        var commentById = _commentRepository.GetComment(newComment.Id);
        var commentResponse = _mapper.Map<Comment, GetCommentResponse>(commentById);
        return Results.Ok(commentResponse);
    }

    // DELETE: api/comments/1
    [HttpDelete("{id:int}")]
    public IResult DeleteComment(int id)
    {
        _commentRepository.DeleteComment(id);
        return Results.Ok();
    }
}
