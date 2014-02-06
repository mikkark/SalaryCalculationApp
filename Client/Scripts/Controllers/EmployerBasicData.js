var basicDataApp = angular.module('basicData', []);

basicDataApp.controller('EmployerBasicDataController', function($scope, $http) {
    $scope.data = 'hello world';

    $http.get('../api/EmployerDataWebApi').success(function (employer) {
        $scope.employer = employer;
    });
}
)