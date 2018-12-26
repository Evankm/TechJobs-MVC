using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        

        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType == "all")
            {
               List<Dictionary<string, string>> value = new List<Dictionary<string, string>>();

                List<Dictionary<string, string>> jobs = JobData.FindAll();
                foreach( Dictionary<string, string> job in jobs)
                {
                    foreach( KeyValuePair<string, string> item in job)
                    {
                        string iv = item.Value.ToLower();
                        if (iv.Contains(searchTerm.ToLower()) == true)
                       
                         value.Add(job);
                    }
                }
                    
                ViewBag.jobs = value;
            }
            else
            {

                List<Dictionary<string, string>> searchResults;
                searchResults = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = searchResults;
                ViewBag.searchType = searchType;
            }

            return View();
        }

    }
}
