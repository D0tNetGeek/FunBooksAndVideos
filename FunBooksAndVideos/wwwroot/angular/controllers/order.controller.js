app.controller("order-controller",
    function ($scope, itemSvc, orderSvc) {

        $scope.items = [];
        $scope.selectAll = false;
        $scope.orderResponse = null;

        $scope.selectedItems = [];

        $scope.orderDetail = {
            itemIds: [],
            totalAmount: 0
        };

        function loadItems() {
            itemSvc.getItems()
                .then(function (res) {
                    $scope.items = res.data;
                },
                function (res) {
                    //process error response
                    console.log(res);
                });
        };

        function resetOrderDetail() {
            $scope.orderDetail = {
                itemIds: [],
                totalAmount: 0
            };

            $scope.selectedItems = [];
        };

        function updateAmount() {
            //reset order detail
            resetOrderDetail();
            //process each element
            angular.forEach($scope.items,
                function (item) {
                    //check if item is selected
                    if (item.isSelected === true) {
                        //add item
                        $scope.orderDetail.itemIds.push(item.id);
                        //update sum
                        $scope.orderDetail.totalAmount += item.price;
                        //add item to select item list
                        $scope.selectedItems.push(item);
                    }
                });

        };

        function init() {
            loadItems();
        };

        //init controller
        init();

        //public functions

        $scope.onSelectAll = function () {
            //process each element
            angular.forEach($scope.items,
                function (item) {
                    item.isSelected = $scope.selectAll;
                });
            //udpate amount
            updateAmount();
        };

        $scope.onItemSelected = function (item) {
            //reset select all if any item not selected
            if (item.isSelected === false)
                $scope.selectAll = false;
            //udpate amount
            updateAmount();
        };

        $scope.createOrder = function () {
            orderSvc.createOrder($scope.orderDetail)
                .then(function (res) {
                    $scope.orderResponse = res.data;
                },
                function (res) {
                    //process error response
                    alert(res.data);
                });
        };
    });