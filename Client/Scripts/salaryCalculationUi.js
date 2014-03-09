(function () {

    function clickHandler($clickedElem, elementClass, elementContainerId) {
        var indexOfCurrentItem = ($clickedElem.index(elementClass, elementContainerId));
        var numberOfSelectedItems = $('.selected', elementContainerId).length;

        function doFadeOutFadeInForElement($elem, moveFunction) {
            $elem.fadeOut(200, moveFunction);
            $elem.fadeIn(200);
        }

        if ($clickedElem.hasClass('selected')) {
            if (indexOfCurrentItem > numberOfSelectedItems - 1) {
                doFadeOutFadeInForElement($clickedElem, function () {
                    $(':not(.selected)', elementContainerId).first().before($clickedElem);
                });
            }

        } else {
            if (indexOfCurrentItem < numberOfSelectedItems) {
                doFadeOutFadeInForElement($clickedElem, function () {
                    $('.selected', elementContainerId).last().after($clickedElem);
                });
            }
        }
    }

    $('#employees').on('click', '.employee', function () {
        clickHandler($(this), '.employee', '#employees');
    });

    $('#employeesAndEmployeeGroups').on('click', '.employeeGroup', function () {
        clickHandler($(this), '.employeeGroup', '#employeeGroups');
    });

})();