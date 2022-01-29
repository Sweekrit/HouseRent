
var app = new Vue({
    el: '#app',
    data: {
        roomArray: [],
        dataAvailable: false,
        disabled: true,
        
        user: {},
        userInfo: {
          
            firstName: '',
            lastName: '',
            phoneNumber: 0,
            address: '',
            email: '',
            userName: '',
            
        },
        userid:0,

    },
    mounted() {
        this.assignInit();
       
  
    },

    methods: {
        assignInit() {
            this.userid = parseInt(document.getElementById("Sessiondata_Id").value);
            var uName = document.getElementById("Sessiondata_UserName").value;
            var email = document.getElementById("Sessiondata_Email").value;

            debugger;
            if (this.userid  == 0) {
                this.userInfo.userName = uName;
                this.userInfo.email = email;
                this.disabled = false;
               
                this.dataAvailable = false;
            }
            else {
                this.getUser(this.userid );
            }



        },
        createUser() {
            debugger;
            axios.post("/User/users/", this.userInfo)
                .then(res => {
                    console.log(res.data);
                    debugger;
                    this.getUser(res.data.id);
                })
        },
        editUser() {
            console.log(this.userInfo);
         
            this.disabled = false;
        },
        updateUser() {
            debugger;
            axios.put('/User/users/',this.userInfo)
                .then(
                res => {
                        this.getUser(this.userid);
                        
                        this.disabled = true;
                    })
        },
        getUser(id) {
          
            axios.get('/User/users/' +id)
                .then(res => {
                    
                    if (res.data != "") {
                        this.user= res.data;
                        this.roomArray = res.data.roomDetail;
                        this.dataAvailable = true;
                       
                        this.disabled = true;
                        this.addtoInfo(this.user);
                    }
                    else {
                       
                        this.disabled = false;
                        this.dataAvailable = false;
                    }
                    console.log(this.roomArray);
                })
        },
        addtoInfo(data) {
            this.userInfo.id = data.id; 
            this.userInfo.firstName = data.firstName; 
            this.userInfo.lastName = data.lastName; 
            this.userInfo.address = data.address; 
            this.userInfo.phoneNumber = data.phoneNumber; 
            this.userInfo.email = data.email; 
            this.userInfo.userName = data.userName; 
        },
    }



});
