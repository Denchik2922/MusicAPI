using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class AuthService : BaseGenericService<User>, IAuthService
	{
		private readonly string _secret;
		public AuthService(MusicContext context, IConfiguration config) : base(context)
		{
			_secret = config.GetSection("JwtSettings")["Secret"];
		}

		public override async Task<IEnumerable<User>> GetAll()
		{
			return await _context.Users
				.Include(u => u.Role)
				.AsNoTracking()
				.ToListAsync();
		}

		public User GetByIdWithInclude(int id)
		{
			var user = _context.Users.Include(u => u.Role)
						.AsNoTracking()
						.FirstOrDefault(x => x.Id == id);
			return user;
		}

		public async Task Register(User user)
		{
			user.Role = _context.Roles.
						Where(r => r.Name == "User").
						FirstOrDefault();
			if (user.Role == null)
			{
				user.Role = new Role { Name = "User" };
			}
			await Add(user);
		}

		public string Authenticate(string username, string password)
		{
			var user = _context.Users
						.Include(u => u.Role)
						.AsNoTracking()
						.SingleOrDefault(x => x.Username == username && x.Password == password);

			if (user == null)
			{
				throw new ArgumentNullException($"User with username - {username} not found");
			}

			string token = GenerateJwtToken(user);

			return token;
		}

		private string GenerateJwtToken(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Id.ToString()),
					new Claim(ClaimTypes.Role, user.Role.Name)
				}),
				Expires = DateTime.UtcNow.AddHours(2),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
