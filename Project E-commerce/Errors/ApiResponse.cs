
namespace Project_E_commerce.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message =null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

      

        public int StatusCode { get; set; }

        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request you have made!!",
                401 => "You Are UnAuthorize",
                500 => "Sorry Server Error XD",
                404 => "OOPS Wrong Search :C",
                _ => null

            };
        }



    }
}
