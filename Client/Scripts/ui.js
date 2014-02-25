(function () {
    var getBootstrapColumnSize = function(countOfActiveItems) {
        var calculated = ((12 / countOfActiveItems) - 1);

        return calculated < 4 ? 4 : calculated;
    };

    var resetColumnSizes = function () {
        var $activeOnes = $('div[ng-app]').children('div.active');
        var count = $activeOnes.length;
        var classnameToApply = 'col-md-' + getBootstrapColumnSize(count);

        $activeOnes.last().addClass('lastActive');

        $activeOnes.each(function () {
            $(this).toggleClass(classnameToApply);
            $(this).removeClass('col-md-1');

            if (!($(this).is($activeOnes.last()))) {
                $(this).removeClass('lastActive');
            }

            for (var i = 1; i <= 3; i++) {
                if (i !== count) {
                    $(this).removeClass('col-md-' + getBootstrapColumnSize(i));
                }
            }
        });
    };

    $('div.active', 'div[ng-app]').livequery(
        function () {
            resetColumnSizes();
        },
        function () {
            if (!($(this).hasClass('active'))) {
                for (var i = 1; i <= 3; i++) {
                    $(this).removeClass('col-md-' + getBootstrapColumnSize(i));
                    $(this).removeClass('lastActive');
                    $(this).addClass('col-md-1');
                }
            }

            resetColumnSizes();
        });

})();