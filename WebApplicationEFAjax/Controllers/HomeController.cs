using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationEFAjax.Models;

namespace WebApplicationEFAjax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            List<Person> personList;
            using (MyItemsDbcontext db = new MyItemsDbcontext())
            {
                personList = db.People.ToList();
            }

            if(personList==null)
            {
                personList = new List<Person>();
            }
                return View(personList);
        }

        public ActionResult PersonDetails(int id)
        {
            Person person;
            using (MyItemsDbcontext db = new MyItemsDbcontext())
            {
                person = db.People.Include("Belongings").Include("Belongings.LentBy").SingleOrDefault(p => p.Id == id);
            }

            if(person==null)
            {
                return new HttpStatusCodeResult(404);
            }

                return PartialView("_PersonDetails", person);
        }

       
    }
}