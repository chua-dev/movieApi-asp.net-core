using System;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Entities;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
	[Route("api/[controller]")]
	public class GenreController : ControllerBase
	{
		private readonly IRepository _repository;

		public GenreController(IRepository repository)
		{
			_repository = repository;
		}


		[HttpGet] // Configure request method
		[HttpGet("list")] // api/genre/list, both shared
		[HttpGet("/allgenre")] // /allgenre, overwrite base url
		public List<Genre> GetAllGenres()
		{
			return _repository.GetAllGenres();
		}

		[HttpGet("{Id:int}/{param2=defaultvalue}")] //Path Parameters, = default value, : route constraint
		public Genre Get(int Id, string param2)
		{
			var genre = _repository.GetGenreById(Id);
			if (genre == null)
			{
				//return NotFound();
			}
			return genre;
		}

		[HttpPost]
		public void PostGenres()
		{

		}

		[HttpPut]
		public void EditGenre()
		{

		}

		[HttpDelete]
		public void DeleteGenre()
		{

		}

	}
}

