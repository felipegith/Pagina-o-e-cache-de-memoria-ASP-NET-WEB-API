using AutoMapper;
using ECONOMY.API.Database;
using ECONOMY.API.Entities;
using ECONOMY.API.Model;

namespace ECONOMY.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AccountVO, Account>();
                config.CreateMap<Account, AccountVO>();

                config.CreateMap<BalanceVO, Balance>();
                config.CreateMap<Balance, BalanceVO>();
            });
            return mappingConfig;
        }
    }
}
