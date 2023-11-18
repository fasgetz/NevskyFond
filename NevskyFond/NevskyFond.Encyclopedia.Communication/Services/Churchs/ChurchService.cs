using AutoMapper;
using MassTransit;
using NevskyFond.Encyclopedia.Communication.Contracts.Churchs.Requests;
using NevskyFond.Encyclopedia.Communication.Contracts.Churchs.Responses;
using NevskyFond.Encyclopedia.Communication.Models.Commands;
using NevskyFond.Encyclopedia.Communication.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Communication.Services.Churchs
{
    public class ChurchService : IChurchService
    {
        private readonly IMapper _mapper;
        private readonly IRequestClient<AddChurchConsumerRequest> _requestClient;

        public ChurchService(IMapper mapper, IRequestClient<AddChurchConsumerRequest> requestClient)
        {
            _mapper = mapper;
            _requestClient = requestClient;
        }

        /// <summary>
        /// Добавление религиозного учреждения
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<AddChurchInterserviceResult> AddChurchAsync(AddChurchInterserviceCommand command)
        {
            var request = _mapper.Map(command, new AddChurchConsumerRequest());

            var addChurchResponse = await _requestClient.GetResponse<AddChurchConsumerResponse>(request, default(CancellationToken));

            if (addChurchResponse.Message == null)
            {
                return null;
            }

            var result = _mapper.Map(addChurchResponse.Message, new AddChurchInterserviceResult());

            return result;
        }
    }
}
