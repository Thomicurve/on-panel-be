namespace Application;

public interface IAuthService
{
    public LoginOutput Login(LoginInput input);
}
