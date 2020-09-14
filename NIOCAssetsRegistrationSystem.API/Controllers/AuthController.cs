using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NIOCAssetsRegistrationSystem.API.Data;
using NIOCAssetsRegistrationSystem.API.Dtos;
using NIOCAssetsRegistrationSystem.API.Models;

namespace NIOCAssetsRegistrationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IAssetRegistrationRepository _repoAssets;        

        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper, IAssetRegistrationRepository repoAssets)
        {
            this._repo = repo;
            this._config = config;
            this._mapper = mapper;
            this._repoAssets = repoAssets;            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //Validate request

            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();

            if (await _repo.UserExists(userForRegisterDto.UserName))
            {
                return BadRequest("User already exists!");
            }

            /* User to save to DB*/
            var userToCreate = _mapper.Map<User>(userForRegisterDto);

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            /* Adding related entities (Company and Usertpe) to the User (for Automapper to get return CompanyName and UserTypeName*/
            var companyCode = createdUser.CompanyId.GetValueOrDefault();
            createdUser.Company = _repoAssets.GetCompany(companyCode);

            var userTypeCode = createdUser.UserTypeId.GetValueOrDefault();
            createdUser.UserType = _repoAssets.GetUserType(userTypeCode);            

            /* Rertun the created user in UserToReturnDto format*/
            var userToReturn = _mapper.Map<UserToReturnDto>(createdUser);

            return CreatedAtRoute("GetUser", new { controller = "Users", id = createdUser.Id }, userToReturn);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.UserName.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Appsettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}