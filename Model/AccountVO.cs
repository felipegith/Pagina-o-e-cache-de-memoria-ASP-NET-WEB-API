using System;
using System.ComponentModel.DataAnnotations;

namespace ECONOMY.API.Model
{
    public class AccountVO
    {
        public AccountVO(string identify, DateTime createdAt)
        {
            Identify = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Identify { get; set; }
        [Required]
        public Decimal Price { get; set; }

        [Required]
        public DateTime Payment { get; set; }
       
        [Required]
        public DateTime CreatedAt { get; set; }

        public long IdBalance { get; set; }
    }
}
