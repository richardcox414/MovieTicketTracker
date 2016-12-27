(function () {
    'use strict';

    angular
		.module('mainApp')
		.factory('movieService', movieService);

    movieService.$inject = ['$http', '$window', '$location', '$routeParams'];

    function movieService($http) {
        var service = {
            current: {},
            filters: {},
            cart: [],
            time: [],
            sale: [],
            addSale: addSale,
            selectMovie: selectMovie,
            clearSelection: clearSelection,
            addToCart: addToCart,
            removeMovie: removeMovie,
            clearCart: clearCart,
            getMovieById: getMovieById,
            removeTime: removeTime,
            addTime: addTime,

        };

        function getMovieById(movies, id) {
            console.log(movies);
            console.log(id + "id");
            for (var i = 0; i < movies.length; i++) {
                var movie = movies[i];
                if (movie.Id == id) {
                    currMovie = movie;
                }
                console.log(currMovie);
            }
        }

        function addSale(shows, email, qrCode) {

            var Quantity = shows.AdultQuantity + shows.SeniorQuantity + shows.ChildQuantity;

            console.log(shows);
            var saleShow = [];

            for (var i = 0; i < shows.length; i++) {
                saleShow.push({ Quantity: shows[i].Quantity, ShowTime: shows[i] })

            }
            console.log(saleShow);

            var sale = {

                EmailAddress: email,
                ShowTime: saleShow,
            };

            console.log((shows) + "before http movies");
            console.log((sale) + "before post");

            $http
                .post('http://localhost:53449/api/Sales', sale)
                .then(function (response) {
                    console.log(sale);
                //    clearCart();
              //      window.location.href = '#/';

                }, function (response) {
                    alert("Something went wrong with sale - please resend confirmation");
                })

        }

        function selectMovie(movie) {
            console.log(movies + "movies");
            console.log(movie + "movie");

            $http
				.get('http://localhost:53449/api/Movies')
				.then(function (response) {
				    angular.copy(movie, service.current);
				    service.current.movie = response.data[0];
				    console.log(service.current.movie + "movie");
				});
        }

        function clearSelection() {
            angular.copy({}, service.current);
        }

        //function addToCart(movie) {

        //    var copy = angular.copy(movie);
        //    service.cart.push(copy);
        //    console.log(copy)
        //}

        function addToCart(show) {

            console.log(show);

            var copy = angular.copy(show);
            service.cart.push(copy);
            console.log(copy)
        }
 
        function addTime(movie) {

            var showT = angular.copy(movie);
            service.time.push(show);
            console.log(showT)
        }

        function removeTime(index) {

            console.log("remove movie");
            console.log(index)
            service.showTime.splice(index, 1);
        }


        function removeMovie(index) {

            console.log("remove movie");
            console.log(index)
            service.cart.splice(index, 1);
        }

        function clearCart() {
            service.cart.length = 0;
        }


        return service;
    }

})();