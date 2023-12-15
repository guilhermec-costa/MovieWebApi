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


    }
}