using CleanArchitecture.Application.Users.Commands.CreateUser;
using CleanArchitecture.Contracts.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(ISender mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        var command = new CreateUserCommand(request.Id);

        var createUserResult = await mediator.Send(command);

        return createUserResult.Match(
            id => Created($"users/{createUserResult.Value}", createUserResult.Value),
            error => Problem());
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