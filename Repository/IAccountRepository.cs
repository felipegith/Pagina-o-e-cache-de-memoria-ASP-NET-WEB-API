using ECONOMY.API.Model;
using System.Threading.Tasks;

namespace ECONOMY.API.Repository
{
    public interface IAccountRepository
    {
        Task<AccountVO> GetByIdentify(string identify);
        
        Task<AccountVO> Create(AccountVO account);
        Task<AccountVO> Update(AccountVO account);
        Task<bool> Delete(string identify);

    }
}
