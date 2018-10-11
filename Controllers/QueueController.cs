using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructureGitHub.Controllers
{
    public class QueueController : Controller
    {
        static Queue<string> myQueue = new Queue<string>();
        Boolean searchResults;
        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.MyQueue = myQueue;

            return View();
        }

        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry #" + (myQueue.Count + 1));
            ViewBag.MyQueue = myQueue;

            return View("Index");
        }

        public ActionResult AddHuge()
        {
            myQueue.Clear();
            for (int i = 0; i < 2000; i++)
            {
                myQueue.Enqueue("New Entry #" + (myQueue.Count + 1));
                ViewBag.MyQueue = myQueue;
            }

            return View("Index");
        }

        public ActionResult Displaystack()
        {
            ViewBag.MyQueue = myQueue;

            return View("Index");
        }

        public ActionResult DeleteFrom()
        {
            ViewBag.MyQueue = myQueue;
            if (myQueue.Count == 0)
            {
                ViewBag.Delete = "There is nothing to delete.";
            }

            else
            {
                myQueue.Dequeue();
            }

            return View("Index");
        }

        public ActionResult ClearQueue()
        {
            ViewBag.MyQueue = myQueue;
            myQueue.Clear();

            return View("Index");
        }

        public ActionResult SearchQueue()
        {
            ViewBag.MyQueue = myQueue;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            for (int i = 0; i < myQueue.Count; i++)
            {
                if (myQueue.Contains("New Entry #350"))
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
                ViewBag.SearchResults = "Entry #350 does not exist in this queue";
            }

            return View("Index");
        }

    }
}