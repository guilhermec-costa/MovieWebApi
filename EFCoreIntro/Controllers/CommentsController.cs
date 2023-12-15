using EFCoreIntroduction.DBContext;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace EFCoreIntroduction.Controllers
{
    [ApiController]
    [Route("api/movies/{movieId:Guid}/comment")]
    public class CommentsController : ControllerBase
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;

        public CommentsController(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
    }
}