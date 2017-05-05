using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZ.Services.Interfaces
{
    public interface ILoggingService
    {
        void LogDebug(Exception ex);

        void LogError(Exception ex);

        void LogInfo(Exception ex);


        void LogDebug(string message);

        void LogError(string message);

        void LogInfo(string message);
    }
}
