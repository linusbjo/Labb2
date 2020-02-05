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

            Labb2.LagerServiceReference.Service1Client client = new Labb2.LagerServiceReference.Service1Client();
            var temp = client.GetListVara();

            // Hej
            foreach (var item in temp)
            {
                Vara TempVara = new Vara();
                TempVara.ID = item.ID;
                TempVara.Namn = item.Namn;
                TempVara.ButikAntal = item.ButikAntal;
                TempVara.LagerAntal = item.LagerAntal;
                TempVara.Pris = item.Pris;

                VaraList.Add(TempVara);
            }

            model.VaraList = VaraList;

            return View(model);
        }
    }
}