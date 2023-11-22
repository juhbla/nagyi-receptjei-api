using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NagyiReceptjei.API.Exceptions;
using NagyiReceptjei.API.Models;
using NagyiReceptjei.API.Repositories;
using NagyiReceptjei.API.Resources.Requests;
using NagyiReceptjei.API.Resources.Responses;

namespace NagyiReceptjei.API.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class UsersController
{
    private readonly UserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersController(
        UserRepository userRepository,
        IMapper mapper
    )
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    // POST: api/users
    [HttpPost]
    public IResult RegisterUser([FromBody] CreateUserRequest request)
    {
        try
        {
            if (request.Password != request.ConfirmPassword)
            {
                throw new PasswordConfirmationException();
            }

            var user = _mapper.Map<CreateUserRequest, User>(request);
            var newUser = _userRepository.Add(user);
            var userResponse = _mapper.Map<User, GetUserResponse>(newUser);
            return Results.Ok(userResponse);
        }
        catch
        {
            return Results.BadRequest();
        }
    }
}
