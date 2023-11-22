using Microsoft.EntityFrameworkCore;
using NagyiReceptjei.API.Models;

namespace NagyiReceptjei.API.Repositories;

public class CommentRepository
{
    private readonly ApplicationDbContext _context;

    public CommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Comment GetCommentById(int id)
    {
        return _context.Comments
            .Include(comment => comment.User)
            .Where(comment => comment.Id == id)
            .SingleOrDefault();
    }

    public Comment Add(Comment comment)
    {
        var newComment = _context.Comments.Add(comment).Entity;
        _context.SaveChanges();
        return newComment;
    }

    public void DeleteComment(int id)
    {
        var commentToDelete = GetCommentById(id);
        _context.Comments.Remove(commentToDelete);
        _context.SaveChanges();
    }
}
