$(document).ready(function () {
    activarItem();
});

function getQueryParam() {
    var location = window.location
    return location.pathname.replace("/", "").toLowerCase();
}

function activarItem() {
    var item = getQueryParam();
    $("#registrarid").removeClass("active");
    $("#pedidoid").removeClass("active");
    $("#reporteid").removeClass("active");
    if ($.trim(item) == "") {
        $("#registrarid").addClass("active");
    } else {
        $("#"+item+"id").addClass("active");
    }
}