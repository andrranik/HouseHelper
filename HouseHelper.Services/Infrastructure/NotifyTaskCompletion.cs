using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HouseHelper.Services.Infrastructure
{
    public sealed class NotifyTaskCompletion<TResult> : INotifyPropertyChanged
    {
        private static List<TaskProperty> _taskProperties = new List<TaskProperty>
        {
            new TaskProperty("Status", x => true),
            new TaskProperty("IsCompleted", x => true),
            new TaskProperty("IsNotCompleted", x => true),
            new TaskProperty("IsCanceled", x => x.IsCanceled ),
            new TaskProperty("IsFaulted", x => x.IsFaulted ),
            new TaskProperty("Exception", x => x.IsFaulted ),
            new TaskProperty("InnerException", x => x.IsFaulted ),
            new TaskProperty("ErrorMessage", x => x.IsFaulted ),
            new TaskProperty("IsSuccessfullyCompleted", x => !x.IsFaulted && !x.IsCanceled ),
            new TaskProperty("Result", x => !x.IsFaulted && !x.IsCanceled ),
        };
        
        public NotifyTaskCompletion(Task<TResult> task)
        {
            Task = task;
            if (!task.IsCompleted)
            {
                var _ = WatchTaskAsync(task);
            }
        }

        public Task<TResult> Task { get; }

        public TResult Result =>
            Task.Status == TaskStatus.RanToCompletion ? Task.Result : default;

        public TaskStatus Status => Task.Status;
        public bool IsCompleted => Task.IsCompleted;
        public bool IsNotCompleted => !Task.IsCompleted;

        public bool IsSuccessfullyCompleted =>
            Task.Status ==
            TaskStatus.RanToCompletion;

        public bool IsCanceled => Task.IsCanceled;
        public bool IsFaulted => Task.IsFaulted;
        public AggregateException Exception => Task.Exception;

        public Exception InnerException =>
            Exception?.InnerException;

        public string ErrorMessage =>
            InnerException?.Message;

        public event PropertyChangedEventHandler PropertyChanged;

        private async Task WatchTaskAsync(Task task)
        {
            try
            {
                await task;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }

            var propertyChanged = PropertyChanged;
            if (propertyChanged == null)
                return;

            foreach (var props in _taskProperties.Where(props => props.IsAllowedChange(task)));
        }
    }
}