using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using adyenCheckoutDemo.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http;

namespace adyenCheckoutDemo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

       //Function to capture payment status and generate pspreference once redirected back from 3rd party site
        [HttpGet]
        public ActionResult ShowResult(string orderReference, string payload, string resultCode, string dispaceResult, string refusalreason, string merchantReference)
        {
        
            if (dispaceResult == null)
            {
                var details = new Dictionary<string, string>();
                if (payload != null)
                {
                    details["payload"] = payload;
                }
                if (resultCode != null)
                {
                    details["redirectResult"] = resultCode;
                }
              

                AdditionalDetails additionalDetailsReqObj = new AdditionalDetails
                {
                    details     = details,
                    paymentData = orderReference
                };

                HttpClient client = new HttpClient();
                string APIURL      = "https://checkout-test.adyen.com/v64/payments/details";
                string xapiKey     = "AQEyhmfxLI3MaBFLw0m/n3Q5qf3VaY9UCJ14XWZE03G/k2NFitRvbe4N1XqH1eHaH2AksaEQwV1bDb7kfNy1WIxIIkxgBw==-y3qzswmlmALhxaVPNjYf74bqPotG12HroatrKA066yE=-W+t7NF;s4}%=kUSD";
                client.BaseAddress = new Uri(APIURL);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-api-key", xapiKey);

                var requestObjValue                   = JsonConvert.SerializeObject(additionalDetailsReqObj);
                var postResponse                      = client.PostAsJsonAsync(APIURL, additionalDetailsReqObj).Result.Content;
                var detailJson                        = postResponse.ReadAsStringAsync().Result;
                dynamic addtionalDetailsResultJsonObj = JsonConvert.DeserializeObject<dynamic>(detailJson);


                if (addtionalDetailsResultJsonObj.merchantReference != null)
                {
                    ViewBag.merchantreference = addtionalDetailsResultJsonObj.merchantReference.ToString();
                }
                if (addtionalDetailsResultJsonObj.resultCode != null)
                {
                    ViewBag.resultCode = addtionalDetailsResultJsonObj.resultCode.ToString();
                }
                if (addtionalDetailsResultJsonObj.refusalReason !=null)
                {
                    ViewBag.refusalReason = addtionalDetailsResultJsonObj.refusalReason.ToString();
                }

            }
            else
            {
                if (merchantReference != null)
                {
                    ViewBag.merchantreference = merchantReference;
                }
                if(refusalreason != null)
                {
                    ViewBag.refusalReason = refusalreason;
                }
                if (dispaceResult != null)
                {
                    ViewBag.resultCode = dispaceResult;
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult ShowResult(Dictionary<string, string> pairs, string orderReference, string payload)
        {
          
            ViewBag.searchValue = pairs;
            return View();
        }


        public ActionResult PaymentMethods(string amount, string country, string currency, string locale)
        {
            //Passing payment details to view for the Paymentmethods API call

            var payload  = new {
                _currency = currency,
                _amount = amount,
                _country = country,
                _locale = locale
            };

            ViewBag.payload = JsonConvert.SerializeObject(payload);

            return View();
        }

        public ActionResult ViewCart()
        {
            ViewBag.Message = "Checkout Item Cart";

            return View();
        }

    }
}