var salarycalculationApp = angular.module('salarycalculationApp', [
    'ngRoute',
    'crudControllers'
]);

salarycalculationApp.factory("DataStore", function () {
    return {};
});