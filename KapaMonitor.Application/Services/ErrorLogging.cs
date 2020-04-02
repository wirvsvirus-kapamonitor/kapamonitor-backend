using KapaMonitor.Database;
using KapaMonitor.Domain.Enums;
using KapaMonitor.Domain.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KapaMonitor.Application.Services
{
    public class ErrorLogging
    {
        private readonly ApplicationDbContext _context;

        public ErrorLogging(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Logs an exception to the database
        /// </summary>
        /// <param name="error">The static code error</param>
        /// <param name="ex">The occurred exception</param>
        /// <param name="errorObject">The object, that potentially caused the exception</param>
        /// <returns>Returns true if logging was successful, false if the error couldn't be saved to the database</returns>
        public async Task<bool> LogError(Error error, Exception ex, object? errorObject = null)
        {
            //_logger.LogError(ex, message, errorObject);

            _context.ErrorLogs.Add(new ErrorLog
            {
                DateTime = DateTime.Now,
                ErrorCode = error.Code,
                ErrorMessage = error.Message,
                Object = JsonSerializer.Serialize(errorObject),
                StackTrace = ex.StackTrace,
            });

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
