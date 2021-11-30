using BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Models;
using Models.ConcertAPI;
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

		public ConcertApiRepository(IConfiguration config, HttpClient httpClient)
		{
			_httpClient = httpClient;
			_url = config.GetSection("ConcertApiOptions")["Url"];
			_clientId = config.GetSection("ConcertApiOptions")["ClientId"];
		}

		public async Task<List<Concert>> GetAllConcerts()
		{
			string url = $"{_url}?type=concert&client_id={_clientId}";

			HttpResponseMessage response = await _httpClient.GetAsync(url);
			if (!response.IsSuccessStatusCode)
			{
				throw new Exception($"Error Get HttpClient, status code {response.StatusCode}");
			}

			string content = await response.Content.ReadAsStringAsync();
			if (content == null)
			{
				throw new ArgumentNullException("Event content is null");
			}

			var Jobject = JObject.Parse(content);
			var concerts = Jobject["events"].ToObject<List<Concert>>();

			return(concerts);
		}

	}
}
