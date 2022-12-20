using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using System;
using System.Diagnostics;
using TP2.Models;

namespace TP2.Controllers
{
    public class PersonController : Controller
    {
        [Route("Person/all")]
        public IActionResult all()
        {
            Personal_info p_info = new Personal_info();

            return View(p_info.getAllPersons());
        }

        [Route("Person/{id:int}")]
        public IActionResult index(int id)
        {
            Personal_info p_info = new Personal_info();

            return View(p_info.getPerson(id));
        }


        [HttpGet]
        [Route("Person/search")]
        public IActionResult form()
        {  
            return View();
        }


        [HttpPost]
        [Route("Person/search")]
        public IActionResult form(String first_name, String country)
        {
            Personal_info p_info = new Personal_info();
            List<Person>  persons= p_info.getAllPersons();
          
            foreach (Person person in persons)
            {
                if (person.first_name == first_name && person.country == country)
                {
                    return RedirectToAction("index", new {id=person.Id});

                }
            }
           
            return RedirectToAction("index", new { id=-1 });
        }

    }
}
