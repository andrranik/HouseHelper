using System;

namespace HouseHelper.Models
{
    public class MoneyOperation
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public Guid CategoryId { get; set; } 
        public Category Category { get; set; }
        public Guid CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public MoneyOperationType Type { get; set; }
        public DateTime Date { get; set; }
    }
}