using RideIt.Features.Users;

namespace RideIt.Services.Abstraction;

public interface IUserManager
{
    Task<User?> GetByEmailAsync(string userName);
    User CreateUser(CreateUserCommand request);
}