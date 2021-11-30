using DAL;
using Microsoft.Extensions.Logging;
using System.Linq;
using System;
using Models;
using System.Collections.Generic;
using BLL.Interfaces;
using System.Threading.Tasks;
using Models.ConcertAPI;

namespace BLL.Services
{
	public class ConcertJob : IConcertJob
	{
		private readonly ILogger<ConcertJob> _logger;
		private readonly IConcertService _concertService;
		private readonly IConcertApiRepository _concertApi;


		public ConcertJob(ILogger<ConcertJob> logger,
								  IConcertService concertService,
								  IConcertApiRepository concertApi)
		{
			_logger = logger;
			_concertService = concertService;
			_concertApi = concertApi;
		}

		public async Task DeleteOldConcerts()
		{
			var allConcerts = await _concertService.GetAll();
			var oldConcerts = allConcerts.Where(c => c.Datetime_Local < DateTime.Now).ToList();
			await _concertService.RemoveConcerts(oldConcerts);
			_logger.LogInformation($"Old concerts(count: {oldConcerts.Count()}) successfully deleted");
		}

		public async Task AddNewConcerts()
		{
			IEnumerable<Concert> newConcerts = await _concertApi.GetAllConcerts();
			if (newConcerts != null)
			{
				await _concertService.AddRange(newConcerts);
			}
			_logger.LogInformation($"New concerts(count: {newConcerts.Count()}) successfully added");
		}
	}
}
