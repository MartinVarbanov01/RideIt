using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RideIt.Infrastructure;

namespace RideIt.Features.Users;

public class GetUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/user", 
                async Task<Results<Ok<User>, NotFound>>(Guid id, ISender sender) =>
                {
                    var query = new GetUserQuery(id);
                    
                    var result = await sender.Send(query);

                    return result is null 
                        ? TypedResults.NotFound()
                        : TypedResults.Ok(result);
                })
            .WithName("GetUser");
    }
}

public record GetUserQuery(Guid Id) : IRequest<User?>;
    
internal sealed class GetFamilyMemberHandler : IRequestHandler<GetUserQuery,User?>
{
    private readonly RideItDbContext _db;

    public GetFamilyMemberHandler(RideItDbContext db)
    {
        _db = db;
    }

    public async Task<User?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await _db.Users.AsNoTracking().FirstOrDefaultAsync(fm =>fm.Id == request.Id,cancellationToken:cancellationToken);
    }
}