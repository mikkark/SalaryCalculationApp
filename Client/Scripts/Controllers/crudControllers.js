'use strict';

var crudControllers = angular.module('crudControllers', []);

crudControllers.controller('fullViewController', ['$scope', '$http',
    function ($scope, $http) {
        var getEmployer = function () {
            $http.get('../api/Employer').success(function (data) {
                $scope.employer = data;
                $scope.employee = undefined;
            });
        };

        $scope.getEmployer = getEmployer;

        getEmployer();

        $scope.getEmployee = function (id) {
            $http.get('../api/Employee/' + id).success(function (data) {
                $scope.employee = data;
                $scope.isactive = false;
                $scope.taxcard = undefined;
            });
        };

        $scope.getTaxcard = function (id) {
            $http.get('../api/Taxcard/' + id).success(function (data) {
                $scope.taxcard = data;
                $scope.isactive = true;
            });
        };
    }]);

//crudControllers.controller('salarycalculationController', function ($scope, $http) {
//    $http.get('../api/SalaryCalculation').success(function (data) {
//        $scope.salarycalculation = data;
//    });
//}
//);