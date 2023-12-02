using RideIt.Features.Users;

namespace RideIt.Features.Blogs;

public class Blog
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    
    public Guid AuthorId { get; set; }
    public User Author { get; set; }
}