using System.Collections.ObjectModel;
using HouseHelper.ViewModel.Models;

namespace HouseHelper.ViewModel
{
    public abstract class BaseViewModel
    {
        protected void ProcessTasks()
        {
        }

        #region props

        protected ReadOnlyObservableCollection<ExceptionInfo> _exceptions;
        public ReadOnlyObservableCollection<ExceptionInfo> Exceptions => _exceptions;

        #endregion
    }
}