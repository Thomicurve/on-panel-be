namespace Application;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Common.Repository;
using Infraestructure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IRepositoryBase<User> _userRepository;

    public AuthService(IConfiguration configuration, IRepositoryBase<User> userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }

    

    public LoginOutput Login(LoginInput input)
    {
        User user = new() { Email = input.Email, Password = input.Password, Id= 1 };
        string token = GenerateJwtToken(user);
        return new LoginOutput() { Token = token};
    }

    public bool Register(RegisterInput input)
    {
        if(input.Password != input.ConfirmPassword)
            throw new Exception("Las contraseñas no coinciden.");

        User? userExists = _userRepository.GetAll().Where(x => x.Email == input.Email).FirstOrDefault();

        if(userExists != null)
            throw new Exception("Ya existe un mail asociado a esa cuenta.");

        return true;
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim("email", user.Email),
            new Claim("userId", user.Id.ToString()),
        };

        try {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return jwt;
        } catch(Exception ex) {
            throw new Exception("Error al iniciar sesión: " + ex.Message);
        }
        
    }
}
