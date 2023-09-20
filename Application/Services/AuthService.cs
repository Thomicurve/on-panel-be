namespace Application;
using AutoMapper;
using Common.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IRepositoryBase<User> _userRepository;
    private readonly IMapper _mapper;

    public AuthService(
        IConfiguration configuration, 
        IRepositoryBase<User> userRepository, 
        IMapper mapper)
    {
        _configuration = configuration;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    

    public LoginOutput Login(LoginInput input)
    {
        User? userExists = _userRepository
            .GetAll()
            .Where(x => x.Email == input.Email)
            .FirstOrDefault();

        if(userExists == null) {
            throw new Exception("El usuario no existe.");
        }

        bool isPasswordRight = EncryptCommon.VerifyPassword(input.Password, userExists.Password);

        if(isPasswordRight == false) {
            throw new Exception("La contraseña es incorrecta.");
        }

        string token = GenerateJwtToken(userExists);
        return new LoginOutput() { Token = token};
    }

    public bool Register(RegisterInput input)
    {
        if(input.Password != input.ConfirmPassword)
            throw new Exception("Las contraseñas no coinciden.");

        User? userExists = _userRepository.GetAll().Where(x => x.Email == input.Email).FirstOrDefault();

        if(userExists != null)
            throw new Exception("Ya existe un mail asociado a esa cuenta.");

        input.Password = EncryptCommon.HashPassword(input.Password);

        _userRepository.Update(_mapper.Map<User>(input));
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
