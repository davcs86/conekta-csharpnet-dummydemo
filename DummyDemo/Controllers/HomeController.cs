using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConektaCSharp;
using Newtonsoft.Json.Linq;

namespace ConektaClientDummyDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Conekta.ApiKey = "1tv5yJp3xnVZ7eK67m4h";

            JObject valid_payment_method = JObject.Parse("{'description':'Stogies'," +
                                                         "'reference_id':'9839-wolf_pack'," +
                                                         "'amount':20000," +
                                                         "'currency':'MXN'," +
                                                         "'card':'tok_test_visa_4242'}");
            try
            {
                Charge charge = Charge.create(valid_payment_method);
                ViewBag.Result = charge.ToString();
            }
            catch (Error e)
            {
                ViewBag.Result = e.ToString();
            }
            return View();
        }

    }
}