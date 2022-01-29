var app = new Vue({
    el: "#app",
    data: {
        bill: {
            id:0,
            roomId:'',
            rent: 0,
            previousEReading:0,
            presentEReading:0,
            waterCost: 0,
            wastageCost: 0,
            miscellenousCost: 0,
            paymentForMonth: '',
            amount: '',
           
        },
        billAvailable:false,
        locationId: '',
        sublocationId:'',
        sublocations: [],
        selLocation: null,
        selSublocation: null,
        monthArr: [],
        customerName: '',
        totalEcost:0
    },
    mounted() {
        this.monthArr = ['Baisakh', 'Jestha', 'Ashad', 'Shrawan', 'Bhadra', 'Ashoj', 'Kartik', 'Mangsir', 'Poush', 'Magh', 'Falgun', 'Chaitra']
        this.getSubLocations();

    },
 
    methods: {

        amount() {
            let amount = this.bill.rent + this.bill.miscellenousCost + this.bill.wastageCost + this.bill.waterCost + this.calculateElectricityCost();
           return amount
        },
        calculateElectricityCost() {
            var data = (this.bill.presentEReading - this.bill.previousEReading) * 12;
            return data;
        },
 

        getSubLocations() {
            axios.get('/Admin/sublocations/')
                .then(res => {
                  
                    
                    this.sublocations = res.data;
                    console.log()

                })
                .catch(function (error) {
                    console.log(error);
                });
        },
        selectedLocation()
        {
            this.selLocation = this.sublocations.find(x => x.locationId == this.locationId);
            this.selLocation = this.selLocation.sublocataion;

        },
        selectedSubLocation()
        {
            this.selSublocation = this.selLocation.find(x => x.id == this.sublocationId);
            this.selSublocation = this.selSublocation.availableRooms;
        },
        dateCalculation() {

            let day = this.selSublocation.find(x => x.roomId == this.bill.roomId).startDay;
          

            this.bill.paymentForMonth = new Date(new Date().getFullYear() + 57, this.bill.paymentForMonth, day).toISOString();


        },

        AddBill() {
            this.dateCalculation();
            this.bill.amount = this.amount();
            axios.post('/Admin/bills/', this.bill)
                .then(
                    res => {
                        this.resetForm();
                       
                    }
                )
        },


        ViewBill() {
            this.dateCalculation();
           
            axios.get('/User/bills', {
                params: {
                    id: this.bill.roomId,
                    date:this.bill.paymentForMonth
                }
            }).
                then(res => {
                    debugger;
                    this.bill = res.data;
                    this.customerName = res.data.customerName;
                    this.bill.paymentForMonth = res.data.paymentForMonth - 1;
                    this.totalEcost = this.calculateElectricityCost();
                    this.billAvailable = true;
                    
                })
        },
        UpdateBill() {
            this.calculateElectricityCost();
            this.dateCalculation();
            this.bill.amount = this.amount();
            axios.put('/Admin/bills/', this.bill)
                .then(res => {
                console.log(res.data)
                    this.resetForm();
                })

           
        },
        resetForm() {
            this.bill.id= 0;
               this.bill.roomId= '';
                   this.bill.rent= 0;
                       this.bill.previousEReading= 0;
                           this.bill.presentEReading= 0;
                               this.bill.waterCost= 0;
                                   this.bill.wastageCost= 0;
                                       this.bill.miscellenousCost= 0;
                                           this.bill.paymentForMonth= '';
            this.bill.amount = '';
            this.customerName = '';
            this.totalEcost = 0;
            this.locationId = '';
            this.sublocationId = '';

        }

     
    }





});