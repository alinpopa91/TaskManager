using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DAL.Exceptions
{
    public class CustomException : Exception
    {
        public ExceptionType ExceptionType { get; set; }
        public CustomException(ExceptionType type, string message): base(message) 
        {
            ExceptionType = type;
        }
    }

    public enum ExceptionType
    {
        Database = 1,
        ApiCall = 2,
        Other = 3
    }
}
