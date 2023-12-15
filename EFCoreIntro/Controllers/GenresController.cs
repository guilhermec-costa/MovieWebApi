using Microsoft.AspNetCore.Mvc;
using EFCoreIntroduction.DBContext;
using EFCoreIntroduction.Entities;
using EFCoreIntroduction.DTOs;


namespace EFCoreIntroduction.Controllers
{

    [ApiController]
    [Route("api/genres")] // http://localhost:3300/api/genres
    public class GenresController : ControllerBase
    {
        private readonly DataContext _ctx;
        public GenresController(DataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]
        public async Task<ActionResult> PostGenre(GenreCreationDTO genre)
        {
            _ctx.Add(genre);
            await _ctx.SaveChangesAsync();
            return Ok();
        }
    }
}