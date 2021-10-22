using BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class ConcertApiRepository : IConcertApiRepository
	{
		private readonly HttpClient _httpClient;
		private readonly string _url;
		private readonly string _clientId;
		private readonly ILogger<ConcertApiRepository> _logger;

		public ConcertApiRepository(IConfiguration config, HttpClient httpClient, ILogger<ConcertApiRepository> logger)
		{
			_httpClient = httpClient;
			_url = config.GetSection("ConcertApiOptions")["Url"];
			_clientId = config.GetSection("ConcertApiOptions")["ClientId"];
			_logger = logger;
		}

		public async Task<List<Concert>> GetAllConcerts()
		{
			string url = $"{_url}?type=concert&client_id={_clientId}";

			HttpResponseMessage response = await _httpClient.GetAsync(url);
			if (!response.IsSuccessStatusCode)
			{
				_logger.LogError($"Error Get HttpClient, status code {response.StatusCode}");
				throw new Exception($"Error Get HttpClient, status code {response.StatusCode}");

			}

			string content = await response.Content.ReadAsStringAsync();
			if (content == null)
			{
				_logger.LogError($"Event content is null");
				throw new ArgumentNullException("Event content is null");
			}

			var Jobject = JObject.Parse(content);
			var concerts = Jobject["events"].ToObject<List<Concert>>();

			return(concerts);
		}

	}
}
