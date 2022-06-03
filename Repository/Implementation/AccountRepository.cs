using AutoMapper;
using ECONOMY.API.Database;
using ECONOMY.API.Entities;
using ECONOMY.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ECONOMY.API.Repository.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ServerContext _context;
        private IMapper _mapper;

        public AccountRepository(ServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AccountVO> GetByIdentify(string identify)
        {
            Account account = await _context.Accounts.SingleOrDefaultAsync(i => i.Identify == identify);
            return _mapper.Map<AccountVO>(account);
        }

        public async Task<AccountVO> Create(AccountVO account)
        {
            
            Account createAccount = _mapper.Map<Account>(account);
            _context.Accounts.Add(createAccount);
            await _context.SaveChangesAsync();
            return _mapper.Map<AccountVO>(createAccount);
        }


        public async Task<AccountVO> Update(AccountVO account)
        {
            Account createAccount = _mapper.Map<Account>(account);
            _context.Accounts.Update(createAccount);
            await _context.SaveChangesAsync();
            return _mapper.Map<AccountVO>(createAccount);
        }

        public async Task<bool> Delete(string identify)
        {
            try
            {
                Account account = await _context.Accounts.SingleOrDefaultAsync(i => i.Identify == identify);

                if (account == null)
                    return false;

                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
