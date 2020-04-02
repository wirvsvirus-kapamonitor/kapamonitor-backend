using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KapaMonitor.Domain.Internal
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Object { get; set; }
        public string StackTrace { get; set; }
    }
}
