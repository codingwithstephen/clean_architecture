using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain;
using ErrorOr;
using MediatR;

namespace CleanArchitecture.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr.ErrorOr<User>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = new Random().Next(1, 1000000000)
        };

        await _userRepository.AddUserAsync(user);
        await _unitOfWork.CommitChangesAsync();
        return user;
    }
}