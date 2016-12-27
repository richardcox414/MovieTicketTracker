(function () {
    'use strict';

    angular
		.module('mainApp')
		.controller('movieCtrl', movieCtrl);



    movieCtrl.$inject = ['$http', 'movieService'];

    function movieCtrl($http, movieService) {

        var movieCtrl = this;


        movieCtrl.currentMovie = movieService.current;
        movieCtrl.addToCart = movieService.addToCart;
        movieCtrl.selectMovie = movieService.selectItem;
        movieCtrl.clearSelection = movieService.clearSelection;
        movieCtrl.removeItem = movieService.removeItem;
        movieCtrl.addSale = movieService.addSale;

        $http
        .get('http://localhost:53449/api/Movies')
        .then(function (response) {
            movieCtrl.movies = response.data;
            console.log(movieCtrl.movies);

        }, function (response) {
            movieCtrl.movies = "Unable to load movies."

        });

    }

})();