using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructureGitHub.Controllers
{
    public class ExitController : Controller
    {
        // GET: Exit
        public ActionResult Index()
        {

            //reroutes to byu.edu
            return Redirect("https://byu.edu");
        }
    }
}