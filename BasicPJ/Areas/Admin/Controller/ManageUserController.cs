using BasicPJ.Controllers;
using BasicPJ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicPJ.Areas.Admin.Controller
{
    [Authorize(Roles = "Admin")]
    public class ManageUserController : BaseController<ApplicationUser>
    {
        // GET: Admin/ManageUser
        public ActionResult Index()
        {
            var users = GetAll().ToList();
            return View(users);
        }
    }
}