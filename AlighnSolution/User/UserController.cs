using System.Net;
using AlighnSolution.Database;
using AlighnSolution.Email;
using AlighnSolution.Shared;
using AlighnSolution.SSO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlighnSolution.User;

internal interface IUserController
{
    Task<IActionResult> SignUpUser(UserRegistrationModel userRegistrationModel);
    Task<IActionResult> ConfirmUserEmail(UserEmailConfirmation userEmailConfirmation);
    Task<IActionResult> SignInUser(UserSignInModel userSignInModel);
    Task<IActionResult> LogoutUser();
}

[ApiController]
public class UserController : ControllerBase, IUserController
{
    private ILogger<UserController> _logger;
    private UserManager<User> _userManager;
    private RoleManager<UserRole> _roleManager;
    private SignInManager<User> _signInManager;
    private IGenericRepository<User> _repository;
    private IEmailService _emailService;

    public UserController(ILogger<UserController> logger, UserManager<User> userManager,
        RoleManager<UserRole> roleManager, SignInManager<User> signInManager, IGenericRepository<User> repository,
        IEmailService emailService)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _repository = repository;
        _emailService = emailService;
    }

    public async Task<IActionResult> SignUpUser([FromBody] UserRegistrationModel userRegistrationModel)
    {
        #region Model validation

        if (userRegistrationModel.Password != userRegistrationModel.ConfirmPassword)
            return StatusCode(HttpStatusCode.BadRequest.ToInt(),
                UserStatus.UserPasswordAndConfirmPasswordDoNotMatch);

        if (string.IsNullOrEmpty(userRegistrationModel.Password) ||
            string.IsNullOrEmpty(userRegistrationModel.Password) ||
            string.IsNullOrEmpty(userRegistrationModel.ConfirmPassword))
            return StatusCode(HttpStatusCode.BadRequest.ToInt(),
                GenericStatus.InputsAreNotMet);

        #endregion

        #region Business

        var user = new User() { Email = userRegistrationModel.Email };
        var identityResult = await _userManager.CreateAsync(user, userRegistrationModel.Password);
        if (!identityResult.Succeeded)
        {
            foreach (var error in identityResult.Errors)
                _logger.Log(LogLevel.Error, $"{DateTime.UtcNow} - {error.Code} - {error.Description}");
            return StatusCode(HttpStatusCode.InternalServerError.ToInt(), GenericStatus.SomethingWentWrong);
        }
        
        #endregion

        return StatusCode(HttpStatusCode.Accepted.ToInt(),
            UserStatus.UserHasBeenCreatedAndEmailConfirmationHasBeenSent);
    }

    public async Task<IActionResult> ConfirmUserEmail([FromBody] UserEmailConfirmation userEmailConfirmation)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> SignInUser([FromBody] UserSignInModel userSignInModel)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> LogoutUser()
    {
        throw new NotImplementedException();
    }
}