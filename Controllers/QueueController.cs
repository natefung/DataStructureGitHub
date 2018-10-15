using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructureGitHub.Controllers
{
    public class QueueController : Controller
    {
        //creates queue and search boolean
        static Queue<string> myQueue = new Queue<string>();
        Boolean searchResults;
        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.MyQueue = myQueue;

            return View();
        }

        //adds a new entry into the queue
        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry #" + (myQueue.Count + 1));
            ViewBag.MyQueue = myQueue;

            return View("Index");
        }

        //adds a list of 2000 entries into the queue
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

        //displays the queue
        public ActionResult DisplayQueue()
        {
            ViewBag.MyQueue = myQueue;
            if(myQueue.Count == 0)
            {
                ViewBag.NoQueue = "There is nothing to display";
            }

            return View("Display");
        }

        //deletes the first entry from the queue
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

        //clears the entire queue
        public ActionResult ClearQueue()
        {
            ViewBag.MyQueue = myQueue;
            if (myQueue.Count != 0)
            {
                myQueue.Clear();
            }

            else
            {
                ViewBag.NoQueue = "The Queue is already empty";
            }

            return View("Display");
        }

        //searches for #350 in the queue and returns whether or not it was found and how fast it was found
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