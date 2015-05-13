(function () {
    "use strict";

    //register the controller as a child of productmanagement and set the function
    angular
        .module("productManagement")
        .controller("ProductListCtrl",
                    ["productResource",
                     ProductListCtrl]);

    function ProductListCtrl(productResource) {
        var vm = this;

        productResource.query(function (data) {
            vm.products = data; 
        });

    }
}());
