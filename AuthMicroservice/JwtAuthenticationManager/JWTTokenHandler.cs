using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuthenticationManager.Model;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthenticationManager;

public class JWTTokenHandler //This generates JWT Tokens but does not validate it 
{
    public const string JWT_SECRET_KEY = "dkjdkjniewdnewknlkmlqsqwiehefbcksmxamsdnwqwjs38ee";
    private const int JWT_TOKEN_VALIDITY = 420;
    private readonly List<UserAccount> _userAccounts;
    public JWTTokenHandler()
    {
        _userAccounts = new List<UserAccount>
        {
            new UserAccount(){ UserName = "admin", Password = "admin", Role = "admin" },
            new UserAccount(){ UserName = "user", Password = "user", Role = "user" }
        };
    }

    public AuthenticationResponse GenerateToken(AuthenticationRequest request)
    {
        if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
        {
            return null;
            
        }
        var user = _userAccounts.Where(x => x.UserName == request.Username && x.Password==request.Password)
            .FirstOrDefault();
        if (user == null)
            return null;
        
        var tokenExpiryTime = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY);
        var tokenKey = Encoding.ASCII.GetBytes(JWT_SECRET_KEY);
        var claimsIdentity = new ClaimsIdentity(new List<Claim> //to ckeck for token is not tampered
        {
            new Claim(ClaimTypes.Name, request.Username),
            new Claim(ClaimTypes.Role, user.Role)
        });
        
        var signInCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature); //adding security to token key 
        var secrityTokenDescription = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = tokenExpiryTime,
            SigningCredentials = signInCredentials
        };
        
        var JwtSecuirtyTokenHandler = new JwtSecurityTokenHandler();
        var securityToken = JwtSecuirtyTokenHandler.CreateToken(secrityTokenDescription); //securityToken class type generated, reciever might require string 
        
        var token = JwtSecuirtyTokenHandler.WriteToken(securityToken); //converts to string 

        return new AuthenticationResponse
        {
            UserName = user.UserName,
            ExpirationTime = (int)tokenExpiryTime.Subtract(DateTime.Now).TotalSeconds,
            Token = token
        };


    }
}