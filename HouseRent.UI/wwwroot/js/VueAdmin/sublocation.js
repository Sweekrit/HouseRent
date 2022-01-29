var sublocation = new Vue({
    el: "#app",
    data: {
        locations: [],
        indexofData:0,
        editing:false,
        location: {
            id:0,
            locationName:''
        },

       
    },
    created() {
        this.getLocations();
    },
    methods: {
        removeLocation(id, index) {
            this.indexofData = index;
            axios.delete('/Admin/locations/' + id).then(
                res => {
                this.products.splice(this.indexOfObject, 1);

            });




        },
        updateLocation() {
           axios.put('/Admin/locations/', this.location)
                .then(res => {
                    console.log(this.indexofData);
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
        }
    }



})