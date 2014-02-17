var salarycalculationApp = angular.module('salarycalculationApp', [
    'ui.router',
    'crudControllers'
]);

salarycalculationApp.factory("DataStore", function () {
    return {};
});

salarycalculationApp.config(
    function($stateProvider) {
        $stateProvider
            .state('/basicdata', {
                url: "",
                views: {
                    "employerView": { templateUrl: '../Views/Partials/employer.html' },
                    "employeeView": { template: '<p>You will see the employee data in this section.</p>' }
                }
            })
            .state('employeeData', {
                url: "/Employees/:id",
                views: {
                    "employerView": { templateUrl: '../Views/Partials/employer.html' },
                    "employeeView": { templateUrl: '../Views/Partials/employee.html' }
                }
            })
            .state('taxCard', {
                url: "/Taxcards/:id",
                views: {
                    "employerView": { templateUrl: '../Views/Partials/employer.html' },
                    "employeeView": { templateUrl: '../Views/Partials/employee.html' },
                    "taxcardView": { templateUrl: '../Views/Partials/taxcard.html' }
                }
            });
    }
);