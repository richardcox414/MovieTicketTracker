(function () {
    'use strict';

    angular
		.module('adminApp')
		.factory('adminService', adminService)
        .value('lubTmdbApiKey', '97eec302eee2b3785808b2587fc3f6ee')

    adminService.$inject = ['$http', '$window'];

    function adminService($http, $log, moment) {
        var service = {
            current: {},
            filters: {},
            inventory: [],
            showTime: [],
            movieList: [],
            popList: [],
            addMovie: addMovie,
            addToInventory: addToInventory,
            removeMovieInventory: removeMovieInventory,
            clearInventory: clearInventory,
            getPopList: getPopList,

        };

        function getPopList() {

            var newMoviesEndpoint = "https://api.themoviedb.org/3/movie/now_playing?api_key=97eec302eee2b3785808b2587fc3f6ee";
            var popularMoviesEndpoint = "https://api.themoviedb.org/3/movie/popular";
            var apiKey = "97eec302eee2b3785808b2587fc3f6ee";
            var page = 0;

            service.popList = [];

            var url = popularMoviesEndpoint + '?page=' + ++page + '&api_key=' + apiKey;

            $http({ method: 'GET', url: url }).
                success(function (data, status, headers, config) {
                    if (status == 200) {
                        page = data.page;
                        service.popList.push.apply(service.popList, data.results)
                        console.log(popList)
                    } else {
                        console.error('Error happened while getting the movie list.')
                    }

                }).
             error(function (data, status, headers, config) {
                 console.error('Error happened while getting the movie list.')
             });
            getPopList();
        }

        function addToInventory(movie) {
            var copy = angular.copy(movie);
            service.inventory.push(copy);
            console.log(copy)
        }


        function removeMovieInventory(index) {
            console.log("remove movie");
            console.log(index)
            service.inventory.splice(index, 1);
        }

        function addMovie(movies) {

            console.log(movies);

            
            var showPost = [];

            for (var i = 0; i < movies.length; i++) {
                showPost.push({Movie: movies[i] })

            }
            console.log(showPost);


            var showTime = {


                Movies: showPost,


            };

            console.log(angular.toJson(movies) + "before http movies");
            console.log(angular.toJson(showTime) + "before post");

            $http
                .post('http://localhost:53449/api/Movies', movies)
                .then(function (response) {
                    console.log(angular.toJson(movies) + "after");
                  //  clearInventory();
                //      window.location.href = '#/';

                }, function (response) {
                    alert("Something went wrong - please resend confirmation");
                })


        }

        function clearInventory() {
            service.cart.length = 0;
        }

        return service;   
    }

    
})();