namespace CleanArchMvc.Domain.Accounts;

public interface IAuthenticate
{
    Task<bool> Login(string email, string password);
    Task<bool> Register(string email, string password);
    Task Logout();
}