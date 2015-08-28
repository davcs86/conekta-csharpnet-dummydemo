using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConektaClientDummyDemo.Models;
using ConektaCSharp;
using Newtonsoft.Json.Linq;

namespace ConektaClientDummyDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Conekta.ApiKey = "key_NR49sJT9k4zCNip4RhRShg";

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

        public ActionResult ChargeDemo()
        {
            return View(new ChargeDemo());
        }

        [HttpPost]
        public ActionResult ChargeDemo(ChargeDemo model)
        {
            Conekta.ApiKey = "key_NR49sJT9k4zCNip4RhRShg";
            JObject valid_payment_method = JObject.Parse("{'description':'Stogies'," +
                                                         "'reference_id':'9839-wolf_pack'," +
                                                         "'amount':20000," +
                                                         "'currency':'MXN'," +
                                                         "'card':''}");
            if (ModelState.IsValid)
            {
                // set the card token
                valid_payment_method["card"] = model.card_token;
            }
            
            try
            {
                Charge charge = Charge.create(valid_payment_method);
                ViewBag.Result = charge.ToString();
            }
            catch (Error e)
            {
                ViewBag.Result = e.ToString();
            }
            return View(model);
        }

    }
}