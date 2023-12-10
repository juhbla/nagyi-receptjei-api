using NagyiReceptjei.API.Models;

namespace NagyiReceptjei.API.Repositories;

public class UserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public User GetUser(string username, string password)
    {
        return _context.Users.SingleOrDefault(user =>
            user.Username == username &&
            user.Password == password);
    }

    public User Add(User user)
    {
        var newUser = _context.Users.Add(user).Entity;
        _context.SaveChanges();
        return newUser;
    }
}
