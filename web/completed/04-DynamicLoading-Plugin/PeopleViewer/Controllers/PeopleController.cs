using Microsoft.AspNetCore.Mvc;

namespace PeopleViewer.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult RuntimeReader()
        {
            var reader = ReaderFactory.GetReader();
            var people = reader.GetPeople();

            ViewData["Title"] = "Using a Runtime Reader";
            ViewData["ReaderType"] = reader.GetType().ToString();
            return View("Index", people);
        }
    }
}