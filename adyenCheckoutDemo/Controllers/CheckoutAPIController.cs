using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using adyenCheckoutDemo.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Web;

namespace adyenCheckoutDemo.Controllers
{
    public class CheckoutAPIController : ControllerBase
    {
        //Function to call Paymentmethods API
        [HttpPost]
        public async Task<dynamic> GetPaymentMethods([FromBody] PaymentMethods pmObject)
        {
            try
            {
                // Payment method request object with amount value in minor units
                PaymentMethods paymentMethodsReqObj = JsonConvert.DeserializeObject<PaymentMethods>(JsonConvert.SerializeObject(pmObject));
                HttpClient client  = new HttpClient();
                string APIURL      = "https://checkout-test.adyen.com/v64/paymentMethods";
                string xapiKey     = "AQEyhmfxLI3MaBFLw0m/n3Q5qf3VaY9UCJ14XWZE03G/k2NFitRvbe4N1XqH1eHaH2AksaEQwV1bDb7kfNy1WIxIIkxgBw==-y3qzswmlmALhxaVPNjYf74bqPotG12HroatrKA066yE=-W+t7NF;s4}%=kUSD";
                client.BaseAddress = new Uri(APIURL);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-api-key", xapiKey);

                var requestObjValue = JsonConvert.SerializeObject(paymentMethodsReqObj);
                //Calling paymentmethods API 
                HttpResponseMessage response       = await client.PostAsJsonAsync(APIURL, paymentMethodsReqObj);
                var paymentMethodResult            = response.Content.ReadAsStringAsync().Result;
                dynamic paymentMethodResultJsonObj = JsonConvert.DeserializeObject<dynamic>(paymentMethodResult);

                return paymentMethodResultJsonObj;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        //Function to call Payments API
        [HttpPost]
        public async Task<dynamic> MakePayment([FromBody] Dictionary<string, object> data)
        {
            try
            {
                var pmObject =  (Newtonsoft.Json.Linq.JObject) data["data"];
                var amount   = (Newtonsoft.Json.Linq.JObject) data["amount"];

            var amountObj = new Amount
            {
                //value in minor unit 
                currency = amount.GetValue("_currency").ToString(),
                value    = (long)amount.GetValue("_amount"),
            };
            var paymentMethodToken = (Newtonsoft.Json.Linq.JObject)pmObject.GetValue("paymentMethod");
            var pmType             = paymentMethodToken.GetValue("type").ToString();

            Payment paymentReqObj           = new Payment();
            LocalPayment localPaymentReqObj = new LocalPayment();

                //For Card Payment case
                if (pmType == "scheme")
            {
                var pmCardNumber   = paymentMethodToken.GetValue("encryptedCardNumber").ToString();
                var pmMonth        = paymentMethodToken.GetValue("encryptedExpiryMonth").ToString();
                var pmYear         = paymentMethodToken.GetValue("encryptedExpiryYear").ToString();
                var pmHolderName   = paymentMethodToken.GetValue("holderName").ToString();
                var pmCVC          = paymentMethodToken.GetValue("encryptedSecurityCode").ToString();
                var orderReference = "naman_checkoutChallenge";

                //additional details for 3DS2
                var additionalData               = new Dictionary<string, string> { { "allow3DS2", "true" } };
                BrowserInfo browserInfoObj       = JsonConvert.DeserializeObject<BrowserInfo>(JsonConvert.SerializeObject(pmObject["browserInfo"]));
                BillingAddress billingAddressObj = JsonConvert.DeserializeObject<BillingAddress>(JsonConvert.SerializeObject(pmObject["billingAddress"]));
                var channel                      = "Web";
                var origin                       = "https://adyencheckoutdemo.azurewebsites.net";
                var returnUrl                    = "https://adyencheckoutdemo.azurewebsites.net/Home/ShowResult?orderReference=" + orderReference;

                var paymentCardDetailsObj = new PaymentCardDetaiils
                {
                    type = pmType,
                    encryptedCardNumber   = pmCardNumber,
                    encryptedExpiryMonth  = pmMonth,
                    encryptedExpiryYear   = pmYear,
                    holderName            = pmHolderName,
                    encryptedSecurityCode = pmCVC
                };

                //Request object for payments API call
                paymentReqObj = new Payment
                {
                    merchantAccount = "AdyenRecruitmentCOM",
                    reference       = orderReference.ToString(),
                    returnUrl       = returnUrl,
                    amount          = amountObj,
                    paymentMethod   = paymentCardDetailsObj,
                    browserInfo     = browserInfoObj,
                    billingAddress  = billingAddressObj,
                    channel         = channel,
                    origin          = origin,
                    additionalData  = additionalData
                };
            }

            //For Local Payments case
            else
            {
                var orderReference = "naman_checkoutChallenge";
                var returnUrl      = "https://adyencheckoutdemo.azurewebsites.net/Home/ShowResult?orderReference=" + orderReference;  
                
                var paymentCardDetailsObj = new LocalPaymentCardDetails
                {
                    type = pmType
                };

               //Request object for payments API call
                localPaymentReqObj = new LocalPayment
                {
                    merchantAccount = "AdyenRecruitmentCOM",
                    reference       = orderReference,
                    returnUrl       = returnUrl,
                    amount          = amountObj,
                    paymentMethod   = paymentCardDetailsObj
                };
            }

            HttpClient client  = new HttpClient();
            string APIURL      = "https://checkout-test.adyen.com/v64/payments";
            string xapiKey     = "AQEyhmfxLI3MaBFLw0m/n3Q5qf3VaY9UCJ14XWZE03G/k2NFitRvbe4N1XqH1eHaH2AksaEQwV1bDb7kfNy1WIxIIkxgBw==-y3qzswmlmALhxaVPNjYf74bqPotG12HroatrKA066yE=-W+t7NF;s4}%=kUSD";
            client.BaseAddress = new Uri(APIURL);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-api-key", xapiKey);

                if (pmType == "scheme")
                {

                    var requestObjValue = JsonConvert.SerializeObject(paymentReqObj);
                    //Calling payments API
                    HttpResponseMessage response = await client.PostAsJsonAsync(APIURL, paymentReqObj);
                    var detailJson               = await response.Content.ReadAsStringAsync();
                    dynamic paymentResultJsonObj = JsonConvert.DeserializeObject<dynamic>(detailJson);

                    return paymentResultJsonObj;
                }
                else
                {
                    var requestObjValue = JsonConvert.SerializeObject(localPaymentReqObj);
                    //Calling payments API
                    HttpResponseMessage response = await client.PostAsJsonAsync(APIURL, localPaymentReqObj);
                    var detailJson               = await response.Content.ReadAsStringAsync();
                    dynamic paymentResultJsonObj = JsonConvert.DeserializeObject<dynamic>(detailJson);

                    return paymentResultJsonObj;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        [HttpPost]
        public async Task<dynamic> GetAdditionalDetails([FromBody] Dictionary<string, object> pmObject)
        {
            try
            {
                string pmdataObj = pmObject["paymentData"].ToString();
                var pmdetailsObj = (Newtonsoft.Json.Linq.JObject)pmObject["details"];
                var pm           = JsonConvert.SerializeObject(pmdetailsObj);
                var pmDetails    = JsonConvert.DeserializeObject<Dictionary<string, string>>(pm);

                AdditionalDetails addtionalDetailsReqObj = new AdditionalDetails
                {
                    details     = pmDetails,
                    paymentData = pmdataObj
                };

                HttpClient client  = new HttpClient();
                string APIURL      = "https://checkout-test.adyen.com/v64/payments/details";
                string xapikey     = "AQEyhmfxLI3MaBFLw0m/n3Q5qf3VaY9UCJ14XWZE03G/k2NFitRvbe4N1XqH1eHaH2AksaEQwV1bDb7kfNy1WIxIIkxgBw==-y3qzswmlmALhxaVPNjYf74bqPotG12HroatrKA066yE=-W+t7NF;s4}%=kUSD";
                client.BaseAddress = new Uri(APIURL);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-api-key", xapikey);

                var requestObjValue = JsonConvert.SerializeObject(addtionalDetailsReqObj);
                //Calling payments/details api
                HttpResponseMessage response          = await client.PostAsJsonAsync(APIURL, addtionalDetailsReqObj);
                var detailJson                        = await response.Content.ReadAsStringAsync();
                dynamic addtionalDetailsResultJsonObj = JsonConvert.DeserializeObject<dynamic>(detailJson);

                return addtionalDetailsResultJsonObj;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }



    }
}
