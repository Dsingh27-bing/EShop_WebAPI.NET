namespace AuthenticationApplicationCore.Model;

public class UserRequestModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string UserName { get; set; }
    public string EmailId { get; set; }
    public string Password { get; set; }
    public string? Salt { get; set; }
}