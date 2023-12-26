using Microsoft.AspNetCore.Mvc;
using EFCoreIntroduction.DBContext;
using EFCoreIntroduction.Entities;
using EFCoreIntroduction.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace EFCoreIntroduction.Controllers
{

    [ApiController]
    [Route("api/genres")] // http://localhost:3300/api/genres
    public class GenresController : ControllerBase
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;
        public GenresController(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> PostGenre(GenreCreationDTO genreCreationDTO)
        {
            var genre = _mapper.Map<Genre>(genreCreationDTO);
            _ctx.Add(genre);// tracks the given entity
            await _ctx.SaveChangesAsync();
            return Ok();
        }


        [HttpPost("several")]
        public async Task<ActionResult> PostGenre(GenreCreationDTO[] genreCreationDTOs)
        {
            var genres = _mapper.Map<Genre[]>(genreCreationDTOs);
            _ctx.AddRange(genres);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> GetGenres()
        {
            return await _ctx.Genres.ToListAsync();
        }

        [HttpPut("{id:int}/name2")]
        public async Task<ActionResult> Put(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(g => g.Id == id);

            if (genre is null)
            {
                return NotFound();
            }

            genre.Name = genre.Name + "2";
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, GenreCreationDTO genreCreationDTO)
        {
            var genre = mapper.Map<Genre>(genreCreationDTO);
            genre.Id = id;
            context.Update(genre);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}/modern")]
        public async Task<ActionResult> Delete(int id)
        {
            var removedRows = await context.Genres.Where(g => g.Id == id).ExecuteDeleteAsync();

            if (removedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}/oldway")]
        public async Task<ActionResult> DeleteOldWay(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(g => g.Id == id);

            if (genre is null)
            {
                return NotFound();
            }

            context.Remove(genre);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
