namespace CreditRegistrationService.Bodies
{
    public class Error
    {
        public string code { get; set; }
        public string message { get; set; }

        public Error() { }
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
