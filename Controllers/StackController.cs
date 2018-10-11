using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructureGitHub.Controllers
{
    public class StackController : Controller
    {
        public static Stack<string> myStack = new Stack<string>();
        Boolean searchResults;
        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.MyStack = myStack;

            return View();
        }

        public ActionResult AddOne()
        {
            myStack.Push("New Entry #" + (myStack.Count + 1));
            ViewBag.MyStack = myStack;

            return View("Index");
        }

        public ActionResult AddHuge()
        {
            myStack.Clear();
            for (int i = 0; i < 2000; i++)
            {
                myStack.Push("New Entry #" + (myStack.Count + 1));
                ViewBag.MyStack = myStack;
            }

            return View("Index");
        }

        public ActionResult Displaystack()
        {
            ViewBag.Mystack = myStack;

            return View("Index");
        }

        public ActionResult DeleteFrom()
        {
            ViewBag.Mystack = myStack;
            if (myStack.Count == 0)
            {
                ViewBag.Delete = "There is nothing to delete.";
            }

            else
            {
                myStack.Pop();
            }

            return View("Index");
        }

        public ActionResult ClearStack()
        {
            ViewBag.MyStack = myStack;
            myStack.Clear();

            return View("Index");
        }

        public ActionResult SearchStack()
        {
            ViewBag.MyStack = myStack;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            for (int i = 0; i < myStack.Count; i++)
            {
                if (myStack.Contains("New Entry #350"))
                {
                    searchResults = true;
                }

                else
                {
                    searchResults = false;
                }
            }
            //loop to do all the work

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            if (searchResults == true)
            {
                ViewBag.SearchResults = "Entry #350 was found in " + ts + " seconds";
            }

            else
            {
                ViewBag.SearchResults = "Entry #350 does not exist in this stack";
            }

            return View("Index");
        }


    }
}