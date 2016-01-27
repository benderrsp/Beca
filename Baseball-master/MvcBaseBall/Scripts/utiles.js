$(document).ready(function () {
    $("#lab").click(function () {

        window.opener.location.reload();
        //alert("Recargando padre");
        window.close();
    });

});
