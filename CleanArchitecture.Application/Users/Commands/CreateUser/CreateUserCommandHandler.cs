using ErrorOr;
using MediatR;

namespace CleanArchitecture.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, ErrorOr.ErrorOr<long>>
{
    public async Task<ErrorOr<long>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return request.Id;
    }
}