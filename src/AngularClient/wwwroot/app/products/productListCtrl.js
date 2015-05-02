(function () {
    'use strict';

    angular
        .module('app')
        .controller('productListCtrl', productListCtrl);

    productListCtrl.$inject = ['$location']; 

    function productListCtrl($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'productListCtrl';

        activate();

        function activate() { }
    }
})();
