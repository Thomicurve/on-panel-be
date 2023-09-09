namespace Application;

public interface IAuthService
{
    public LoginOutput Login(LoginInput input);
    public bool Register(RegisterInput input);
}
