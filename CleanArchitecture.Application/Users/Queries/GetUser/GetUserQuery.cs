using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Users.Queries.GetUser;

public class GetUserQuery(long userId): IRequest<ErrorOr.ErrorOr<User>>
{
    public long UserId { get; set; }
}
