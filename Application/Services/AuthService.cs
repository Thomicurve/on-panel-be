namespace Application;

public class AuthService : IAuthService
{
    public AuthService()
    {
    }

    public LoginOutput Login(LoginInput input)
    {
        return new LoginOutput() { Token = "token" };
    }
}
