using System;
using HouseHelper.Models;

namespace HouseHelper.ViewModel.Models
{
    public class MoneyOperationDto
    {
        public string CategoryName { get; set; }
        public decimal Value { get; set; }
        public string CurrencyFullName { get; set; }
        public string CurrencyShortName { get; set; }
        public DateTime Date { get; set; }
        public MoneyOperationType Type { get; set; }
    }
}