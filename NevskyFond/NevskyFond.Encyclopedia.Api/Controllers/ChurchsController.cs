using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NevskyFond.Encyclopedia.Api.Models.Requests.Churchs;
using NevskyFond.Encyclopedia.Api.Models.Responses.Churchs;
using NevskyFond.Encyclopedia.Infrastructure.Commands.Encyclopedia.AddChurch;
using NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetChurchById;
using NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetExtendedChurch;
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
            var query = _mapper.Map(request, new GetChurchByIdHandlerQuery());

            var foundChurchResult = await _mediator.Send(query);

            var response = _mapper.Map(foundChurchResult, new GetChurchByIdResponse());

            return Ok(response);
        }

        /// <summary>
        /// Получение расширенной информации о религиозном учреждении
        /// </summary>
        /// <returns>Возвращает расширенную информацию о религиозном учреждении</returns>
        [HttpPost("Extended/{id}")]
        public async Task<ActionResult<GetExtendedChurchResponse>> GetExtendedChurch([FromRoute] int id, [FromBody] GetExtendedChurchRequest request)
        {
            var query = _mapper.Map(request, new GetExtendedChurchHandlerQuery()
            {
                Id = id
            });

            var result = await _mediator.Send(query);

            // TODO в будущем, когда будет MiddleWare, он будет автоматически сопоставлять
            // кастомные ошибки и выдавать коды ответов
            if (result == null)
            {
                return NoContent();
            }

            var response = _mapper.Map(result, new GetExtendedChurchResponse());

            return response;
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