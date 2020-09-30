using System.Web.Mvc;

namespace NFix.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult VideoView()
        {
            return View();
        }

        public ActionResult CategoryView()
        {
            return View();
        }

        public ActionResult BlogsPage()
        {
            return View();
        }

        public ActionResult TutorView()
        {
            return View();
        }

        public ActionResult VideosPage()
        {
            return View();
        }

    }
}