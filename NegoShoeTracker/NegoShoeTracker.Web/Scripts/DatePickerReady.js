/*
if (!Modernizr.inputtypes.date) {
    $(function () {

        $(".datecontrol").datepicker().on('changeDate', function (e) {
            $('.datecontrol').datepicker('hide');
        });
    });
}

*/

$(document).ready(function () {
        $(".datecontrol").datepicker({ format: 'dd/mm/yyyy', autoclose: true, todayBtn: 'linked' })
});