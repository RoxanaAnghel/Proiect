using System.Web.Mvc;

namespace Pet.Web.Controllers
{
    public class TemplatesController : Controller
    {
        public ActionResult Home()
        {
            return PartialView("~/Views/Templates/Home.cshtml");
        }

        public ActionResult MyPets()
        {
            return PartialView("~/Views/Templates/MyPets.cshtml");
        }

        public ActionResult PetSave()
        {
            return PartialView("~/Views/Templates/PetSave.cshtml");
        }

        public ActionResult PetEdit()
        {
            return PartialView("~/Views/Templates/PetEdit.cshtml");
        }

        public ActionResult UserDetails()
        {
            return PartialView("~/Views/Templates/UserDetails.cshtml");
        }

        public ActionResult UserConversations()
        {
            return PartialView("~/Views/Templates/UserConversations.cshtml");
        }

        public ActionResult Conversation()
        {
            return PartialView("~/Views/Templates/Conversation.cshtml");
        }

        public ActionResult PetViewProfile()
        {
            return PartialView("~/Views/Templates/PetViewProfile.cshtml");
        }

        public ActionResult Uploads()
        {
            return PartialView("~/Views/Templates/Uploads.cshtml");
        }

        public ActionResult EditUserDetails()
        {
            return PartialView("~/Views/Templates/EditUserDetails.cshtml");
        }
    }
}