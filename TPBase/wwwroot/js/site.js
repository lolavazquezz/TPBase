function CrearCuenta() {
    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Home/CrearCuentaAjax',
        data: { IdUsuario: idU },
        success: function (response) {
            let content = "Nombre de usuario: <input type='text' class='play' id='player' name='Nombre' placeholder='Ingrese su nombre'></input>"
            $("#CrearCuenta").html(content);
        }

    })
}

function MostrarMasInfo(idC) {
    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Home/MostrarMasInfoAjax',
        data: { Idconcierto: idC },
        success: function (response) {
            console.log(response);
            $("#FechaCreacion").html("Fecha del concierto: " + response.fechaConcierto.substr(0,10));
            $("#Descripcion").html(response.descripcion);
            $("#Precio").html("Precio: " + response.precio);
        }
    });
}
function Likes(idc, element) {
        let h6CantLikes = element.parentNode.children[2];
        let elementIsLiked = element.src.includes('CorazonBlanco.jpg');
        $.ajax({
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/LikesAjax',
            data:
            {
                IdConcierto: idc,
                CantLikes: !elementIsLiked ? -1 : 1 
            },
            success: function (response) {
                console.log(response);
                if (elementIsLiked) element.src = '/Imagenes/CorazonRojo.jpg';
                else element.src = '/Imagenes/CorazonBlanco.jpg';
                h6CantLikes.innerText = response;
            }
    
        });
    }


