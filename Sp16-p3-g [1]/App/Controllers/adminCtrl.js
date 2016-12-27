(function () {
    'use strict';

    angular
		.module('mainApp')
        .controller('adminCtrl', adminCtrl);


    adminCtrl.$inject = ['$http', 'adminService'];

    function adminCtrl($http, adminService) {

        

        var adminCtrl = this;
        adminCtrl.scrollService = adminService.scrollService;
        adminCtrl.select = adminService.select;
        adminCtrl.removeMovieInventory = adminService.removeMovieInventory;
        adminCtrl.addToInventory = adminService.addToInventory;



        var newMoviesEndpoint = "https://api.themoviedb.org/3/movie/now_playing?api_key=97eec302eee2b3785808b2587fc3f6ee";
        var apiKey = "97eec302eee2b3785808b2587fc3f6ee";
        var page = 0;
        adminCtrl.movieList = [];

        //adminCtrl.getMovieList = function () {
        //    var url = newMoviesEndpoint + '?page=' + ++page + '&api_key=' + apiKey;

        //    $http({method: 'GET', url: url}).
        //        success(function (data, status, headers, config) {
        //            if (status == 200) {
        //                page = data.page;
        //                adminCtrl.movieList.push.apply(adminCtrl.movieList, data.results)
        //                console.log(adminCtrl.movieList)
        //            } else {
        //                console.error('Error happened while getting the movie list.')
        //            }

        //        }).
        //     error(function (data, status, headers, config) {
        //         console.error('Error happened while getting the movie list.')
        //     });
        //    adminCtrl.getMovieList();
        //}

        $http({method: 'GET', url: newMoviesEndpoint}).
            success(function (data, status, headers, config) {

        if (status == 200) {
            adminCtrl.movieList = data.results;
            console.log(adminCtrl.movieList)
        } else {
           console.error('Error happened while getting the movie list.')
         }

         }).
             error(function (data, status, headers, config) {
                console.error('Error happened while getting the movie list.')
         });
        
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