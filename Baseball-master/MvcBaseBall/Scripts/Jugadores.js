var anoElegido = $("#year").val();
alert(anoElegido);
    $(document).ready(function () {
        $("#jugadores").click(function (e) {
           
            var jugador = e.target;
            var url = document.location.origin + '/Jugador/Modificar/id=' + jugador.id;
            
            $.ajax(url).done(function (data) {

                $("#jugador").empty();
                $("#jugador").html(data);
            });
        });
    });

