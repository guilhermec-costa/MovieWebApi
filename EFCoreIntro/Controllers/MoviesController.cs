using EFCoreIntroduction.DBContext;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using EFCoreIntroduction.DTOs;
using EFCoreIntroduction.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreIntroduction.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;
        public MoviesController(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(MovieCreationDTO movieCreationDTO)
        {
            var movie = _mapper.Map<Movie>(movieCreationDTO);
            if (movie.Genres is not null)
            {
                foreach (var genre in movie.Genres)
                {
                    // a entitdade está sendo trackeada, mas não está no banco ainda
                    _ctx.Entry(genre).State = EntityState.Unchanged;
                }
            }

            for (int i = 0; i < movie.MoviesActors.Count; ++i)
            {
                movie.MoviesActors[i].Order = i + 1;
            }

            _ctx.Add(movie);
            await _ctx.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id:int}/modern")]
        public async Task<ActionResult> Delete(int id)
        {
            var removedRows = await context.Movies.Where(g => g.Id == id).ExecuteDeleteAsync();

            if (removedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
