using AutoMapper;
using Finaktiva.API.Hubs;
using Finaktiva.API.Models;
using Finaktiva.Aplication.Dtos;
using Finaktiva.Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Finaktiva.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventLogsController : Controller
    {
        private readonly IEventLogsService _service;
        private readonly IHubContext<EventLogsHub> _hubContext;
        private readonly IMapper _mapper;

        public EventLogsController(IHubContext<EventLogsHub> hubContext, IEventLogsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventLogsModel request)
        {
            var objRequest = _mapper.Map<EventLogsDto>(request);            
            var result = await _service.Post(objRequest);
            if (result)
            {
                await _hubContext.Clients.All.SendAsync("LoadingGetAll", true);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.Get(id);
            return Ok(result);
        }
    }
}
