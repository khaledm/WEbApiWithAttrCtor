using System.Web.Http;
using WEbApiWithAttrCtor.Models;

namespace WEbApiWithAttrCtor.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IRepository<Course> _courseRepository;

        public HomeController(IRepository<Course>  courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_courseRepository.GetAll());
        }
    }
}
