using System;
using System.Threading.Tasks;
using DynamicData;
using HouseHelper.Models;

namespace HouseHelper.Services.Interfaces
{
    public interface IMoneyOperationService
    {
        IObservable<IChangeSet<MoneyOperation, Guid>> Connect();
        Task ReadSource();
    }
}