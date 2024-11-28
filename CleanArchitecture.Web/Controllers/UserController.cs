using CleanArchitecture.Application.Services;
using CleanArchitecture.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        var user = _userService.CreateUser(request.Id);

        var response = new UserResponse(user);
        return Created($"users/{user}", response);
    }
}

public class UserResponse
{
    public long Id { get; set; }
    public UserResponse(long user)
    {
        Id = user;
    }
}