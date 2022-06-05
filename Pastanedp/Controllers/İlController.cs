
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
    public class İlController : Controller
    {
        // GET: İl
        public ActionResult Index()
        {
            return View(DPModel.ReturnList<illermodel>("IlListe"));
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@id", id);
                return View(DPModel.ReturnList<illermodel>("IlSirala", param).FirstOrDefault<illermodel>());
            }
        }
        [HttpPost]
        public ActionResult EY(illermodel mus)
        {
            //view oluştururken edit olanı seçiyoruz
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", mus.id);
            param.Add("@Sehir", mus.Sehir);
            
            DPModel.ExecuteWithoutReturn("IlEy", param);
            return RedirectToAction("Index");

        }

    }
}