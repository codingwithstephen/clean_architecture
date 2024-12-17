using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Users.Commands.CreateUser;

public record CreateUserCommand(User User): IRequest<ErrorOr.ErrorOr<User>>;