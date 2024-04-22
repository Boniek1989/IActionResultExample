using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("book")]
        public IActionResult Index() // can return any type of Action result
        {
            //Book id should be supplied
            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.StatusCode = 400;
                return Content("Book id is not supplied");
            }
            
            //Book id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 400;
                return Content("Book id cannot be null or empty");
            }

            //Book id should be between 1 to 1000
            int bookId = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId <= 0 )
            {
                Response.StatusCode = 400;
                return Content("Book id can't be less then or equal to zero");
            }
            if (bookId > 1000)
            {
                Response.StatusCode = 400;
                return Content("Book id cannot be greater than 1000");
            }

            //isloggedin shall be true
            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                Response.StatusCode = 401;
                return Content("User must be authenticated");
            }
            
            Response.StatusCode = 200;
            return File("/sample.pdf","application/pdf");
        }
    }
}
