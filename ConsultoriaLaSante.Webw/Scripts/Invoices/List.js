$(document).ready(function () {
    $("#btnMore").click(function () {
        $("#filter").clone().appendTo("#filters");
    });
});