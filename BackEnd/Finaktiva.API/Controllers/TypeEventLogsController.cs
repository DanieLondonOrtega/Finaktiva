using AutoMapper;
using Finaktiva.Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finaktiva.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeEventLogsController : Controller
    {
        private readonly ITypeEventLogsService _service;
        private readonly IMapper _mapper;
        public TypeEventLogsController(ITypeEventLogsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }
    }
}
