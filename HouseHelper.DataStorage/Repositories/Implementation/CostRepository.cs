using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HouseHelper.DataStorage.Repositories.Interfaces;
using HouseHelper.Models;

namespace HouseHelper.DataStorage.Repositories.Implementation
{
    public class MoneyOperationRepository : BaseRepository<MoneyOperation>, IMoneyOperationRepository
    {
        public override IEnumerable<MoneyOperation> Get()
        {
            var r = new List<MoneyOperation>();
            for (var i = 0; i < 3; i++)
            {
                var item =
                    new MoneyOperation
                    {
                        Id = new Guid(),
                        Value = 4000,
                        CategoryId = new Guid(),
                        Category = null,
                        CurrencyId = new Guid(),
                        Currency = null,
                        Type = MoneyOperationType.Consumption,
                        Date = DateTime.Now
                    };
                r.Add(item);
            }

            return r;
        }

        public override async Task<IEnumerable<MoneyOperation>> GetAsync()
        {
            return await Task.Run(() =>
            {
                var r = new List<MoneyOperation>();

                var category = new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Аптека",
                    Description = "Описание аптеки"
                };

                var currency = new Currency
                {
                    Id = Guid.NewGuid(),
                    FullName = "Доллар США",
                    Description = "Валюта США",
                    ShortName = "USD"
                };

                r.Add(new MoneyOperation
                {
                    Id = Guid.NewGuid(),
                    Value = 30,
                    CategoryId = category.Id,
                    Category = category,
                    CurrencyId = currency.Id,
                    Currency = currency,
                    Type = MoneyOperationType.Consumption,
                    Date = DateTime.Now.AddDays(-1)
                });

                r.Add(new MoneyOperation
                {
                    Id = Guid.NewGuid(),
                    Value = 100,
                    CategoryId = category.Id,
                    Category = category,
                    CurrencyId = currency.Id,
                    Currency = currency,
                    Type = MoneyOperationType.Consumption,
                    Date = DateTime.Now.AddDays(-2)
                });

                r.Add(new MoneyOperation
                {
                    Id = Guid.NewGuid(),
                    Value = 5000,
                    CategoryId = category.Id,
                    Category = category,
                    CurrencyId = currency.Id,
                    Currency = currency,
                    Type = MoneyOperationType.Consumption,
                    Date = DateTime.Now
                });

                return r;
            });
        }

        public override async Task<MoneyOperation> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public override MoneyOperation Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override async Task<Guid> Insert(MoneyOperation item)
        {
            throw new NotImplementedException();
        }

        public override async Task<Guid> Update(MoneyOperation item)
        {
            throw new NotImplementedException();
        }

        public override async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}