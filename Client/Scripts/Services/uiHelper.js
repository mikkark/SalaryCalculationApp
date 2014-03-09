salaryCalculationApp.factory('uiHelper', function ($http) {

    var rowTypes = {};

    $http.get('../api/CalculationRowType').success(function (data) {
        for (var i = 0; i < data.length; i++) {
            rowTypes[data[i].Id] = { Name: data[i].Name, RowType: data[i].RowType };
        }
    });

    this.getFriendlyName = function (friendlyfyThis, type) {

        switch (type) {
            case 'status':
                switch (friendlyfyThis) {
                    case 'GeneratingReports':
                        return 'Generating reports';
                    case 'AwaitingApproval':
                        return 'Awaiting approval';
                    default:
                        return "Unknown status";
                }
            case 'calculationRowTypeName':
                return rowTypes[friendlyfyThis].Name;
            case 'calculationRowType':
                return rowTypes[friendlyfyThis].RowType;
        }
    };

    window.uiHelper = this;

    return this;
})