using Microsoft.AspNetCore.Identity;

namespace AlighnSolution.Configuration.SSO;

public class IdentityConfigurations
{
    public UserOptions User { get; set; } = new UserOptions()
    {
    };

    public PasswordOptions Password { get; set; } = new PasswordOptions()
    {
    };

    public LockoutOptions Lockout { get; set; } = new LockoutOptions()
    {
    };

    public SignInOptions SignIn { get; set; } = new SignInOptions()
    {
    };

    public TokenOptions Tokens { get; set; } = new TokenOptions()
    {
    };

    public StoreOptions Stores { get; set; } = new StoreOptions()
    {
    };
}