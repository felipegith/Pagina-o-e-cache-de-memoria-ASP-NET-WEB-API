using ECONOMY.API.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECONOMY.API.Database
{
    [Table("SALDO")]
    public class Balance
    {
        public Balance()
        {
            Accounts = new List<Account>();
        }

        [Column("MACADDRESS")]
        public string Macaddress { get; set; }
        public long Id { get; set; }
        [Column("SALDOTOTAL")]
        public decimal Value { get; set; }
        [Column("CONTAS")]
        public List<Account> Accounts { get; set; }
    }
}
