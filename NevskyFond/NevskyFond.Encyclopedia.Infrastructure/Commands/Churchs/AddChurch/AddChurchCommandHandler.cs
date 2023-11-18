using AutoMapper;
using MediatR;

namespace NevskyFond.Encyclopedia.Infrastructure.Commands.Encyclopedia.AddChurch
{
    public class AddChurchCommandHandler : IRequestHandler<AddChurchCommand, AddChurchCommandResult>
    {
        private readonly IMapper _mapper;

        public Task<AddChurchCommandResult> Handle(AddChurchCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //private readonly IChurchService _churchService;

        //public AddChurchCommandHandler(IMapper mapper, IChurchService churchService)
        //{
        //    _mapper = mapper;
        //    _churchService = churchService;
        //}

        //public async Task<AddChurchCommandResult> Handle(AddChurchCommand request, CancellationToken cancellationToken)
        //{
        //    var serviceCommand = _mapper.Map(request, new AddChurchInterserviceCommand());

        //    var addedChurch = await _churchService.AddChurchAsync(serviceCommand);

        //    var result = _mapper.Map(addedChurch, new AddChurchCommandResult());

        //    return result;
        //}
    }
}
