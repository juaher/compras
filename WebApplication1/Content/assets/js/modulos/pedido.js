var selectVendedor = $('[name ="selectvendedor"]');

var tbodyPedido = $('[name ="tbodypedidos"]');

var generarTabla = function () {
    tbodyPedido.html("");
    var text = "";
    var vendedor = selectVendedor.val();
    if (vendedor > 0) {
        $.get("api/pedidos/PorVendedor/" + vendedor, function (data) {
            var datos = data;
            tbodyPedido.html();
            var text = "";
                for (i = 0; i < datos.length; i++) {
                    var c = datos[i];
                    text += "<tr>";
                    text += "<td>" + c.Id + "</td>";
                    text += "<td>" + c.NombreCliente + "</td>";
                    text += "<td>" + c.FechaHora + "</td>";
                    text += "<td>";
                    text += '<div class="form-button-action">'
                        + '<button type="button" name="bteliminar" data-toggle="tooltip" data-id="' + c.Id+'" title="" class="btn btn-link btn-danger" data-original-title="Eliminar">'
                        + ' <i class="fa fa-times"></i>'
                        + '</button>'
                        + '</div>'
                    +'</td>';
                    text += "</tr>";
                }
            tbodyPedido.html(text);    
            $('[name ="bteliminar"]').on("click", function() {
                var idPedido = $(this).data("id");
                $.ajax('api/pedidos/' + idPedido, {
                    'type': 'DELETE',
                    'processData': false
                }).done(function () {
                    alert("Pedido " + idPedido + " eliminado");
                    generarTabla();
                });

            });

        });
    }
    
    
}

var vendedores = function () {
    $.get("api/personas/1", function (data) {
        var listaVendedor = data;
        var text = "<option value=''>&nbsp;</option>";
        selectVendedor.empty();
        for (i = 0; i < listaVendedor.length; i++) {
            var c = listaVendedor[i];
            text += "<option value='" + c.Id + "'>" + c.Nombre + " " + c.Apellido + "</option>";
        }
        selectVendedor.html(text);
    });
}

vendedores();

selectVendedor.on("change", function () {
    generarTabla();
});