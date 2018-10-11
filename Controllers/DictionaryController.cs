using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructureGitHub.Controllers
{
    public class DictionaryController : Controller
    {
        Boolean searchResults;
        static Dictionary<string, int> myDictionary = new Dictionary<string, int>();
        // GET: Dictionary
        public ActionResult Index()
        {
            ViewBag.MyDictionary = myDictionary;

            return View();
        }

        public ActionResult AddOne()
        {
            myDictionary.Add("New Entry #" + (myDictionary.Count + 1), myDictionary.Count);
            ViewBag.MyDictionary = myDictionary;

            return View("Index");
        }

        public ActionResult AddHuge()
        {
            myDictionary.Clear();

            for (int i = 0; i < 2000; i++)
            {
                myDictionary.Add("New Entry #" + (myDictionary.Count + 1), myDictionary.Count);
                ViewBag.MyDictionary = myDictionary;
            }

            return View("Index");
        }

        public ActionResult DisplayDictionary()
        {
            ViewBag.MyDictionary = myDictionary;
            if (myDictionary.Count == 0)
            {
                ViewBag.NoDictionary = "There is nothing to display";
            }

            return View("Display");
        }

        public ActionResult DeleteFrom()
        {
            ViewBag.MyDictionary = myDictionary;
            if (myDictionary.Count == 0)
            {
                ViewBag.Delete = "There is nothing to delete.";
            }

            else
            {
                myDictionary.Remove("New Entry #" + myDictionary.Count);
            }

            return View("Index");
        }

        public ActionResult ClearDictionary()
        {
            ViewBag.MyDictionary = myDictionary;
            if (myDictionary.Count != 0)
            {
                myDictionary.Clear();
            }

            else
            {
                ViewBag.NoDictionary = "The Dictionary is already empty";
            }

            return View("Display");
        }

        public ActionResult SearchDictionary()
        {
            ViewBag.MyDictionary = myDictionary;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            for (int i = 0; i < myDictionary.Count; i++)
            {
                if (myDictionary.ContainsKey("New Entry #350"))
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
                ViewBag.SearchResults = "Entry #350 does not exist in this dictionary";
            }

            return View("Index");
        }
    }
}