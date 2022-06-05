
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Pastanedp.Models;
using static Pastanedp.Models.DPmodel;

namespace Pastanedp.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        public ActionResult Index()
        {
            return View(DPModel.ReturnList<urun>("UrunListele"));
        }
    }
}