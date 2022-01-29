using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicData;
using HouseHelper.DataStorage.Repositories.Interfaces;
using HouseHelper.Models;
using HouseHelper.Services.Infrastructure;
using HouseHelper.Services.Interfaces;

namespace HouseHelper.Services.Implementation
{
    public class MoneyOperationsService : IMoneyOperationService
    {
        private readonly IMoneyOperationRepository _moneyOperationRepository;
        private readonly SourceCache<MoneyOperation, Guid> _moneyOperationSource;
        public IObservable<IChangeSet<MoneyOperation, Guid>> Connect() => _moneyOperationSource.Connect();

        public MoneyOperationsService(IMoneyOperationRepository moneyOperationRepository)
        {
            _moneyOperationRepository = moneyOperationRepository;
            _moneyOperationSource = new SourceCache<MoneyOperation, Guid>(x => x.Id);
            
        }

        public async Task ReadSource()
        {
            foreach (var item in await _moneyOperationRepository.GetAsync())
            {
                await Task.Delay(2000);
                _moneyOperationSource.AddOrUpdate(item);
            }
        }
    }
}