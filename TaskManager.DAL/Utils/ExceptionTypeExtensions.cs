using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DAL.Exceptions;

namespace TaskManager.DAL.Utils
{
    public static class ExceptionTypeExtensions
    {
        public static string ToErrorMessage(this ExceptionType value)
        {
            switch (value)
            {
                case ExceptionType.Database:
                    return "Database error";
                case ExceptionType.ApiCall:
                    return "API Error";
                case ExceptionType.Other:
                    return "Unknow error";
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }
    }
}
