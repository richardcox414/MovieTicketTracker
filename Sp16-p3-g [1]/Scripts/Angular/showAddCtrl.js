(function () {
    'use strict';

    angular
		.module('adminApp')
        .controller('showAddCtrl', ['adminService', '$http', '$window', function (adminService, $http, $window) {


            var showAddCtrl = this;

            showAddCtrl.select = adminService.select;
            showAddCtrl.removeMovieInventory = adminService.removeMovieInventory;
            showAddCtrl.addToInventory = adminService.addToInventory;
            showAddCtrl.movies = adminService.inventory;
            showAddCtrl.clearInventory = adminService.clearInventory
            showAddCtrl.addPostShow = adminService.addPostShow;


            $http
            .get('http://localhost:53449/api/Movies')
            .then(function (response) {
                showAddCtrl.shows = response.data;
                console.log(showAddCtrl.shows);
            }, function (response) {
                showAddCtrl.show = "Unable to load show."

            });



        }]);


})();