using Microsoft.AspNetCore.Mvc;

namespace PeopleViewer.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Service()
        {
            ViewData["Title"] = "Using a Web Service";
            return GetPeople("Service");
        }

        public IActionResult CSV()
        {
            ViewData["Title"] = "Using a CSV Text File";
            return GetPeople("CSV");
        }

        public IActionResult SQL()
        {
            ViewData["Title"] = "Using a SQL Database";
            return GetPeople("SQL");
        }


        private IActionResult GetPeople(string readerType)
        {
            var reader = ReaderFactory.GetReader(readerType);
            var people = reader.GetPeople();
            return View("Index", people);
        }
    }
}