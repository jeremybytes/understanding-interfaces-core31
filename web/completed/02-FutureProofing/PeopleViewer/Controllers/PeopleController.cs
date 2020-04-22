using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using People.Library;

namespace PeopleViewer.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult ConcreteType()
        {
            List<Person> people;

            var reader = new PersonReader();
            people = reader.GetPeople();

            ViewData["Title"] = "Using Concrete Type";
            return View("Index", people);
        }

        public IActionResult AbstractType()
        {
            IEnumerable<Person> people;

            var reader = new PersonReader();
            people = reader.GetPeople();

            ViewData["Title"] = "Using Abstract Type";
            return View("Index", people);
        }
    }
}