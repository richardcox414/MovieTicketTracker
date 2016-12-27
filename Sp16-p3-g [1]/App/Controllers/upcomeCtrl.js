(function () {
    'use strict';

    angular
		.module('mainApp')
        .controller('upcomeCtrl', upcomeCtrl);


    upcomeCtrl.$inject = ['$http', 'movieService'];

    function upcomeCtrl($http, movieService) {



        var upcomeCtrl = this;
        upcomeCtrl.scrollService = movieService.scrollService;
        upcomeCtrl.select = movieService.select;
        upcomeCtrl.removeMovieInventory = movieService.removeMovieInventory;
        upcomeCtrl.addToInventory = movieService.addToInventory;




        var upcomeMoviesEndpoint = "https://api.themoviedb.org/3/movie/now_playing?api_key=97eec302eee2b3785808b2587fc3f6ee";
        var apiKey = "97eec302eee2b3785808b2587fc3f6ee";
        var page = 0;
        upcomeCtrl.movieList = [];

 

        $http({ method: 'GET', url: upcomeMoviesEndpoint }).
            success(function (data, status, headers, config) {

                if (status == 200) {
                    upcomeCtrl.movieList = data.results;
                    console.log(upcomeCtrl.movieList)
                } else {
                    console.error('Error happened while getting the movie list.')
                }

            }).
             error(function (data, status, headers, config) {
                 console.error('Error happened while getting the movie list.')
             });





    }


})();