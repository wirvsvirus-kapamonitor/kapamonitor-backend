using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapaMonitor.Domain.Internal
{
    public class Error
    {
        public int Code;
        public string Message;
    }
    public static class ErrorMessages
    {
        public const string DatabaseOperationFailed = "Database operation failed.";

        public static readonly Error CreateContactInfo = new Error { Code = 1, Message = "Failed to add new ContactInfo to database." };
        public static readonly Error UpdateContactInfo = new Error { Code = 2, Message = "Failed to update existing ContactInfo in database." };
        public static readonly Error DeleteContactInfo = new Error { Code = 3, Message = "Failed to remove ContactInfo from database." };

        public static readonly Error CreateLocation = new Error { Code = 4, Message = "Failed to add new Location to database." };
        public static readonly Error UpdateLocation = new Error { Code = 5, Message = "Failed to update existing Location in database." };
        public static readonly Error DeleteLocation = new Error { Code = 6, Message = "Failed to remove Location from database." };

        public static readonly Error CreateHospital = new Error { Code = 7, Message = "Failed to add new Hospital to database." };
        public static readonly Error UpdateHospital = new Error { Code = 8, Message = "Failed to update existing Hospital in database." };
        public static readonly Error DeleteHospital = new Error { Code = 9, Message = "Failed to remove Hospital from database." };
    }
}
