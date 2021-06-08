using CATlinBE.BusinessLogicLayer;
using CATlinBE.DataAccessLayer.EntityDALs;
using CATlinBE.Entities;
using CATlinBE.WebApi.DTOs;
using CATlinBE.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CATlinBE.WebApi.Controllers
{
    public class AccountController : BaseAPIController
    {
        private readonly ITokenService _tokenService;

        public AccountController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if (await UserExists(registerDTO.Email)) return BadRequest("This email address is alrady registered.");


            using var hmac = new HMACSHA512();

            var user = new User
            {
                Email = registerDTO.Email,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
                PasswordSalt = hmac.Key
            };

            await Task.Run(() => new UserBLL
            {
                UserDAL = new UserDAL()
            }.RegisterUser(user));;


            return new UserDTO
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await Task.Run(() => new UserBLL
            {
                UserDAL = new UserDAL()
            }.GetUserByEmail(loginDTO.Email));

            if (user.Id == 0) return Unauthorized("Invalid email");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            for(int i = 0; i<computedHash.Length;i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDTO
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RoleId = user.RoleId,
                Token = _tokenService.CreateToken(user)
            };

        }

        private async Task<bool> UserExists(string email)
        {
            return await Task.FromResult(new UserBLL
            {
                UserDAL = new UserDAL()
            }.UserExists(email.ToLower()));
        }
    }
}
