using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DynamicData;
using HouseHelper.Services.Interfaces;
using HouseHelper.ViewModel.Models;
using ReactiveUI;

namespace HouseHelper.ViewModel
{
    public class MainViewModel : ReactiveObject
    {
        private readonly ReadOnlyObservableCollection<MoneyOperationDto> _uiItems;
        private string _theText;

        public MainViewModel(IMapper map,
            IMoneyOperationService moneyOperationService)
        {
            moneyOperationService.ReadSource()
                .ContinueWith(ProcessTasks);

            moneyOperationService
                .Connect()
                .Transform(x => map.Map<MoneyOperationDto>(x))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _uiItems)
                .DisposeMany()
                .Subscribe();
        }

        public string TheText
        {
            get => _theText;
            set => this.RaiseAndSetIfChanged(ref _theText, value);
        }

        public ReadOnlyObservableCollection<MoneyOperationDto> UiItems => _uiItems;

        private void ProcessTasks(Task task)
        {
        }
    }
}