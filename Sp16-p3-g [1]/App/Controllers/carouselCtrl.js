(function () {
    'use strict';

    angular
		.module('mainApp')
		.controller('carouselCtrl', carouselCtrl);



    carouselCtrl.$inject = ['$http', 'movieService'];

    function carouselCtrl($http, movieService) {

        var carouselCtrl = this;


        carouselCtrl.currentMovie = movieService.current;
        carouselCtrl.addToCart = movieService.addToCart;
        carouselCtrl.selectMovie = movieService.selectItem;
        carouselCtrl.clearSelection = movieService.clearSelection;
        carouselCtrl.removeItem = movieService.removeItem;
        carouselCtrl.addSale = movieService.addSale;

        $http
        .get('http://gdata.youtube.com/feeds/api/standardfeeds/most_popular?v=2&alt=json')
        .then(function (response) {
          //  carouselCtrl.data = response.data;
            carouselCtrl.data = response.feed.entry;
            console.log(carouselCtrl.data);

        }, function (response) {
            carouselCtrl.data = "Unable to load carousel."

        });

        //$http
        // .get('http://localhost:53449/api/ShowTimes')
        // .then(function (response) {
        //     movieCtrl.shows = response.data;
        //     console.log(movieCtrl.shows);
        // }, function (response) {
        //     movieCtrl.shows = "Unable to load show."

        // });
    }

})();