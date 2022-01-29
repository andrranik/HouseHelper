using System;

namespace HouseHelper.ViewModel.Models
{
    public class ExceptionInfo
    {
        #region ctors

        public ExceptionInfo(Exception ex)
        {
        }

        #endregion

        #region props

        public string Message { get; set; }

        public Exception SourceException { get; set; }

        #endregion
    }
}