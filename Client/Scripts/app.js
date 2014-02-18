var salarycalculationApp = angular.module('salarycalculationApp', [
    'ngRoute',
    'crudControllers'
]);

salarycalculationApp.factory("DataStore", function() {
    return {};
});

salarycalculationApp.config(['$routeProvider',
    function($routeProvider) {
        $routeProvider.
            when('/basicdata', {
                templateUrl: '../Views/Partials/employer.html'
            }).
            when('/Employees/:id', {
                templateUrl: '../Views/Partials/employee.html'
            }).            
            when('/Taxcards/:id', {
                templateUrl: '../Views/Partials/taxcard.html'
            }).
            otherwise({
                redirectTo: '/basicdata'
            });
    }]);