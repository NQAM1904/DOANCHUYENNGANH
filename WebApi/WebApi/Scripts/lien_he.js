$(document).ready(function () {
    $("#modal_lienhe").click(function () {
        $("#Modal1").modal("show");
    });
});

$(document).ready(function () {
    $("#contact-agency").click(function () {
        $("#Modal2").modal("show");
        $("#Modal1").modal("hide");
    });
});