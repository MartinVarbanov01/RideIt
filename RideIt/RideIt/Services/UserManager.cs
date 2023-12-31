using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RideIt.Features.Users;
using RideIt.Infrastructure;
using RideIt.Services.Abstraction;

namespace RideIt.Services;

public class UserManager
{
    private readonly IPasswordHasher<User> _hasher;
    private readonly RideItDbContext _context;
    private readonly IFileSystemService _fileSystemService;

    public UserManager(IPasswordHasher<User> hasher,RideItDbContext context,IFileSystemService fileSystemService)
    {
        _hasher = hasher;
        _context = context;
        _fileSystemService = fileSystemService;
    }
    public User CreateUser(CreateUserCommand request)
    {
        var user = new User()
        {
            FirstName = request.FirstName,
            SecondName = request.SecondName,
            UserName = request.UserName
        };
        
        user.Password = _hasher.HashPassword(user, request.Password);
        user.ImageUrl = _fileSystemService.GetImageUrl(request.Image);

        return user;
    }

    public async Task<User?> GetByEmailAsync(string userName)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

        return user;
    }
}