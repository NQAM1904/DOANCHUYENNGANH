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

$("#Modal2").each(function () {

    var currentModal = $(this);

    //click next
    currentModal.find('.btn-next').click(function () {
        currentModal.modal('hide');
        currentModal.closest("#Modal2").nextAll("#Modal3").first().modal('show');
    });

    //click prev
    currentModal.find('.btn-prev').click(function () {
        currentModal.modal('hide');
        currentModal.closest("#Modal3").prevAll("#Modal2").first().modal('show');
    });

});