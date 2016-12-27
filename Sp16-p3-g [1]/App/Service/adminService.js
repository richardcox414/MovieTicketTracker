(function () {
    'use strict';

    angular
		.module('mainApp')
		.factory('adminService', adminService)

    adminService.$inject = ['$http', '$window'];

    function adminService($http, $log, moment) {
        var service = {
            current: {},
            filters: {},
            inventory: [],
            showTime: [],
            addPostShow: addPostShow,
            addToInventory: addToInventory,
            removeMovieInventory: removeMovieInventory,
            clearInventory: clearInventory,

        };

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

        function addPostShow(movies) {

            console.log(movies);
            var showPost = [];

            for (var i = 0; i < movies.length; i++) {
                showPost.push({Movie: movies[i] })

            }
            console.log(showPost);


            var showTime = {


                Movies: showPost,


            };

            console.log(angular.toJson(movies) + "before http items");
            console.log(angular.toJson(showTime) + "before post");

            $http
                .post('http://localhost:53449/api/ShowTimes', showTime)
                .then(function (response) {
                    console.log(angular.toJson(showTime) + "after");
                    clearInventory();
                    window.location.href = '#/';

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