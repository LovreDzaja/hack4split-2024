using hack4splitBORBAapi.Context;
using hack4splitBORBAapi.Helpers;
using hack4splitBORBAapi.Model;
using hack4splitBORBAapi.Model.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace hack4splitBORBAapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public UserController(AppDbContext dbContext) {
            _dbContext = dbContext;
        }

        // POST: authenticate
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserModelDTOForLogin userObj) {

            if (userObj == null)
                return BadRequest();

            if (string.IsNullOrEmpty(userObj.Username) || string.IsNullOrEmpty(userObj.Password))
                return BadRequest(new {
                    Message = "Please fill in the forms."
                });

            var user = await _dbContext.Users!.FirstOrDefaultAsync(x => x.Username == userObj.Username);

            if (user == null)
                return NotFound(new {
                    Message = "User Not Found."
                });

            if (!PasswordHasher.VerifyPassword(userObj.Password, user.Password)) {
                return BadRequest(new {
                    Message = "Password is Incorrect."
                });
            }

            return Ok(new {
                Message = "Login Success."
            });
        }

        // POST: register
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] UserModelDTO userObj) {
            
            if (userObj == null)
                return BadRequest();

            if (await CheckUserNameExistAsync(userObj.Username!))
                return BadRequest(new {
                    Message = "Username Already Exists."
                });

            if (await CheckEmailExistAsync(userObj.Email!))
                return BadRequest(new {
                    Message = "Email Already Exists."
                });

            var pass = CheckPasswordStrength(userObj.Password!);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new {
                    Message = pass.ToString()
                });

            UserModel user = new UserModel {
                Id = 0,
                Username = userObj.Username,
                Email = userObj.Email,
                Password = userObj.Password,
                Ratings = null!
            };

            user.Password = PasswordHasher.HashPassword(user.Password!);

            await _dbContext.Users!.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return Ok(new {
                Message = "User Registered!"
            });
        }

        [HttpGet]
        [Route("getUsers")]
        public async Task<IEnumerable<UserModel>> GetUsers(){

            var users = await _dbContext.Users!.ToListAsync();

            return users;
        }

        private Task<bool> CheckUserNameExistAsync(string username)
            => _dbContext.Users!.AnyAsync(x => x.Username == username);

        private Task<bool> CheckEmailExistAsync(string email)
            => _dbContext.Users!.AnyAsync(x => x.Email == email);

        private string CheckPasswordStrength(string password) {
            StringBuilder sb = new StringBuilder();

            if (password.Length < 8)
                sb.Append("Minimum password length should be 8" + Environment.NewLine);
            if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "[0-9]")))
                sb.Append("Password should be Alphanumeric" + Environment.NewLine);

            return sb.ToString();
        }
    }
}
