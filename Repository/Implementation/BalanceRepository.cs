using AutoMapper;
using ECONOMY.API.Database;
using ECONOMY.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECONOMY.API.Repository.Implementation
{

    public class BalanceRepository : IBalanceRepository
    {
        private readonly IMemoryCache _memoryCache;
        private const string KEYCACHE = "CACHE";
        private readonly ServerContext _context;
        private IMapper _mapper;

        public BalanceRepository(ServerContext context, IMapper mapper, IMemoryCache  memoryCache)
        {
            _memoryCache = memoryCache;
            _context = context;
            _mapper = mapper;
        }

        public async Task<BalanceVO> CreateBalance(BalanceVO balance)
        {
            Balance createBalance = _mapper.Map<Balance>(balance);
            _context.Balances.Add(createBalance);
            await _context.SaveChangesAsync();
            return _mapper.Map<BalanceVO>(createBalance);
        }

        public async Task<List<BalanceVO>> GetAll(string macaddress, int skip, int take)
        {
            if(_memoryCache.TryGetValue(KEYCACHE, out List<Balance> balances))
            {
                return _mapper.Map<List<BalanceVO>>(balances);
            }

                balances = await _context.Balances.
                Where(m => m.Macaddress == macaddress).
                AsNoTracking().
                Include(a => a.Accounts).
                Skip(skip).
                Take(take).
                ToListAsync();

            var memoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
                SlidingExpiration = TimeSpan.FromSeconds(1200)
            };

            _memoryCache.Set(KEYCACHE, balances, memoryCacheEntryOptions);
            return _mapper.Map<List<BalanceVO>>(balances);
        }

        public async Task<BalanceVO> GetById(long id)
        {
            Balance balance = await _context.Balances.Include(p => p.Accounts).SingleOrDefaultAsync(p => p.Id == id);
            if (balance == null)
                throw new ArgumentNullException();

            return _mapper.Map<BalanceVO>(balance);
        }

        public async Task<BalanceVO> Update(BalanceVO balance, long id)
        {
            Balance update = await _context.Balances.SingleOrDefaultAsync(i => i.Id == id);

            update.Value = balance.Value;

            return _mapper.Map<BalanceVO>(update);
        }
    }
}
