var app = new Vue({
    el: "#app",
    data: {
        sublocations:[],
        locations: [],
        indexofData:0,
        editing:false,
        location: {
            id:0,
            locationName:''
        },
        sublocation: {
            id: 0,
            sublocationName: '',
            locationid:''
        },
        selProd: null


       
    },
    mounted() {
        this.getLocations();
        this.getSubLocations();
    },
    methods: {
        removeLocation(id, index) {
            console.log(index);
            axios.delete('/Admin/locations/' + id).then(
                res => {
                this.locations.splice(index, 1);

            });




        },
        updateLocation() {
           axios.put('/Admin/locations/', this.location)
                .then(res => {
                    this.locations.push(res.data);
                    
                })
                .catch(function (error) {
                    console.log(error);
                });
            this.editing = false;
        },

        addLocation() {
            axios.post('/Admin/locations/',this.location)
                .then(res => {
                   this.locations.push(res.data);
                })
                .catch(function (error) {
                    console.log(error);
                });
        },
        getLocations() {
            axios.get('/Admin/locations/')
                .then(res => {
                    this.locations = res.data;
                })
                .catch(function (error) {
                    console.log(error);
                });
        },
        editLocation(product, index) {
            this.indexofData = index;
            this.location = product;   
            this.editing = true;
        },


        addSubLocation() {
          
            axios.post('/Admin/sublocations/',this.sublocation)
                .then(function (response) {
                    this.sublocations.push(res.data);
                    
                })
                .catch(function (error) {
                    console.log(error);
                });

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

        selectedLocation(e) {
            var locId = parseInt(e.target.value);
            this.sublocation.locationid = locId;
            this.selProd = this.sublocations.find(x => x.locationId == locId);
            this.selProd = this.selProd.sublocataion;
        },

        editSubLocation() {
           
            this.editing = true;
        },
        updateSubLocation() {
            axios.put('/Admin/sublocations/', {
                sublocation: this.selProd.map(x => {
                    return {
                        id: x.id,
                        sublocationName:x.sublocationName,
                        locationid: this.sublocation.locationid
                    };
                })





            }).then(res => {
                console.log(res.data);

            });


        },
        removeSubLocation(id, index) {
            axios.delete('/Admin/sublocations/' + id)
                .then(
                    this.selProd.splice(index, 1)
                )

        }
        

    }



})