
//Function to filter payment methods 
function filterUnimplemented(pm) {
    pm.paymentMethods = pm.paymentMethods.filter((it) =>
        [
            "alipay",
            "scheme",
            "alipay_wap",
            "wechatpayWeb",
            
        ].includes(it.type)
    );
    return pm;
}

//Function to setup and load dropin
function SetupDropin(payload) {

    CallServerAPI("/CheckOutAPI/GetPaymentMethods", {
        merchantAccount: "AdyenRecruitmentCOM",
        amount:{
            currency: payload._currency,
            value: payload._amount
        },
        countryCode: payload._country,
        shopperLocale: payload._locale
    })
    .then((paymentMethodsResponse) => {
        const configuration = {
            paymentMethodsResponse: filterUnimplemented(paymentMethodsResponse), // The `/paymentMethods` response from the server.
            clientKey: "test_CIXAPNBW2JERLEJ6GYYC3WBLVMO2HIZ3", // Web Drop-in versions before 3.10.1 use originKey instead of clientKey.
            locale: "en-SG",
            environment: "test",
            onSubmit: (state, dropin) => {
                // Calling MakePayment method in CheckOutAPI controller to make the `/payments` request
                var amount = {
                  _amount: payload._amount,
                  _currency: payload._currency
                }
                CallServerAPI("/CheckOutAPI/MakePayment", {
                    data: state.data,
                    amount: amount
                })
                .then(response => {
                        if (response.action) {
                            // Drop-in handles the action object from the /payments response
                            dropin.handleAction(response.action);
                        } else {
                            // Set dropin status based on resultCode and redirect users to ShowResult page
                            if (response.resultCode == "Error") {
                                dropin.setStatus('error');
                                dropin.setStatus('error', { message: 'Something went wrong.' });
                                var redirectUrl =
                                    "/Home/ShowResult/?refusalreason={1}&dispaceResult={2}&merchantReference={3}";
                                if (response.refusalReason) {
                                    var refusal = response.refusalReason;
                                }
                                if (response.resultCode) {
                                    var result = response.resultCode;
                                }
                                if (response.merchantReference) {
                                    var merchantRef = response.merchantReference;
                                }
                                redirectUrl = redirectUrl.replace("{1}", refusal);
                                redirectUrl = redirectUrl.replace("{2}", result);
                                redirectUrl = redirectUrl.replace("{3}", merchantRef);

                                window.location = redirectUrl;
                            }
                            else if (response.resultCode == "Refused") {

                                dropin.setStatus('refused');
                                dropin.setStatus('error', { message: "Payment Refused" });
                                var redirectUrl =
                                    "/Home/ShowResult/?refusalreason={1}&dispaceResult={2}&merchantReference={3}";
                                if (response.refusalReason) {
                                    var refusal = response.refusalReason;
                                }
                                if (response.resultCode) {
                                    var result = response.resultCode;
                                }
                                if (response.merchantReference) {
                                    var merchantRef = response.merchantReference;
                                }
                                redirectUrl = redirectUrl.replace("{1}", refusal);
                                redirectUrl = redirectUrl.replace("{2}", result);
                                redirectUrl = redirectUrl.replace("{3}", merchantRef);

                                window.location = redirectUrl;
                            }
                            else {
                                dropin.setStatus('success', { message: 'Payment successful!' });
                                console.log("make payment");
                                console.log(response);
                                var redirectUrl =
                                    "/Home/ShowResult/?refusalreason={1}&dispaceResult={2}&merchantReference={3}";
                                if (response.refusalReason) {
                                    var refusal = response.refusalReason;
                                    console.log(refusal);
                                }
                                if (response.resultCode) {
                                    var result = response.resultCode;
                                }
                                if (response.merchantReference) {
                                    var merchantRef = response.merchantReference;
                                    console.log(merchantRef);
                                }
                                redirectUrl = redirectUrl.replace("{1}", refusal);
                                redirectUrl = redirectUrl.replace("{2}", result);
                                redirectUrl = redirectUrl.replace("{3}", merchantRef);

                                window.location = redirectUrl;
                            }
                        }
                    })
                    .catch(error => {
                        throw Error(error);
                    });
                console.log(state);
            },
            onAdditionalDetails: (state, dropin) => {
                // Calling MakePayment method in CheckOutAPI controller to make the `/payments/details` request
                CallServerAPI("/CheckOutAPI/GetAdditionalDetails", state.data)
                    .then(response => {
                        if (response.action) {
                            // Drop-in handles the action object from the /payments response
                            dropin.handleAction(response.action);
                        } else {
                            // Set dropin status based on resultCode and redirect users to ShowResult page
                            if (response.resultCode == "Error") {
                                    
                                dropin.setStatus('error');
                                dropin.setStatus('error', { message: 'Something went wrong.' });
                                var redirectUrl =
                                    "/Home/ShowResult/?refusalreason={1}&dispaceResult={2}&merchantReference={3}";
                                if (response.refusalReason) {
                                    var refusal = response.refusalReason;
                                }
                                if (response.resultCode) {
                                    var result = response.resultCode;
                                }
                                if (response.merchantReference) {
                                    var merchantRef = response.merchantReference;
                                }
                                redirectUrl = redirectUrl.replace("{1}", refusal);
                                redirectUrl = redirectUrl.replace("{2}", result);
                                redirectUrl = redirectUrl.replace("{3}", merchantRef);

                                window.location = redirectUrl;
                            }
                            else if (response.resultCode == "Refused") {

                                dropin.setStatus('refused');
                                dropin.setStatus('error', { message: "Payment Refused" });
                                var redirectUrl = "/Home/ShowResult/?refusalreason={1}&dispaceResult={2}&merchantReference={3}";
                                if (response.refusalReason) {
                                    var refusal = response.refusalReason;
                                }
                                if (response.resultCode) {
                                    var result = response.resultCode;
                                }
                                if (response.merchantReference) {
                                    var merchantRef = response.merchantReference;
                                }
                                redirectUrl = redirectUrl.replace("{1}", refusal);
                                redirectUrl = redirectUrl.replace("{2}", result);
                                redirectUrl = redirectUrl.replace("{3}", merchantRef);

                                window.location = redirectUrl;
                            }
                            else {
                                dropin.setStatus('success', { message: 'Payment successful!' });
                                console.log("additional payment");
                                console.log(response);
                                var redirectUrl = "/Home/ShowResult/?refusalreason={1}&dispaceResult={2}&merchantReference={3}";
                                if (response.refusalReason !=null) {
                                    var refusal = response.refusalReason;
                                    console.log(refusal);
                                }
                                if (response.resultCode) {
                                    var result = response.resultCode;
                                }
                                if (response.merchantReference) {
                                    var merchantRef = response.merchantReference;
                                    console.log(merchantRef);
                                }
                                redirectUrl = redirectUrl.replace("{1}", refusal);
                                redirectUrl = redirectUrl.replace("{2}", result);
                                redirectUrl = redirectUrl.replace("{3}", merchantRef);

                                window.location = redirectUrl;
                            }
                        }
                    })
                    .catch(error => {
                        throw Error(error);
                    });
            },
            paymentMethodsConfiguration: {
                card: {
                    // Configuration for Cards
                    hasHolderName: true,
                    holderNameRequired: true,
                    enableStoreDetails: true,
                    hideCVC: false, 
                    name: 'Credit or debit card',
                    billingAddressRequired: true
                }
            }
        };
        try {

            const checkout = new AdyenCheckout(configuration);
            checkout.create('dropin').mount('#dropin-container');
        }
        catch (err) {
            document.getElementById("dropin-container").innerHTML = err.message;
        }
    })
}

//Funtion to do Post call to the server
function CallServerAPI(url, data) {
    
    return fetch(url, {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
            "Content-Type": "application/json",
        },
    }).then((res) => res.json());
}


