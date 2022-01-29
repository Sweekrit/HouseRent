var app = new Vue({
    el: '#app',
    data: {
        customerSelected: false,

        customers: [],
        customer: {}
    },

    mounted() {
        this.getAllUsers();
    },
    methods: {
        getAllUsers() {
            axios.get('/Admin/users/')
                .then(res => {
                    this.customers = res.data;
                    console.log(this.customers);

                })
                .catch(function (error) {
                    console.log(error);
                });


        },

        getUser(id) {
            this.customerSelected = true;
                    debugger;
            axios.get('/User/users/' +id)
                .then(res => {
                    this.customer = res.data;
                    console.log(this.customer);

                })
                .catch(function (error) {
                    console.log(error);
                });

        },
        RemoveUser(id) {
            axios.delete('/Admin/users/' + id)
                .then(res => {

                });
        }


    }
    









});