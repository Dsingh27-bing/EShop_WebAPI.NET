namespace JwtAuthenticationManager.Model;

public class AuthenticationResponse
{
    public string Token { get; set; }
    public string UserName { get; set; }
    public int ExpirationTime { get; set; }
}