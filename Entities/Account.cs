using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECONOMY.API.Entities
{
    [Table("CONTA")]
    public class Account
    {
        public long Id { get; set; }

        [Column("CONTA")]
        public string Title { get; set; }
        [Column("IDENTIFICADOR")]
        public string Identify { get; set; }

        [Column("PRECO")]
        public Decimal Price { get; set; }

        [Column("DATADOPAGAMENTO")]
        public DateTime Payment { get; set; }

        [Column("CRIADOEM")]
        public DateTime CreatedAt { get; set; }

        public long IdBalance { get; set; }
    }
}
