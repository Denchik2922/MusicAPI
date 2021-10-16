using BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json.Linq;
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
			var content = await _httpClient.GetStringAsync(url);

			var Jobject = JObject.Parse(content);
			var concerts = Jobject["events"].ToObject<List<Concert>>();

			return(concerts);
		}

	}
}
