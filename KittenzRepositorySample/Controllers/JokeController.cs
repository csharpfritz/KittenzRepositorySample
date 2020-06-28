using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KittenzRepositorySample.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KittenzRepositorySample.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JokeController : ControllerBase
	{
		private readonly IRepository _Repository;

		public JokeController(IRepository repository)
		{
			_Repository = repository;
		}

		public ActionResult<DadJoke> Get() {

			return Ok(_Repository.GetRandom());

		}

	}
}
