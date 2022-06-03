using ECONOMY.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECONOMY.API.Repository
{
    public interface IBalanceRepository
    {
        Task<List<BalanceVO>> GetAll(string macaddress, int skip, int take);
        Task<BalanceVO> GetById(long id);
        Task<BalanceVO> CreateBalance(BalanceVO balance);
        Task<BalanceVO> Update(BalanceVO balance, long id);

    }
}
