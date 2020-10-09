using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adyenCheckoutDemo.Models
{
   
    public class PaymentMethods
    {
        public string merchantAccount { get; set; }
        public string countryCode { get; set; }
        public string shopperLocale { get; set; }
        public Amount amount;
    }
    public class Amount
    {
        public string currency { get; set; }
        public double value { get; set; }
    }

    public class Payment
    {
        public Amount amount;
        public string reference;
        public string returnUrl;
        public string merchantAccount;
        public PaymentCardDetaiils paymentMethod;
        public BrowserInfo browserInfo;
        public BillingAddress billingAddress;
        public Dictionary<string, string> additionalData;
        public string channel;
        public string origin;
    }

    public class PaymentCardDetaiils
    {
        public string type;
        public string encryptedCardNumber;
        public string encryptedExpiryMonth;
        public string encryptedExpiryYear;
        public string holderName;
        public string encryptedSecurityCode;
    }
    public class BrowserInfo
    {
        public string userAgent = @"Mozilla\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\/537.36 (KHTML, like Gecko) Chrome\/70.0.3538.110 Safari\/537.36";
        public string acceptHeader = @"text\/html,application\/xhtml+xml,application\/xml;q=0.9,image\/webp,image\/apng,*\/*;q=0.8";
        public string language = "nl-NL";
        public int colorDepth = 24;
        public int screenHeight = 723;
        public int screenWidth = 1536;
        public int timeZoneOffset = 0;
        public bool javaEnabled = true;
    }
    public class BillingAddress
    {
        public string city = "Amsterdam";
        public string country = "NL";
        public string houseNumberOrName = "1";
        public string postalCode = "1011DJ";
        public string street = "Infinite Loop";
    }
    public class AdditionalDetails
    {
        public string paymentData;
        public Dictionary<string, string> details;
    }
}
