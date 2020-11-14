using System.Web.Mvc;

namespace NFix.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hero()
        {
            return PartialView();
        }
        public ActionResult Stripe()
        {
            return PartialView();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
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