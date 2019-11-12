$(document).ready(function() {
  $("#lienhe").click(function() {
    $("#Modal2").modal("show");
  });
});
// return from loign
$(document).ready(function() {
  $("#contact-agency").click(function() {
    $("#Modal3").modal("show");
    $("#Modal2").modal("hide");
  });
});

