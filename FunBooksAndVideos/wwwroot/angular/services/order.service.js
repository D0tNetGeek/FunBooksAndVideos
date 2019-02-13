app.service("orderSvc",
    function ($http) {
        this.createOrder = function (model) {
            console.log(model);
            return $http.post("/api/order", model);
        }
    });