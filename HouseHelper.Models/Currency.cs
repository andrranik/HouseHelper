using System;

namespace HouseHelper.Models
{
    public class Currency
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
    }
}