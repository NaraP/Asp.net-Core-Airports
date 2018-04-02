using System;

namespace Utility.ErrorLog
{
    public interface IErrorLoggers
    {
        void ExceptionHandler(Exception ex, string strPolicy, string ModuleName);

        void ExceptionWriteIntoTextFile(Exception ex, string strPolicy, string strQuery, string ModuleName);
    }
}
