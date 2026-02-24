using System.Collections.Generic;

namespace SuiteRx.Interface.Application.Common.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, string message = "Request completed successfully.")
        {
            return new ApiResponse<T> { Success = true, Data = data, Message = message };
        }

        public static ApiResponse<T> ErrorResponse(string message, IEnumerable<ValidationError> errors = null)
        {
            return new ApiResponse<T> { Success = false, Message = message, Errors = errors };
        }
    }
}
