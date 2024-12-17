using CleanArchitecture.Application.Users.Commands.CreateUser;
using CleanArchitecture.Application.Users.Queries;
using CleanArchitecture.Application.Users.Queries.GetUser;
using CleanArchitecture.Contracts.Users;
using CleanArchitecture.Domain;
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
        var user = new User
        {
            Id = request.Id,
            Username = request.Username,
        };
        
        var command = new CreateUserCommand(user);

        var createUserResult = await mediator.Send(command);

        return createUserResult.Match(
            user => Created($"users/{user.Id}", new UserResponse(user.Id)),
            error => Problem());
    }

    [HttpGet]
    public async Task<IActionResult> GetUser(long userId)
    {
        var query = new GetUserQuery(userId);
        
        var getUserResult = await mediator.Send(query);
        
        return getUserResult.MatchFirst(
            user => Ok(new UserResponse(user.Id)),
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