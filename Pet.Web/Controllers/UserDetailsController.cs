using Microsoft.AspNet.Identity;
using Pet.Database;
using Pet.Database.Entities;
using Pet.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet.Web.Controllers
{
    public class UserDetailsController : Controller
    {

        private static UnitOfWorkFactory unitOfWorkFactory;
        private static IUserDetailsService userDetailsService;


        public UserDetailsController()
        {
            unitOfWorkFactory = new UnitOfWorkFactory(new Config());
            userDetailsService = new UserDetailsService(unitOfWorkFactory);
        }

        // GET: UserDetails
        public ActionResult Index()
        {
            Guid userID = new Guid(User.Identity.GetUserId());
            UserDetails userDetails = userDetailsService.GetUserDetails(userID);
            return View(userDetails);
        }

        // GET: UserDetails/Details/5
        public ActionResult Details()
        {
            Guid userID = new Guid(User.Identity.GetUserId());
            UserDetails userDetails = userDetailsService.GetUserDetails(userID);
            return View(userDetails);
        }

        // GET: UserDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDetails/Create
        [HttpPost]
        public ActionResult Create(UserDetails userDetails)
        {
            try
            {
                //userDetails.ID = new Guid(User.Identity.GetUserId());
                userDetailsService.Update(userDetails);
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserDetails/Edit/5
        public ActionResult Edit()
        {
            Guid userID = new Guid(User.Identity.GetUserId());
            UserDetails userDetails = userDetailsService.GetUserDetails(userID);
            return View(userDetails);
        }

        // POST: UserDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(UserDetails userDetails)
        {
            try
            {
                userDetailsService.Update(userDetails);

                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserDetails/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
