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

salaryCalculationControllers.controller('employeeAndEmployeeGroupController', ['$scope', '$http', 'eventBroadcast', 'employeeService',
    function ($scope, $http, eventBroadcast, employeeService) {

        $http.get('../api/Employee/').success(function (data) {
            $scope.employees = data;
        });

        //This was an attempt to get the employees from a service. I will keep this here for later reference. 
        //This was also my first proper look into promise objects.
        //
        //employeeService.async().then(function () {
        //    $scope.employees = employeeService.data();
        //});

        $scope.selectEmployee = function (employee) {
            if (employee.selected === true) {
                employee.selected = false;
            } else {
                employee.selected = true;
            }

            eventBroadcast.broadcast('employeeSelectionChanged', employee);
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

salaryCalculationControllers.controller('salaryCalculationController', ['$scope', '$http', 'eventBroadcast', 'uiHelper', 'employeeService',
    function ($scope, $http, eventBroadcast, uiHelper, employeeService) {

        $scope.initialize = function () {
            $scope.calculationRows = new Array();

            //TODO: Get these from the uihelper, it loads these too.
            $http.get('../api/CalculationRowType/').success(function (data) {
                $scope.possibleCalculationRowTypes = data;
                $scope.selectedRowType = '';
            });

            $scope.calculationBasicdata = {};

            var currDate = new Date();
            var periodStartDate = new Date(currDate.getFullYear(), currDate.getMonth(), 1);
            var periodEndDate = new Date(new Date(new Date(periodStartDate).setMonth(periodStartDate.getMonth() + 1)) - 1);

            //Set some defaults.
            $scope.calculationBasicdata.PeriodStartDate = periodStartDate.getDate() + '.' + (periodStartDate.getMonth() + 1) + '.' + periodStartDate.getFullYear();
            $scope.calculationBasicdata.PeriodEndDate = periodEndDate.getDate() + '.' + (periodEndDate.getMonth() + 1) + '.' + periodEndDate.getFullYear();

            $scope.calculationTotals = [];
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

        $scope.total = function () {
            var totalNumber = 0;
            for (var i = 0; i < $scope.calculationRows.length; i++) {
                var value = $scope.calculationRows[i].Value;
                totalNumber = totalNumber + ($scope.calculationRows[i].RowType === 'plus' ? value : value * -1);
            }

            return totalNumber;
        };

        $scope.totalTax = function (taxPercentage) {
            var total = $scope.total();

            return (taxPercentage / 100) * total;
        };

        $scope.$on('submitCalculation', function () {
            eventBroadcast.message.calculationRows = $scope.calculationRows;
        });

        $scope.$on('employeeSelectionChanged', function () {
            var employee = eventBroadcast.message;

            if (employee.selected) {
                $scope.calculationTotals[$scope.calculationTotals.length] = {
                    employeeName: employee.Name,
                    taxPercentage: employee.Taxcards[0].TaxPercentage
                };
            } else {
                angular.forEach($scope.calculationTotals, function (obj, index) {
                    if (obj.employeeName === employee.Name) {
                        $scope.calculationTotals.splice(index, 1);
                    }
                });
            }
        });

        $scope.$on('clearAll', function () {
            $scope.initialize();
        });
    }
]);