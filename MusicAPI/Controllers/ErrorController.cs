using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ErrorController : ControllerBase
	{	
		[Route("/Error")]
		[HttpGet]
		public IActionResult Error()
		{
			var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
			return Problem(exception.Error.Message);
		}
	}
}
