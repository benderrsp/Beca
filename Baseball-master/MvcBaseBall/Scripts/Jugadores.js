$(document).ready(function () {
    
    //$("#jugadores>li").click(function () {
    //    var jugador = $(this).attr('id');
    //    alert("Has clickado algo");

        //var url = document.location.origin + 'Jugadores?id=' + jugador;
        //$.ajax(url).done(function (data) {
        //    $("#PlayerID").html(data.jugador)
           
        //});
        $("#jugadores").click(function(e){

            var jugador = e.target;
            alert(jugador.id);
            alert(document.location.origin);
            var url = document.location.origin + 'Jugador?id=' + jugador.id;
            $.ajax(url).done(function (data) {
                $("#PlayerID").html(data.jugador)

            });

           });


    });
//});