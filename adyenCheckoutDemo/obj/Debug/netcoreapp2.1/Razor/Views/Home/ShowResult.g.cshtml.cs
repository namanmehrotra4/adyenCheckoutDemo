#pragma checksum "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f0a0c5e55c45ef5b55c553d7825ce117e7e9e7a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowResult), @"mvc.1.0.view", @"/Views/Home/ShowResult.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ShowResult.cshtml", typeof(AspNetCore.Views_Home_ShowResult))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\_ViewImports.cshtml"
using adyenCheckoutDemo;

#line default
#line hidden
#line 2 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\_ViewImports.cshtml"
using adyenCheckoutDemo.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f0a0c5e55c45ef5b55c553d7825ce117e7e9e7a", @"/Views/Home/ShowResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a23646d86481891e4e37f544ae094769128d6b45", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShowResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
  
    ViewData["Title"] = "ShowResult";

#line default
#line hidden
            BeginContext(46, 182, true);
            WriteLiteral("\r\n\r\n<div class=\"contact-form spad\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-12\">\r\n                <div class=\"contact__form__title\">\r\n");
            EndContext();
#line 11 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                      
                        if (ViewBag.resultCode != null)
                        {
                            if (ViewBag.resultCode == "Authorised")
                            {

#line default
#line hidden
            BeginContext(436, 204, true);
            WriteLiteral("                                <h3> Thank you for shopping. Your payment was successful. <br /> </h3>\r\n                                <h5> Please use the following reference number to track your order: ");
            EndContext();
            BeginContext(641, 25, false);
#line 17 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                                                                                               Write(ViewBag.merchantreference);

#line default
#line hidden
            EndContext();
            BeginContext(666, 7, true);
            WriteLiteral("</h5>\r\n");
            EndContext();
#line 18 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                            }
                            else if (ViewBag.resultCode == "Refused")
                            {
                                if (ViewBag.refusalReason != null)
                                {

#line default
#line hidden
            BeginContext(909, 92, true);
            WriteLiteral("                                    <h3> Your payment was refused for the following reason: ");
            EndContext();
            BeginContext(1002, 21, false);
#line 23 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                                                                                       Write(ViewBag.refusalreason);

#line default
#line hidden
            EndContext();
            BeginContext(1023, 221, true);
            WriteLiteral(" <br /> </h3>\r\n                                    <h5>\r\n                                        Please use the following reference number to troubleshoot:\r\n                                        <span style=\"color:red\">");
            EndContext();
            BeginContext(1245, 25, false);
#line 26 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                                                           Write(ViewBag.merchantreference);

#line default
#line hidden
            EndContext();
            BeginContext(1270, 53, true);
            WriteLiteral(" </span>\r\n                                    </h5>\r\n");
            EndContext();
#line 28 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                                }
                                else
                                {

#line default
#line hidden
            BeginContext(1431, 287, true);
            WriteLiteral(@"                                    <h3>Your payment was refused. <br /> </h3>
                                    <h5>
                                        Please use the following reference number to troubleshoot:
                                        <span style=""color:red""> ");
            EndContext();
            BeginContext(1719, 25, false);
#line 34 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                                                            Write(ViewBag.merchantreference);

#line default
#line hidden
            EndContext();
            BeginContext(1744, 53, true);
            WriteLiteral(" </span>\r\n                                    </h5>\r\n");
            EndContext();
#line 36 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                                }
                            }
                            else if (ViewBag.resultCode == "Pending")
                            {

#line default
#line hidden
            BeginContext(1965, 269, true);
            WriteLiteral(@"                                <h3>Your payment is pending.<br /> </h3>
                                <h5>
                                    Please use the following reference number to troubleshoot:
                                    <span style=""color:red""> ");
            EndContext();
            BeginContext(2235, 25, false);
#line 43 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                                                        Write(ViewBag.merchantreference);

#line default
#line hidden
            EndContext();
            BeginContext(2260, 49, true);
            WriteLiteral(" </span>\r\n                                </h5>\r\n");
            EndContext();
#line 45 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                            }
                            else if (ViewBag.resultCode == "Error")
                            {

#line default
#line hidden
            BeginContext(2440, 81, true);
            WriteLiteral("                                <h3> An error occured while making your payment: ");
            EndContext();
            BeginContext(2522, 21, false);
#line 48 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                                                                            Write(ViewBag.refusalreason);

#line default
#line hidden
            EndContext();
            BeginContext(2543, 209, true);
            WriteLiteral(" <br /> </h3>\r\n                                <h5>\r\n                                    Please use the following reference number to troubleshoot:\r\n                                    <span style=\"color:red\">");
            EndContext();
            BeginContext(2753, 25, false);
#line 51 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                                                       Write(ViewBag.merchantreference);

#line default
#line hidden
            EndContext();
            BeginContext(2778, 48, true);
            WriteLiteral("</span>\r\n                                </h5>\r\n");
            EndContext();
#line 53 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                            }
                            else if (ViewBag.resultCode == "Received")
                            {

#line default
#line hidden
            BeginContext(2960, 258, true);
            WriteLiteral(@"                                <h3>Your payment has been received.<br /> </h3>
                                <h5>
                                    Please use the following reference number to troubleshoot:
                                    <span> ");
            EndContext();
            BeginContext(3219, 25, false);
#line 59 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                                      Write(ViewBag.merchantreference);

#line default
#line hidden
            EndContext();
            BeginContext(3244, 49, true);
            WriteLiteral(" </span>\r\n                                </h5>\r\n");
            EndContext();
#line 61 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                            }
                            else if (ViewBag.resultCode == "Cancelled")
                            {

#line default
#line hidden
            BeginContext(3428, 259, true);
            WriteLiteral(@"                                <h3>Your payment has been cancelled.<br /> </h3>
                                <h5>
                                    Please use the following reference number to troubleshoot:
                                    <span> ");
            EndContext();
            BeginContext(3688, 25, false);
#line 67 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                                      Write(ViewBag.merchantreference);

#line default
#line hidden
            EndContext();
            BeginContext(3713, 49, true);
            WriteLiteral(" </span>\r\n                                </h5>\r\n");
            EndContext();
#line 69 "C:\Users\naman\source\repos\adyenCheckoutDemo\adyenCheckoutDemo\Views\Home\ShowResult.cshtml"
                            }
                        }
                    

#line default
#line hidden
            BeginContext(3843, 1541, true);
            WriteLiteral(@"                </div>
            </div>
        </div>
    </div>
</div>

<section class=""contact spad"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-3 col-md-3 col-sm-6 text-center"">
                    <div class=""contact__widget"">
                        <span class=""icon_phone""></span>
                        <h4>Phone</h4>
                        <p>+01-3-8888-6868</p>
                    </div>
                </div>
                <div class=""col-lg-3 col-md-3 col-sm-6 text-center"">
                    <div class=""contact__widget"">
                        <span class=""icon_pin_alt""></span>
                        <h4>Address</h4>
                        <p>60-49 Road 11378 New York</p>
                    </div>
                </div>
                <div class=""col-lg-3 col-md-3 col-sm-6 text-center"">
                    <div class=""contact__widget"">
                        <span class=""icon_clock_alt""></span>
           ");
            WriteLiteral(@"             <h4>Open time</h4>
                        <p>10:00 am to 23:00 pm</p>
                    </div>
                </div>
                <div class=""col-lg-3 col-md-3 col-sm-6 text-center"">
                    <div class=""contact__widget"">
                        <span class=""icon_mail_alt""></span>
                        <h4>Email</h4>
                        <p>hello@colorlib.com</p>
                    </div>
                </div>
            </div>
        </div>
    </section>

");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591