var app = new Vue({
    el: '#app',
    data: {
        details: [],
        monthArr: [],
        originalData: {},
        billAvailable: false,
        totalEcost: 0,
        userid: 0,
        isPay: false,
        
       
    },
    mounted() {
        this.monthArr = ['Baisakh', 'Jestha', 'Ashad', 'Shrawan', 'Bhadra', 'Ashoj', 'Kartik', 'Mangsir', 'Poush', 'Magh', 'Falgun', 'Chaitra']
        
        this.assignInit();
    },
   

    methods: {

        assignInit() {
            //this.userid = 11;
            this.userid= parseInt(document.getElementById("Sessiondata_Id").value);
           
           

            debugger;
            
            if (this.userid != 0) {

                this.getBills(this.userid);
            }



        },
        calculateElectricityCost() {
           this.totalEcost = (this.originalData.presentEReading - this.originalData.previousEReading) * 12;
          
        },

        dateCalculation(date) {

            let month = this.monthArr.indexOf(date.split('/')[0])
            date = new Date(new Date().getFullYear() + 57, month, new Date().getDate()).toISOString();
            return date;
        },

        getMonthsInWords(date,data) {
           
           
            var month = this.monthArr[parseInt(date.split('-')[1]) - 1];
            let temp = date.split('-')[0];
            var year = (temp.substring(1, temp.length));

            data.startingDate = month + "/" + year;

            

       

        },
        getBills(id) {
            axios.get('/User/bills/' + id)
                .then(res => {

                   
                    this.details = res.data;
                    debugger;
                   
                    this.details.forEach(item => {item.bills.forEach( x =>  this.getMonthsInWords(x.startingDate,x)) })
                    
                    
                })
        },
       
        ViewBill(id, date) {
           date = this.dateCalculation(date);
            this.billAvailable = true;
            axios.get('/User/bills', {
                params: {
                    id: id,
                    date: date
                }
            }).
                then(res => {
                    this.originalData = res.data;
                  
                   
                    this.calculateElectricityCost();
                })

        },
        PayFor() {
            this.isPay = true;

            var purchase = {
              
                id: this.originalData.id,
                amount: this.originalData.amount,
               // customer: this.userid.toString()
            }

            var publicKey = document.getElementById("PublicKey").value;

            // A reference to Stripe.js initialized with a fake API key.
            // Sign in to see examples pre-filled with your key.
            var stripe = Stripe(publicKey);
            debugger;


            // The items the customer wants to buy

            // Disable the button until we have Stripe set up on the page
            document.querySelector("button").disabled = true;
            fetch("/create-payment-intent", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(purchase)
            })
                .then(function (result) {
                    debugger;
                    return result.json();
                })
                .then(function (data) {
                    debugger;
                    var elements = stripe.elements();

                    var style = {
                        base: {
                            color: "#32325d",
                            fontFamily: 'Arial, sans-serif',
                            fontSmoothing: "antialiased",
                            fontSize: "16px",
                            "::placeholder": {
                                color: "#32325d"
                            }
                        },
                        invalid: {
                            fontFamily: 'Arial, sans-serif',
                            color: "#fa755a",
                            iconColor: "#fa755a"
                        }
                    };

                    var card = elements.create("card", { style: style });
                    // Stripe injects an iframe into the DOM
                    card.mount("#card-element");

                    card.on("change", function (event) {
                        // Disable the Pay button if there are no card details in the Element
                        document.querySelector("button").disabled = event.empty;
                        document.querySelector("#card-error").textContent = event.error ? event.error.message : "";
                    });

                    var form = document.getElementById("payment-form");
                    form.addEventListener("submit", function (event) {
                        event.preventDefault();
                        // Complete payment when the submit button is clicked
                        payWithCard(stripe, card, data.clientSecret);
                    });
                });

            // Calls stripe.confirmCardPayment
            // If the card requires authentication Stripe shows a pop-up modal to
            // prompt the user to enter authentication details without leaving your page.
            var payWithCard = function (stripe, card, clientSecret) {
                loading(true);
                stripe
                    .confirmCardPayment(clientSecret, {
                        payment_method: {
                            card: card
                        }
                    })
                    .then(function (result) {
                        if (result.error) {
                            // Show error to your customer
                            showError(result.error.message);
                        } else {
                            // The payment succeeded!
                            orderComplete(result.paymentIntent.id);
                        }
                    });
            };

            /* ------- UI helpers ------- */

            // Shows a success message when the payment is complete
            var orderComplete = function (paymentIntentId) {
                loading(false);
                document
                    .querySelector(".result-message a")
                    .setAttribute(
                        "href",
                        "https://dashboard.stripe.com/test/payments/" + paymentIntentId
                    );
                document.querySelector(".result-message").classList.remove("hidden");
                document.querySelector("button").disabled = true;
            };

            // Show the customer the error from Stripe if their card fails to charge
            var showError = function (errorMsgText) {
                loading(false);
                var errorMsg = document.querySelector("#card-error");
                errorMsg.textContent = errorMsgText;
                setTimeout(function () {
                    errorMsg.textContent = "";
                }, 4000);
            };

            // Show a spinner on payment submission
            var loading = function (isLoading) {
                if (isLoading) {
                    // Disable the button and show a spinner
                    document.querySelector("button").disabled = true;
                    document.querySelector("#spinner").classList.remove("hidden");
                    document.querySelector("#button-text").classList.add("hidden");
                } else {
                    document.querySelector("button").disabled = false;
                    document.querySelector("#spinner").classList.add("hidden");
                    document.querySelector("#button-text").classList.remove("hidden");
                }
            };

           
        }
     
    }










});



