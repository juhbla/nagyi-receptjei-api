using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NagyiReceptjei.API.Controllers.Resources.Requests;
using NagyiReceptjei.API.Controllers.Resources.Responses;
using NagyiReceptjei.API.Models;
using NagyiReceptjei.API.Repositories;
using NagyiReceptjei.API.Utilities.Exceptions;

namespace NagyiReceptjei.API.Controllers;

[ApiController]
[EnableCors("DefaultCorsPolicy")]
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

    // GET: api/users
    [HttpGet]
    public IResult AuthenticateUser([FromQuery] AuthenticationRequest request)
    {
        try
        {
            var user = _userRepository.GetUser(request.Username, request.Password);

            if (user == null)
            {
                throw new Exception($"Invalid username or password.");
            }

            var userResponse = _mapper.Map<User, GetUserResponse>(user);

            return Results.Ok(userResponse);
        }
        catch (Exception exception)
        {
            return Results.BadRequest(exception.Message);
        }
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
