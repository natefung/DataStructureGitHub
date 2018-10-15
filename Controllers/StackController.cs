using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructureGitHub.Controllers
{
    public class StackController : Controller
    {
        //creates a stack and variables
        public static Stack<string> myStack = new Stack<string>();
        Boolean searchResults;
        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.MyStack = myStack;

            return View();
        }

        //adds an entry into the stack
        public ActionResult AddOne()
        {
            myStack.Push("New Entry #" + (myStack.Count + 1));
            ViewBag.MyStack = myStack;

            return View("Index");
        }

        //adds a list of 2000 entries into the stack
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

        //displays the stack
        public ActionResult DisplayStack()
        {
            ViewBag.MyStack = myStack;
            if (myStack.Count == 0)
            {
                ViewBag.NoStack = "There is nothing to display";
            }

            return View("Display");
        }

        //deletes the last entry in the stack
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

        //clears the entire stack
        public ActionResult ClearStack()
        {
            ViewBag.MyStack = myStack;
            if (myStack.Count != 0)
            {
                myStack.Clear();
            }
            
            else
            {
                ViewBag.NoStack = "The Stack is already empty";
            }

            return View("Display");
        }

        //searches for #350 in the stack and returns whether or not it was found and how quickly it was found
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