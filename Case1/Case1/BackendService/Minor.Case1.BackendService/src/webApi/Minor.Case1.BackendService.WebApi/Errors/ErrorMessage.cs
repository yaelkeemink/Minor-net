using Minor.Case1.BackendService.WebApi.Errors;

namespace Minor.Case1.BackendService.WebApi.Errors
{
    internal class ErrorMessage
    {
        public ErrorTypes ErrorType { get; set; }
        public string Message { get; set; }
        public string Remedy { get; set; }

        public ErrorMessage(ErrorTypes errorType, string errorMessage, string remedy = null)
        {
            ErrorType = errorType;
            Message = errorMessage;
            Remedy = remedy;
        }
    }
}