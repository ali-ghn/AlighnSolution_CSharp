using AlighnSolution.Database;

namespace AlighnSolution.SSO;

public class UserPermission : DatabaseObject
{
    public string AvatarId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string TOTPSecret { get; set; }
    public bool EmailConfirmed { get; set; }
}