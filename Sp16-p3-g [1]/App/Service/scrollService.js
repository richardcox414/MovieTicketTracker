(function () {
    'use strict';
   
     angular
    .module('mainApp')
    .factory('scrollService',scrollService)

    scrollService.$inject = ['$http'];

    
    function scrollService($http) {

        var scrollService = function () {
            this.items = [];
            this.busy = false;
            this.after = '';
            scrollService: scrollService
        };

        scrollService.prototype.nextPage = function() {
            if (this.busy) return;
            this.busy = true;

            var url = "https://api.themoviedb.org/3/movie/now_playing?api_key=97eec302eee2b3785808b2587fc3f6ee" + this.after + "&jsonp=JSON_CALLBACK";
            $http.jsonp(url).success(function(data) {
                var items = data.data.children;
                for (var i = 0; i < items.length; i++) {
                    this.items.push(items[i].data);
                    console.log(items);
                    console.log(this.items);
                }
                this.after = "t3_" + this.items[this.items.length - 1].id;
                this.busy = false;
            }.bind(this));
        };

        return scrollService;
    }

})();