using System.ComponentModel.DataAnnotations;

namespace NagyiReceptjei.API.Controllers.Resources.Requests;

public class CreateUserRequest
{
    [EmailAddress]
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
