using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbApplikation.Models;
using Labb2;

namespace WebbApplikation.Controllers
{
    public class BusinessController : Controller
    {
        // GET: Business
        public ActionResult Index()
        {
            BusinessViewModel model = new BusinessViewModel();
            List<Vara> VaraList = new List<Vara>();

            // We changed name on project and the service reference requires the old name namespace. 
            Labb2.LagerServiceReference.Service1Client client = new Labb2.LagerServiceReference.Service1Client();
            var temp = client.GetListVara(); // It was supposed to look like: "model.VaraList = client.GetListVara();", but it did not work. 

            // The original plan was to use the line above "var temp", but the model is unable to directly converted. Our solution was a loop. 
            foreach (var item in temp)
            {
                Vara TempVara = new Vara(); // Create new object each loop
                TempVara.ID = item.ID;
                TempVara.Namn = item.Namn;
                TempVara.ButikAntal = item.ButikAntal;
                TempVara.LagerAntal = item.LagerAntal;
                TempVara.Pris = item.Pris;

                VaraList.Add(TempVara); // insert TempVara to create new list item
            }

            model.VaraList = VaraList; // Insert list from the loop into the model list

            return View(model);
        }

        // Order works only from the index page. Requires a submit from a form
        [HttpPost]
        public ActionResult Order(int Id)
        {
            Vara VaraObject = new Vara();
            Labb2.LagerServiceReference.Service1Client client = new Labb2.LagerServiceReference.Service1Client();

            // Same solution and method from Index. 
            var list = client.GetListVara();

            // Loop and get one specific ID. We forgot doing a method retreiving a specific ID from services. 

            foreach (var item in list)
            {
                if(item.ID == Id)
                {
                    VaraObject.ID = item.ID;
                    VaraObject.Namn = item.Namn;
                    VaraObject.ButikAntal = item.ButikAntal;
                    VaraObject.LagerAntal = item.LagerAntal;
                    VaraObject.Pris = item.Pris;
                }
            }
            return View(VaraObject);
        }

        // This ActionResult handles input from the form and makes the order to the services. 
        [HttpPost]
        public ActionResult OrderMade(FormCollection collection)
        {
            // Retrieve and convert from collection
            int antal = Convert.ToInt32(collection["antal"]);
            int id = Convert.ToInt32(collection["ID"]);

            Labb2.LagerServiceReference.Service1Client client = new Labb2.LagerServiceReference.Service1Client();
            client.OrderVaraFromStorage(id, antal);

            return RedirectToAction("Index");
        }
    }
}