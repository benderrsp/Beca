var anoElegido = $("#year").val();

$(document).ready(function () {
    $("#jugadores").click(function (e) {
       
        var jugador = e.target;
        var equipo = $("#equipohid").val();
        var url = document.location.origin + '/Jugador/Modificar?id=' + jugador.id+'&year='+anoElegido+'&team='+equipo;
      
        enlace(url);
              
    });
});

function enlace(url) {
   
    window.location = url;
}
