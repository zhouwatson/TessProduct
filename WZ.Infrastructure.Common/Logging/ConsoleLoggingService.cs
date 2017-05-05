using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZ.Infrastructure.Common.Logging
{
    public class ConsoleLoggingService : Services.Interfaces.ILoggingService
    {
        public void LogDebug(string message)
        {
            Console.WriteLine(string.Format("DEBUG - {0}", message));
        }

        public void LogDebug(Exception ex)
        {
            Console.WriteLine(string.Format("DEBUG - {0}", ex.StackTrace));
        }

        public void LogError(string message)
        {
            Console.WriteLine(string.Format("ERROR - {0}", message));
        }

        public void LogError(Exception ex)
        {
            Console.WriteLine(string.Format("ERROR - {0}", ex.StackTrace));
        }

        public void LogInfo(string message)
        {
            Console.WriteLine(string.Format("INFO - {0}", message));
        }

        public void LogInfo(Exception ex)
        {
            Console.WriteLine(string.Format("INFO - {0}", ex.Message));
        }
    }
}
