using BLL.Interfaces;
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
	public class StatisticController : ControllerBase
	{
		private readonly IStatisticService _statisticService;

		public StatisticController(IStatisticService statisticService)
		{
			_statisticService = statisticService;
		}

		/// <summary>
		/// Get five popular instruments
		/// </summary>
		[HttpGet]
		public IActionResult GetPopularInstruments()
		{
			return Ok(_statisticService.GetFivePopularInstruments());
		}

		/// <summary>
		/// Get the average cost of a concert today
		/// </summary>
		[HttpGet("concerts_average")]
		public IActionResult GetAverageCost()
		{
			return Ok(_statisticService.GetAverageCostConcert());
		}

		/// <summary>
		/// Get countries with most popular types musicians
		/// </summary>
		[HttpGet]
		[Route("country_musicans")]
		public IActionResult GetCountryWithMostMusicians()
		{
			return Ok(_statisticService.GetCountriesWithMostMusicians());
		}
	}
}

