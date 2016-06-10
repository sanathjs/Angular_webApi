using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Angular_WebApi.Models;
using System.Web.Http;

namespace Angular_WebApi.Controllers
{
    [RoutePrefix("Patient")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Route("Home/getPatientlist")]
        public JsonResult getPatientlist()
        {
            patientRepository repo = new patientRepository();
            return Json(repo.GetAllPatients(), JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetPatientByDetails([FromUri]patient patdetails)
        {
            patientRepository repo = new patientRepository();
            return Json(repo.GetPatient(patdetails), JsonRequestBehavior.AllowGet);
            
        }
    }
}
