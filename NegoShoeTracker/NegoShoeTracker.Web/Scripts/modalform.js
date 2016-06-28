$(function () {

    $.ajaxSetup({ cache: false });

    $("a[data-modal]").on("click", function (e) {

        // hide dropdown if any
        $(e.target).closest('.btn-group').children('.dropdown-toggle').dropdown('toggle');


        $('#myModalContent').load(this.href, function () {


            $('#myModal').modal({
                backdrop: 'static',
                keyboard: false
            }, 'show');

            bindForm(this);
        });

        return false;
    });


});

function bindForm(dialog) {

    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                console.log(result);
                if (result) {
        
                    $('#myModal').modal('hide');
                    //Refresh
                    console.log('recalc');
                    location.reload();
                } else {
                    $('#myModalContent').html(result);
                    bindForm();
                }
            }
        });
        return false;
    });
}