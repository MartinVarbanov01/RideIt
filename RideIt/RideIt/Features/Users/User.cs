namespace RideIt.Features.Users;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string ImageUrl { get; set; }
}