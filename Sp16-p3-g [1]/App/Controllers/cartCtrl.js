(function () {
    'use strict';

    angular
		.module('mainApp')
		.controller('CartCtrl', ['movieService', '$window', function (movieService, $window) {


		    var cartCtrl = this;

		    cartCtrl.clearCart = movieService.clearCart;
		    cartCtrl.getTotal = movieService.getTotal;
		    cartCtrl.addSale = movieService.addSale;
		   // cartCtrl.movies = movieService.cart;
		    cartCtrl.shows = movieService.cart;
		    cartCtrl.removeMovie = movieService.removeMovie;
		    cartCtrl.addTime = movieService.addTime;
		    cartCtrl.removeTime = movieService.removeTime;


		    cartCtrl.getTotal = function () {
		        var TotalAmount = 0;
		        angular.forEach(cartCtrl.shows, function (show) {
		            TotalAmount += (show.AdultQuantity * show.Movie.AdultPrice) + (show.SeniorQuantity * show.Movie.SeniorPrice) + (show.ChildQuantity * show.Movie.ChildPrice);
		        })
		        return TotalAmount;
		    }

		    cartCtrl.getQty = function () {
		        var seatSold = 0;
		        angular.forEach(cartCtrl.shows, function (show) {
		            seatSold += show.AdultQuantity + show.SeniorQuantity + show.ChildQuantity;
		        })
		        return seatSold;
		    }

		    cartCtrl.getNumber = function () {
		        return cartCtrl.movies.length;
		        console.log(cartCtrl.movies.length);
		    }

		    cartCtrl.getMovies = function () {
		        return cartCtrl.movies;
		    }





		}]);

})();