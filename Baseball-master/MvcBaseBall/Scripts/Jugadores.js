$(document).ready(function () {
    $(#jugadores>li).click(function () {
        var jugador = $(this).attr('id');
      
        var url = document.location.origin + 'Jugadores?id=' + jugador;
        $.ajax(url).done(function (data) {
            $("#PlayerID").val = 'caca';
           
        });
    });
});