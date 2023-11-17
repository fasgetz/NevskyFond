using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewskyFond.Portal.Gateway.Api.Models.Requests.Churchs;
using NewskyFond.Portal.Gateway.Infrastructure.Commands.Churchs.AddChurch;

namespace NewskyFond.Portal.Gateway.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChurchsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ChurchsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Добавление религиозного учреждения
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddChurch([FromBody]AddChurchRequest request)
        {
            var command = _mapper.Map(request, new AddChurchCommand());

            var result = await _mediator.Send(command);

            return Ok(command);
        }
    }
}
