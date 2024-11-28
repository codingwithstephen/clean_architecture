using MediatR;

namespace CleanArchitecture.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, long>
{
    public Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(request.Id);
    }
}