using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KittenzRepositorySample.Data
{

	public interface IRepository
	{

		IQueryable<DadJoke> Get();

		DadJoke GetRandom();

		DadJoke GetById(int id);

	}

	public class JsonRepository : IRepository
	{

		private static readonly List<DadJoke> _DadJokes;

		static JsonRepository()
		{
			LoadFromJson();
		}

		private static void LoadFromJson() {

			if (_DadJokes != null && _DadJokes.Any()) return;

			// do the thing to load the List<DadJoke>

		}

		public IQueryable<DadJoke> Get()
		{
			return _DadJokes.AsQueryable();
		}

		public DadJoke GetRandom() {
			return _DadJokes.OrderBy(j => Guid.NewGuid()).First();
		}

		public DadJoke GetById(int id)
		{
			return _DadJokes.FirstOrDefault(j => j.Id == id);
		}
	}

}
