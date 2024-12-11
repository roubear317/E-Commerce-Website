using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_E_commerce.Errors;

namespace Project_E_commerce.Controllers
{
    [Route("errors/{code}")]
    
    public class ErrorController : BaseController
    {

        public IActionResult GetError(int code)
        {

            return new ObjectResult(new ApiResponse(code));

        }





    }
}
