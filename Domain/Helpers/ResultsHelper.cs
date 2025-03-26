using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public static class ResultsHelper
    {
        public static string GetErrorsMessage(this Result result)
        {
            var message = "";
            foreach (var error in result.Errors)
            {
                message += error.Message + " ";
            }
            return message;
        }

        public static string GetErrorsMessage<T>(this Result<T> result)
        {
            var message = "";
            foreach (var error in result.Errors)
            {
                message += error.Message + " ";
            }
            return message;
        }
    }
}
