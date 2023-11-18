using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NevskyFond.Encyclopedia.Api.Models.Requests.Churchs;
using NevskyFond.Encyclopedia.Api.Models.Responses.Churchs;
using NevskyFond.Encyclopedia.Infrastructure.Commands.Encyclopedia.AddChurch;
using NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetChurchById;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NevskyFond.Encyclopedia.Api.Controllers
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
        /// Получение религиозного учреждения
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<ActionResult<GetChurchByIdResponse>> GetChurchById([FromQuery] GetChurchByIdRequest request)
        {
            var query = _mapper.Map(request, new GetChurchByIdQuery());

            var foundChurchResult = await _mediator.Send(query);

            var response = _mapper.Map(foundChurchResult, new GetChurchByIdResponse());

            return Ok(response);
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