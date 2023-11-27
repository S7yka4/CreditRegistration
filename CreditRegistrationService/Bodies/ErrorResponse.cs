namespace CreditRegistrationService.Bodies
{
    public class Error
    {
        public string code { get; init; }
        public string message { get; init; }
    }
    public class ErrorResponse
    {
        public Error error { get; set; }
        public ErrorResponse() { }
        public ErrorResponse(string errorCode)
        {
            error = new Error()
            {
                code = errorCode,
                message = ErrorCodes.CodeMessages[errorCode]
            };
        }
    }
}
