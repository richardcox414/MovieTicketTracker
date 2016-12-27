(function () {
    var mainApp = angular.module('mainApp', ['ngRoute', 'angular.filter', 'monospaced.qrcode', 'angular-carousel'])
        .config(['$routeProvider', function ($routeProvider) {
            $routeProvider
            $routeProvider.when('/', {
                templateUrl: '/App/Views/Movies.html',
            })
            $routeProvider.when('/detail/:id', {
                templateUrl: '/App/Views/Details.html',
            })
            $routeProvider.when('/book', {
                templateUrl: '/App/Views/Book.html',
            })
            $routeProvider.when('/admin', {
                templateUrl: '/App/Views/Admin.html',
            })
            $routeProvider.when('/sched', {
                templateUrl: '/App/Views/ShowSched.html',
            })
            $routeProvider.when('/sale', {
                templateUrl: '/App/Views/Sales.html',
            })
            $routeProvider.when('/thanks', {
                templateUrl: '/Home.cshtml',
            })
            $routeProvider.when('/done', {
                templateUrl: '/App/Views/ThankYou.html',
            });
        }])

})();