
$(document).ready(function () {
    $("li").click(function () {
        var equipo = $(this).attr('id');
        var url = document.location.origin + '/Equipo/Jugadores?equipo=' + equipo + '&year=' + $('#year').val();
        $.ajax(url).done(function (data) {
            $("#jugadores").empty();
            $("#jugadores").html(data);
        });
    });

    //$("li").click(function () {
    //    var equipo = $(this).attr('id');
    //    var url = document.location.origin + '/api/Ejemplo?equipo=' + equipo + '&year=' + $('#year').val();
    //    $.getJSON(url).done(function (data) {
    //        $("#jugadores").empty();
    //        data.forEach(function (item) {
    //            $("#jugadores").append("<li>" + item.NameGiven + "</li>");
    //        });
    //    })
    //});
});