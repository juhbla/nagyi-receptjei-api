using Microsoft.AspNetCore.Mvc;
using NagyiReceptjei.API.Models;

namespace NagyiReceptjei.API.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class UsersController
{
    // POST: api/users
    [HttpPost]
    public IResult RegisterUser([FromBody] User user)
    {
        return null;
    }
}
