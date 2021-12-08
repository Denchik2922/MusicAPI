using BLL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class AuthService : IAuthService
	{
		private readonly string _secret;
		private readonly UserManager<IdentityUser> _userManager;

		public AuthService(UserManager<IdentityUser> userManager, IConfiguration config)
		{
			_secret = config.GetSection("JwtSettings")["Secret"];
			_userManager = userManager;
		}

		public async Task<IEnumerable<IdentityUser>> GetAll()
		{
			return await _userManager.Users.ToListAsync();
		}

		public async Task Register(IdentityUser user, string password)
		{
			var result = await _userManager.CreateAsync(user, password);
			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					throw new Exception($"Code: {error.Code}, Description: { error.Description}");
				}
			}
			await _userManager.AddToRoleAsync(user, "User");

		}

		public async Task<bool> ChangePassword(string UserId, string OldPassword, string NewPassword)
		{
			var user = await _userManager.FindByIdAsync(UserId);
			if (user != null)
			{
				IdentityResult result =
					await _userManager.ChangePasswordAsync(user, OldPassword, NewPassword);
				if (!result.Succeeded)
				{
					foreach (var error in result.Errors)
					{
						throw new Exception($"Code: {error.Code}, Description: { error.Description}");
					}
				}
				return result.Succeeded;
			}
			else
			{
				throw new ArgumentNullException($"{typeof(IdentityUser).Name} item with id {UserId} not found.");
			}

		}

		public async Task<string> Authenticate(string username, string password)
		{	
			var user = await _userManager.FindByNameAsync(username);
			if (user != null &&
				await _userManager.CheckPasswordAsync(user, password))
			{
				IList<string> roles = await _userManager.GetRolesAsync(user);
				string token = GenerateJwtToken(user, roles);

				return token;
			}
			else
			{
				throw new Exception("Authenticate error");
			}
			
		}

		private string GenerateJwtToken(IdentityUser user, IList<string> roles)
		{
			var tokenHandler = new JwtSecurityTokenHandler();

			var key = Encoding.ASCII.GetBytes(_secret);

			List<Claim> claims = roles.Select(r => new Claim(ClaimTypes.Role, r)).ToList();
			claims.Add(new Claim(ClaimTypes.Name, user.UserName));
			claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.AddMinutes(10),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
