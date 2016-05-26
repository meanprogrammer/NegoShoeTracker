if (!Modernizr.inputtypes.date) {
    $(function () {

        $(".datecontrol").datepicker().on('changeDate', function (e) {
            $('.datecontrol').datepicker('hide');
        });
    });
}