using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NevskyFond.Encyclopedia.Data.Store.Church;
using NevskyFond.Encyclopedia.Data.StoreModels.Church.Queries;
using NevskyFond.Encyclopedia.Infrastructure.Commands.Encyclopedia.AddChurch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Infrastructure.Queries.Churchs.GetChurchById
{
    public class GetChurchByIdHandler : IRequestHandler<GetChurchByIdQuery, GetChurchByIdHandlerResult>
    {
        private readonly IMapper _mapper;
        private readonly IChurchStore _churchStore;

        public GetChurchByIdHandler(IMapper mapper, IChurchStore churchStore)
        {
            _mapper = mapper;
            _churchStore = churchStore;
        }

        public async Task<GetChurchByIdHandlerResult> Handle(GetChurchByIdQuery request, CancellationToken cancellationToken)
        {
            var queryStore = _mapper.Map(request, new GetChurchByIdStoreQuery());

            var foundChurchResult = await _churchStore.GetChurchByIdAsync(queryStore);

            var result = _mapper.Map(foundChurchResult, new GetChurchByIdHandlerResult());

            return result;
        }
    }
}