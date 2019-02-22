using Microsoft.AspNet.Identity;
using Pet.Database;
using Pet.Services.Pet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pet.Web.Controllers
{
    [Authorize]
    public class PetController : Controller
    {
        private static UnitOfWorkFactory unitOfWorkFactory;
        private static IPetService petService;

        public PetController()
        {
            unitOfWorkFactory = new UnitOfWorkFactory(new Config());
            petService = new PetService(unitOfWorkFactory);
            
            //CurrentUserId = new Guid(User.Identity.GetUserId());
        }

        // GET: Pet
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            return View(petService.GetPetsForOwner(new Guid(User.Identity.GetUserId())));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Database.Entities.Pet());
        }

        [HttpPost]
        public ActionResult Create(Database.Entities.Pet pet)
        {
            pet.ID = Guid.NewGuid();
            
            pet.OwnerID = new Guid(User.Identity.GetUserId());

            petService.AddOrUpdate(pet);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            Database.Entities.Pet pet = petService.GetPet(id);
            return View(pet);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            Database.Entities.Pet pet = petService.GetPet(id);
            return View(pet);
        }

        [HttpPost]
        public ActionResult Edit(Database.Entities.Pet pet)
        {
            petService.AddOrUpdate(pet);
            return RedirectToAction("Details", pet);
        }

        public ActionResult Delete(Guid id)
        {
            petService.Delete(id);
            return RedirectToAction("List");
        }
    }
}