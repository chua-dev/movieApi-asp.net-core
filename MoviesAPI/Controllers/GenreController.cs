using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesAPI.Entities;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenreController : ControllerBase
	{
		private readonly IRepository _repository;
		private readonly ILogger<GenreController> logger;

		public GenreController(IRepository repository, ILogger<GenreController> logger)
		{
			_repository = repository;
		}


		[HttpGet] // Configure request method
		[HttpGet("list")] // api/genre/list, both shared
		[HttpGet("/allgenre")] // /allgenre, overwrite base url
		public async Task<List<Genre>> GetAllGenres()
		{
			logger.LogInformation("Getting all the genres");
			return await _repository.GetAllGenres();
		}

		[HttpGet("{Id:int}")] //Path Parameters, = default value, : route constraint
		public ActionResult<Genre> Get(int Id,[BindRequired] string param2)
		{
			/*
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			} api controller replace this*/
			logger.LogDebug("get by id method executing");

			var genre = _repository.GetGenreById(Id);
			if (genre == null)
			{
				logger.LogWarning($"Genre with Id {Id} not found");
				return NotFound();
			}
			return genre;
		}

		[HttpPost]
		public ActionResult<Genre> PostGenres([FromBody] Genre genre)
		{

			_repository.AddGenre(genre);
			return NoContent();
		}

		[HttpPut]
		public void EditGenre([FromBody] Genre genre)
		{

		}

		[HttpDelete]
		public void DeleteGenre()
		{

		}

	}
}

