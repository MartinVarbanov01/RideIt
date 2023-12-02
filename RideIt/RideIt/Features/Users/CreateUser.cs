using Carter;
using MediatR;
using RideIt.Infrastructure;
using RideIt.Services;

namespace RideIt.Features.Users;

public class CreateUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/user", async (CreateUserCommand request, ISender sender) =>
            {
                var result = await sender.Send(request);

                return TypedResults.Ok(result);
            })
            .WithName("CreateUser");
    }
}

public class CreateUserCommand : IRequest<User>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public IFormFile Image { get; set; }
}

internal sealed class CreateUserHamdler : IRequestHandler<CreateUserCommand, User>
{
    private readonly RideItDbContext _context;
    private readonly UserManager _userManager;
    public CreateUserHamdler(RideItDbContext context, UserManager userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _userManager.CreateUser(request);

        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(user);
    }
}