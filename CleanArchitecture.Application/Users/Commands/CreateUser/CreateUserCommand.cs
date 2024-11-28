using MediatR;

namespace CleanArchitecture.Application.Users.Commands.CreateUser;

public record CreateUserCommand(long Id): IRequest<long>;