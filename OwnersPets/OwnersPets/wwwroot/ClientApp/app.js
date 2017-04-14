var app = angular.module('ownersPetsApp', ['ngRoute', 'ngAnimate', 'ngSanitize']);

app.config(['$routeProvider', '$httpProvider', '$locationProvider', function ($routeProvider, $httpProvider, $locationProvider) {

    $routeProvider.when("/owners", {
        title: 'All Users',
        controller: "allOwnersController as ctrl",
        templateUrl: "/ClientApp/components/all.owners/all.owners.html"
    });

    $routeProvider.when("/owner-pets/:ownerId", {
        title: 'Owner Page',
        controller: "ownerPetsController as ctrl",
        templateUrl: "/ClientApp/components/owner.pets/owner.pets.html"
    });

    $routeProvider.otherwise({ redirectTo: "/owners" });


    // Disable Cache
    //initialize get if not there
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }

    // Answer edited to include suggestions from comments
    // because previous version of code introduced browser-related errors

    //disable IE ajax request caching
    $httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
    // extra
    $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
    $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';

    $locationProvider.html5Mode(false).hashPrefix('!');
}]);