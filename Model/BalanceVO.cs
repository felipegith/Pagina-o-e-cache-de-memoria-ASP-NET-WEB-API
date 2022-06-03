using ECONOMY.API.Entities;
using System.Collections.Generic;

namespace ECONOMY.API.Model
{
    public class BalanceVO
    {
        public long Id { get; set; }
        public decimal Value { get; set; }
        public string Macaddress { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
