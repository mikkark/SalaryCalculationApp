//This is not needed anymore, this was just an attempt to give several controllers access to employees in one
//central location.
salaryCalculationApp.factory('employeeService', function ($http, $q) {
    var deferred = $q.defer();
    var data = [];
    var employeeService = {};

    employeeService.async = function () {
        $http.get('../api/Employee/').success(function (d) {
            data = d;
            console.log(d);
            deferred.resolve(data);
        });
        return deferred.promise;
    };
    
    employeeService.data = function () { return data; };

    return employeeService;
})