using AutoMapper;
using MediatR;
using NevskyFond.Encyclopedia.Communication.Models.Commands;
using NevskyFond.Encyclopedia.Communication.Services.Churchs;

namespace NevskyFond.Encyclopedia.Infrastructure.Commands.Encyclopedia.AddChurch
{
    public class AddChurchCommandHandler : IRequestHandler<AddChurchCommand, AddChurchCommandResult>
    {
        private readonly IMapper _mapper;
        private readonly IChurchService _churchService;

        public AddChurchCommandHandler(IMapper mapper, IChurchService churchService)
        {
            _mapper = mapper;
            _churchService = churchService;
        }

        public async Task<AddChurchCommandResult> Handle(AddChurchCommand request, CancellationToken cancellationToken)
        {
            var serviceCommand = _mapper.Map(request, new AddChurchInterserviceCommand());

            var addedChurch = await _churchService.AddChurchAsync(serviceCommand);

            var result = _mapper.Map(addedChurch, new AddChurchCommandResult());

            return result;
        }
    }
}
