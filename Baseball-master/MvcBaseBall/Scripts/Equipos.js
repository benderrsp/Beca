
$(document).ready(function () {
    $("li").click(function () {
        var equipo = $(this).attr('id');
        var url = document.location.origin + '/Equipo/Jugadores?equipo=' + equipo + '&year=' + $('#year').val();
        $.ajax(url).done(function (data) {
            $("#jugadores").empty();
            $("#jugadores").html(data);
        });
    });

 
});