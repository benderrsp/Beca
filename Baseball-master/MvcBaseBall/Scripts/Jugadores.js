
    $(document).ready(function () {
        $("#jugadores").click(function (e) {
           
            var jugador = e.target;
            var url = document.location.origin + '/Equipo/Jugador?id=' + jugador.id;
            
            $.ajax(url).done(function (data) {

                $("#jugador").empty();
                $("#jugador").html(data);
            });
        });
    });

