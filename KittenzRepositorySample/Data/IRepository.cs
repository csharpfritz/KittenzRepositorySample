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

}
