(function () {
    'use strict';

    angular
		.module('adminApp')
        .value('lubTmdbApiKey', '97eec302eee2b3785808b2587fc3f6ee')
        .controller('adminCtrl', adminCtrl);
        


    adminCtrl.$inject = ['$http', 'adminService', 'lubTmdbApi'];

    function adminCtrl($http, adminService, lubTmdbApi) {



        var adminCtrl = this;
        adminCtrl.scrollService = adminService.scrollService;
        adminCtrl.select = adminService.select;
        adminCtrl.removeMovieInventory = adminService.removeMovieInventory;
        adminCtrl.addToInventory = adminService.addToInventory;
        adminCtrl.getPopList = adminService.getPopList;
        adminCtrl.addMovie = adminService.addMovie;
        adminCtrl.movies = adminService.movies;



        var newMoviesEndpoint = "https://api.themoviedb.org/3/movie/now_playing?api_key=97eec302eee2b3785808b2587fc3f6ee";
        var newMovies1Endpoint = "https://api.themoviedb.org/3/movie/now_playing?";
        var popularMoviesEndpoint = "https://api.themoviedb.org/3/movie/popular?api_key=97eec302eee2b3785808b2587fc3f6ee";
        var apiKey = "97eec302eee2b3785808b2587fc3f6ee";
        var page = 0;

        adminCtrl.movieList = [];
        adminCtrl.popList = [];
    
       
     //   adminCtrl.getMovieList = function () {
     //       var url = newMovies1Endpoint + '?page=' + ++page + '&api_key=' + apiKey;

     //       $http({ method: 'GET', url: url }).
     //           success(function (data, status, headers, config) {
     //               if (status == 200) {
     //                   page = data.page;
     //                   adminCtrl.popList.push.apply(adminCtrl.popList, data.results)
     //                   console.log(adminCtrl.popList)
     //               } else {
     //                   console.error('Error happened while getting the movie list.')
     //               }

     //           }).
     //        error(function (data, status, headers, config) {
     //            console.error('Error happened while getting the movie list.')
     //        })
     //       adminCtrl.getMovieList();
     //   };


        $http({ method: 'GET', url: newMoviesEndpoint }).
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



        $http({ method: 'GET', url: popularMoviesEndpoint }).
             success(function (data, status, headers, config) {

                 if (status == 200) {
                     adminCtrl.popList = data.results;
                     console.log(adminCtrl.popList)
                 } else {
                     console.error('Error happened while getting the movie list.')
                 }

             }).
            error(function (data, status, headers, config) {
                console.error('Error happened while getting the movie list.')
     });

        var suc = function (results) {
            console.log(results);
            console.log(adminCtrl.movie);

            adminCtrl.searchResult = angular.toJson(results, true);
            console.log(adminCtrl.searchResult);
            console.log(adminCtrl.searchResult.id);
            //   console.log(adminCtrl.searchResult.movie.id);

            // console.log(adminCtrl.searchResult);


        };
        var err = function (results) {
            adminCtrl.searchResult = results;
        };
        adminCtrl.exec = function (type, method, query) {
            lubTmdbApi[type][method]({
                query: query
            }).then(suc, err);
        }

        adminCtrl.movieInfos = function () {
            var rename = {
                alternativeTitles: 'alternative_titles',
                similarMovies: 'similar_movies',
                nowPlaying: 'now_playing',
                topRated: 'top_rated'
            }
            var needsNoIdentifier = ['latest', 'upcoming', 'nowPlaying', 'popular', 'topRated'];
            var action, append_to_response = [];
            angular.forEach(adminCtrl.movie, function (value, key) {
                if (value && !action) {
                    action = key;
                } else if (value && action) {
                    if (rename[key]) {
                        append_to_response.push(rename[key]);
                        console.log(adminCtrl.movie);
                    } else {
                        append_to_response.push(key);
                    }
                }
            });
            if (!action) {
                action = 'movie';
            }
            if (needsNoIdentifier.indexOf(action) >= 0) {
                lubTmdbApi.movie[action]({
                    params: {
                        append_to_response: append_to_response.join(',')
                    }
                }).then(suc, err);
            } else {
                lubTmdbApi.movie[action]({
                    query: adminCtrl.identifier,
                    params: { append_to_response: append_to_response.join(',') }
                }).then(suc, err);
            }
        }

    }


})();