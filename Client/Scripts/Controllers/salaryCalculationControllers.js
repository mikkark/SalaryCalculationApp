'use strict';

var salaryCalculationControllers = angular.module('salaryCalculationControllers', ['LocalStorageModule'])
    .config(['localStorageServiceProvider', function (localStorageServiceProvider) {
        localStorageServiceProvider.setPrefix('sca');
    }]);

salaryCalculationControllers.controller('appController', ['$scope', '$http', 'localStorageService', 'eventBroadcast', 'uiHelper',
    function ($scope, $http, localStorageService, eventBroadcast, uiHelper) {

        $scope.getFriendlyName = uiHelper.getFriendlyName;

        $scope.submitCalculation = function () {

            eventBroadcast.broadcast('notificationSent', { type: 'warning', message: 'About to send your calculation to server, do not unplug your machine.' });

            //Broadcast event to ask controllers to give their data.
            var dataToSave = {};
            eventBroadcast.broadcast('submitCalculation', dataToSave);

            //Save in local storage first.
            localStorageService.clearAll();
            localStorageService.add('submittedSalaryCalculation', dataToSave);

            $http.post('../api/Calculation', dataToSave).success(function (ret) {
                eventBroadcast.broadcast('notificationSent', { type: 'info', message: 'Your calculation has been succesfully committed to server.' });
                localStorageService.clearAll();

                eventBroadcast.broadcast('clearAll');
            }).error(function (ret) {
                eventBroadcast.broadcast('notificationSent', { type: 'error', message: 'Sending your calculation to the server failed. Don\'t worry, it is saved in your browser and you can try sending it again later.' });
            });

        };

    }]);

salaryCalculationControllers.controller('employeeAndEmployeeGroupController', ['$scope', '$http', 'eventBroadcast',
    function ($scope, $http, eventBroadcast) {

        $http.get('../api/Employee/').success(function (data) {
            $scope.employees = data;
        });

        $scope.selectEmployee = function (employee) {
            if (employee.selected === true) {
                employee.selected = false;
            } else {
                employee.selected = true;
            }
        };

        // When 'submit' is broadcast, give the selected employees/groups.
        $scope.$on('submitCalculation', function () {
            eventBroadcast.message.selectedEmployees = new Array();

            for (var i = 0; i < $scope.employees.length; i++) {
                var emp = $scope.employees[i];

                if (emp.selected) {
                    eventBroadcast.message.selectedEmployees[eventBroadcast.message.selectedEmployees.length] = emp;
                }
            }
        });

        $scope.$on('clearAll', function () {
            for (var i = 0; i < $scope.employees.length; i++) {
                $scope.employees[i].selected = false;
            }
        });

    }]);

salaryCalculationControllers.controller('processController', ['$scope', '$http',
    function ($scope, $http) {

        //TODO: think about where to store the current employer Id, it is needed here.
        var employerId = '123';

        //Start by loading calculations being processed.
        $http.get('../api/Calculation/' + employerId + '?statusNotIn=done').success(function (data) {
            $scope.calculationsBeingProcessed = data;
        });

        //TODO: Create a function for SignalR to call and update statuses in real-time.

    }]);

salaryCalculationControllers.controller('notificationsController', ['$scope', 'eventBroadcast',
    function ($scope, eventBroadcast) {
        $scope.notifications = new Array();

        $scope.$on('notificationSent', function () {
            $scope.notifications[$scope.notifications.length] = eventBroadcast.message;
        });
    }]);

salaryCalculationControllers.controller('salaryCalculationController', ['$scope', '$http', 'eventBroadcast', 'uiHelper',
    function ($scope, $http, eventBroadcast, uiHelper) {

        $scope.initialize = function () {
            $scope.calculationRows = new Array();

            //TODO: Get these from the uihelper, it loads these too.
            $http.get('../api/CalculationRowType/').success(function (data) {
                $scope.possibleCalculationRowTypes = data;
                $scope.selectedRowType = '';
            });
        };

        $scope.initialize();

        $scope.addCalculationRow = function () {
            $scope.calculationRows[$scope.calculationRows.length] = {
                TypeId: $scope.selectedRowType,
                Value: 0,
                Name: uiHelper.getFriendlyName($scope.selectedRowType, 'calculationRowTypeName'),
                RowType: uiHelper.getFriendlyName($scope.selectedRowType, 'calculationRowType')
            };
            $scope.selectedRowType = ''; //Clear this bound field to empty the dropdown again.
        };

        $scope.$on('submitCalculation', function () {
            eventBroadcast.message.calculationRows = $scope.calculationRows;
        });

        $scope.$on('clearAll', function () {
            $scope.initialize();
        });
    }
]);