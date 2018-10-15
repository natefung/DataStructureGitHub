/******
 Author: Group 2-3: Nate Fung, Eric Lee, Anson Huang, Katrina Peterson
 Description: Create webpages that createst and displays a stack, dictionary, queue, and returns to BYU website upon Exit.
 **********/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructureGitHub.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            //return the view
            return View();
        }
    }
}