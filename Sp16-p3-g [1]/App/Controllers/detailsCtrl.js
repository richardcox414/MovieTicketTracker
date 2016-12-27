(function () {
    'use strict';

    angular
    .module('mainApp')
    .controller('detailsCrtl', detailsCtrl);

    detailsCtrl.$inject = ['http', 'movieService', '$routeParams'];

    function detailsCtrl($http, movieService, $routeParams) {

        var detailsCtrl = this;

        detailsCtrl.getMovieById = movieService.getMovieById;
    }
})();