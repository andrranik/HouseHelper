using System;
using System.Threading.Tasks;

namespace HouseHelper.Services.Infrastructure
{
    public class TaskProperty
    {
        public TaskProperty(string propertyName, Func<Task, bool> isAllowedChange)
        {
            PropertyName = propertyName;
            IsAllowedChange = isAllowedChange;
        }

        public string PropertyName { get; set; }
        public Func<Task, bool> IsAllowedChange { get; set; }
    }
}