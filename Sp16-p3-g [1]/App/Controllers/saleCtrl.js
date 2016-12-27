(function () {
    'use strict';

    angular
		.module('mainApp')
		.controller('SaleCtrl', SaleCtrl);



    SaleCtrl.$inject = ['$http', 'movieService'];

    function SaleCtrl($http, movieService) {
        var saleCtrl = this;

        saleCtrl.currentMovie = movieService.current;
        saleCtrl.addToCart = movieService.addToCart;
        saleCtrl.selectMovie = movieService.selectItem;
        saleCtrl.clearSelection = movieService.clearSelection;
        saleCtrl.removeItem = movieService.removeItem;
        saleCtrl.addSale = movieService.addSale;

        $http
            .get('http://localhost:10194/api/Sales')
            .then(function (response) {
                saleCtrl.items = response.data;
                console.log(angular.toJson(saleCtrl.items) + "Salectrl items")
            });

    };

})();