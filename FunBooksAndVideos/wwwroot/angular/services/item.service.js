app.service("itemSvc",
    function ($http) {
        this.getItems = function () {
            return $http.get("/api/item");
        };
    });