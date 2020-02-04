using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbApplikation.Models;

namespace WebbApplikation.Controllers
{
    public class BusinessController : Controller
    {
        // GET: Business
        public ActionResult Index()
        {
           // ArticleService.Service1Client client = new ArticleService.Service1Client();

            return View();
        }
    }
}