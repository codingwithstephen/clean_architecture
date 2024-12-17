using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain;
using ErrorOr;
using MediatR;

namespace CleanArchitecture.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateUserCommand, ErrorOr.ErrorOr<User>>
{
    public async Task<ErrorOr<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = new Random().Next(1, 1000000000),
            Username = request.User.Username,
        };

        await userRepository.AddUserAsync(user);
        await unitOfWork.CommitChangesAsync();
        return user;
    }
}