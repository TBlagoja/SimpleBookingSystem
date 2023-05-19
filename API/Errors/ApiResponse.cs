namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string errorMessage = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage ?? GetDefaultMessageForStatusCode(statusCode);   
        }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You have made a bad request",
                401 => "You are not Authorized",
                404 => "Resource wasnt found",
                500 => "Error proccesing the request",
                _ => null,
            };
        }
    }
}
