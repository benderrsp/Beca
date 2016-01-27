
$(document).ready(function () {
    $("#jugadores").click(function (e) {
       
        var jugador = e.target;
        //alert(document.location.origin);
        var url = document.location.origin + '/Jugador/Modificar/' + jugador.id;
        //alert(url);
        enlace(url);
       
        
        
    });
});

function enlace(url) {
   
    window.open(url, "Jugador", "width=700,height=400,scrollbars=NO")
}
