using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace KittenzRepositorySample.Data
{
	public class GitHubRepository : IRepository
	{
		private const string url = "https://raw.githubusercontent.com/csharpfritz/KittenzRepositorySample/master/data/dadjokes.json";
		private IList<DadJoke> _Jokes;

		public GitHubRepository(IHttpClientFactory clientFactory)
		{

			var client = clientFactory.CreateClient();
			client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
			var response = client.GetAsync(url).GetAwaiter().GetResult();

			var serializeOptions = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				WriteIndented = true
			};
			var jokeText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			_Jokes = JsonSerializer.Deserialize<DadJokeCollection>(jokeText, serializeOptions).Jokes.ToList();

		}

		public IQueryable<DadJoke> Get()
		{
			return _Jokes.AsQueryable();
		}

		public DadJoke GetById(int id)
		{
			return _Jokes.FirstOrDefault(j => j.Id == id);
		}

		public DadJoke GetRandom()
		{
			return _Jokes.OrderBy(j => Guid.NewGuid()).First();
		}
	}


	public class DadJokeCollection
	{
		public DadJoke[] Jokes { get; set; }
	}

}
