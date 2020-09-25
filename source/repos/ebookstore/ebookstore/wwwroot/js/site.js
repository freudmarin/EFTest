// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


showInPopUp = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('show');
            $(".modal-backdrop").remove();
        }
    })
};
jQueryAjaxPost = form => {
    try {

        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#viewAll').html(res.html);
                 //   $('#form-modal').html(' ');
                    $('#form-modal .modal-title').html('');

                    $('#form-modal').modal('hide');
                    $(".modal-backdrop").remove();
                }
                else

                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err);
            }
        })


        return false;
    } catch (e) {
        console.log(e);
    }
}//per te mos bere submit


// Write your JavaScript code.
jQueryAjaxDelete = form => {
    if (confirm('Deshironi te fshini kete rekord ?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#viewAll').html(res.html);
                },
                error: function (err) {
                    console.log(err)
                }
            })
        } catch (ex) {
            console.log(ex)
        }
    }


    //prevent default form submit event
    return false;
}

$(".glyphicon glyphicon-thumbs-up").click(function () {
    $(".glyphicon glyphicon-thumbs-up").addClass('button-clicked');
});

