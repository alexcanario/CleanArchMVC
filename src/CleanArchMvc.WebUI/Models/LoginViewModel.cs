namespace CleanArchMvc.WebUI.Models;

public class LoginViewModel(string returnUrl)
{
    public LoginViewModel(string email, string password, string returnUrl) : this(returnUrl)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }

    public string Password { get; set; }

    public string ReturnUrl { get; set; } = returnUrl;
}