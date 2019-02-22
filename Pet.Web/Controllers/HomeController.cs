using Pet.Database;
using Pet.Services.Pet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet.Web.Controllers
{
    public class HomeController : Controller
    {
        private static UnitOfWorkFactory unitOfWorkFactory;
        private static IPetService petService;

        public HomeController()
        {
            unitOfWorkFactory = new UnitOfWorkFactory(new Config());
            petService = new PetService(unitOfWorkFactory);
        }

        public ActionResult Index()
        {
            bool isAuthenticated = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            //if (isAuthenticated)
            //{
            //    return RedirectToAction("List", "Pet");
            //}
            return View(petService.GetAllPets(null));
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

    }
}