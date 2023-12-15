using Microsoft.AspNetCore.Mvc;
using EFCoreIntroduction.DBContext;
using AutoMapper;
using EFCoreIntroduction.DTOs;
using EFCoreIntroduction.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreIntroduction.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController : ControllerBase
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;
        public ActorsController(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreationDTO actorCreationDTO)
        {
            var actor = _mapper.Map<Actor>(actorCreationDTO);
            _ctx.Add(actor);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("several")]
        public async Task<ActionResult> PostActors(ActorCreationDTO[] actorCreationDTOs)
        {
            var actors = _mapper.Map<Actor[]>(actorCreationDTOs);
            _ctx.AddRange(actors);
            await _ctx.SaveChangesAsync();
            return Ok();

        }

        [HttpGet]
        public async Task<ActionResult<List<Actor>>> GetActor()
        {
            return await _ctx.Actors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActors(Guid id)
        {
            return await _ctx.Actors.FindAsync(id);
        }
    }
}