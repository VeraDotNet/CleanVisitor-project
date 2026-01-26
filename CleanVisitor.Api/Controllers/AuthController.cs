using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    public AuthController(UserManager<AppUser> userManager,
                            SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    //Register
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var user = new AppUser
        {
            UserName = dto.Email,
            Email = dto.Email, 
            Name = dto.Name
        };
        try
        {
            var result = await _userManager.CreateAsync(user, dto.Password);
            const string DEFAULTROLE = "Receptionist";
            
            if(!result.Succeeded)
                return BadRequest(result.Errors);
            await _userManager.AddToRoleAsync(user, DEFAULTROLE);
            return Ok("User registered successfully");
            
        }
        catch(Exception e)
        {
            return BadRequest(e.InnerException?.Message ?? e.Message);
        }
    }

    //Login
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var result = await _signInManager.PasswordSignInAsync(
            dto.Email,
            dto.Password,
            isPersistent: false,
            lockoutOnFailure: false
        );
        if(!result.Succeeded)
            return Unauthorized("Invalid credentials");
        return Ok("login successful");
    }
}