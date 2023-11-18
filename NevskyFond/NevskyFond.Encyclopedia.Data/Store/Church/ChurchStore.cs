using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NevskyFond.Encyclopedia.Data.StoreModels.Church.Queries;
using NevskyFond.Encyclopedia.Data.StoreModels.Church.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevskyFond.Encyclopedia.Data.Store.Church
{
    /// <summary>
    /// Знаю я, что не паттерн репозиторий. Сам репозиторий можно использовать именно в Store
    /// </summary>
    /// <remarks>
    /// На текущий момент в целях демонстрации реализую обычный Store
    /// </remarks>
    public class ChurchStore : IChurchStore
    {
        private readonly EncyclopediaContext _dbContext;
        private readonly IMapper _mapper;

        public ChurchStore(EncyclopediaContext db, IMapper mapper)
        {
            _dbContext = db;
            _mapper = mapper;
        }

        public async Task<GetChurchByIdStoreResult> GetChurchByIdAsync(GetChurchByIdStoreQuery query)
        {
            var foundChurch = await _dbContext.Churchs
                .Where(e => e.Id == query.Id)
                .Select(e => _mapper.Map(e, new GetChurchByIdStoreDTO()))
                .FirstOrDefaultAsync();

            var result = new GetChurchByIdStoreResult()
            {
                Church = foundChurch
            };

            return result;
        }
    }
}
