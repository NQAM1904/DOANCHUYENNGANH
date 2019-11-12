$(document).ready(function () {
    $('#Mybtn').click(function (){
        var url = $(this).data('url');
        $.get(url, function (data) {
            $('#divModal').html(data);
            $('#Modal').modal('show');
        });
    });
});