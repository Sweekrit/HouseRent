var app = new Vue({
    el: '#app',
    data: {
       editing:false,
        sublocations: [],
        selProd: null,
        customers:[],
        rooms: [],

        roomInfo: {
            id: 0,
            roomDesc: '',
            //rent: 0,
            startingDate: '',
            //previousEReading:0,
            //presentEReading:0,
            //waterCost: 0,
            //wastageCost: 0,
            //miscellenousCost: 0,
            subLocationId:'',
            tenantId:''
        },
        locationId:''
    },

    mounted() {
        this.getAllRooms();
        this.getSubLocations();
        this.getAllUsers();
    },
    methods: {
        selectedLocation() {

            this.selProd = this.sublocations.find(x => x.locationId == this.locationId);
            this.selProd = this.selProd.sublocataion;

        },


        getSubLocations() {
            axios.get('/Admin/sublocations/')
                .then(res => {
                    this.sublocations = res.data;



                })
                .catch(function (error) {
                    console.log(error);
                });
        },

        getAllUsers() {
            axios.get('/Admin/users/')
                .then(res => {
                    this.customers = res.data;



                })
                .catch(function (error) {
                    console.log(error);
                });


        },


        getAllRooms() {
            axios.get('/Admin/rooms/')
                .then(res => {
                    this.rooms = res.data;

                })
                .catch(function (error) {
                    console.log(error);
                });
        },
        getRoom(id) {
            this.editing = true;
            axios.post('/Admin/rooms/' + id)
                .then(res => {
                    this.roomInfo = res.data;
                    this.locationId = res.data.locationId;
                    this.selectedLocation();
                })
                .catch(function (error) {
                    console.log(error);
                });

        },

        updateRooms() {
            debugger;
            axios.put('/Admin/rooms/', this.roomInfo)
                .then(res =>
                {
                    console.log(res.data)
                    debugger;
                    this.getAllRooms();
                })
            this.editing = false;
            this.resetForm();

        },

        DeleteRoom(id) {
            axios.delete('/Admin/rooms/' + id)
                .then(res => {
                    this.getAllRooms();
                }
                )

        },

        dateChanged() {
           
        },

        AddRoom() {
            this.roomInfo.startingDate = date;
            console.log(this.roomInfo);
            debugger;
            axios.post('/Admin/rooms/', this.roomInfo)
                .then( res => {
                    this.getAllRooms();

                })
                .catch(function (error) {
                    console.log(error);
                });

            this.resetForm();
        },


        resetForm() {
            this.roomInfo.id = 0;
            this.roomInfo.roomDesc = '';
            //this.roomInfo.rent = 0;
            //this.roomInfo.previousEReading = 0;
            //this.roomInfo.presentEReading = 0;
            //this.roomInfo.wastageCost = 0;
            //this.roomInfo.waterCost = 0;
            //this.roomInfo.miscellenousCost = 0;
            this.roomInfo.tenantId = '';
            this.roomInfo.subLocationId = '';
            this.roomInfo.startingDate = '';
         
            locationId = '';

        }


        

    }

});
var date ='';

window.onload = function () {
    var mainInput = document.getElementById("datepicker");
    mainInput.nepaliDatePicker({
        language: "english",
        onChange: function (e) {
            date = e.bs;
        }
    });

}