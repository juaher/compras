var selectVendedor = $('[name ="selectvendedor"]');
var selectCliente = $('[name ="selectcliente"]');
var selectArticulo = $('[name ="selectarticulo"]');
var inputNumero = $('[name ="inputnumero"]');
var inputCantidad = $('[name ="inputcantidad"]');
var inputValor = $('[name ="inputvalor"]');

var tbodyArticulo = $('[name ="tbodyarticulo"]');
var btnAgregar = $('[name ="btnagregar"]');
var btnCancelar = $('[name ="btncancelar"]');
var btnAceptar = $('[name ="btnaceptar"]');


var Pedido = new Object();
Pedido.DetallePedidos = new Array();

var clear = function () {
    selectArticulo.val("");
    inputNumero.val(0);
    inputCantidad.val(0);
    inputValor.val(0);
    var padreSuperior = selectArticulo.closest('div');
    padreSuperior.removeClass("has-success");
    padreSuperior = inputCantidad.closest('div');
    padreSuperior.removeClass("has-success");
    padreSuperior = inputNumero.closest('div');
    padreSuperior.removeClass("has-success");
    padreSuperior = inputValor.closest('div');
    padreSuperior.removeClass("has-success");

}
   

clear();

var generarTabla = function () {
    tbodyArticulo.html("");
    var text = "";
    for (i = 0; i < Pedido.DetallePedidos.length; i++) {
        text += "<tr>";
        text += "<td>" + Pedido.DetallePedidos[i].CodigoArticulo + "</td>";
        text += "<td>" + Pedido.DetallePedidos[i].Numero + "</td>";
        text += "<td>" + Pedido.DetallePedidos[i].Cantidad + "</td>";
        text += "<td>" + Pedido.DetallePedidos[i].ValorUnidad + "</td>";
        text += "</tr>";
    }

    tbodyArticulo.html(text);
}

var agregarArticulo = function () {
    var idArticulo = selectArticulo.val();
    var numero = inputNumero.val();
    var cantidad = parseInt(inputCantidad.val());
    var valor = parseInt(inputValor.val());
    if (idArticulo == "") {
        var padreSuperior = selectArticulo.closest('div');
        padreSuperior.addClass("has-error");
        return;
    } else {
        var padreSuperior = selectArticulo.closest('div');
        padreSuperior.removeClass("has-error").addClass("has-success");
    }

    if (numero == "" || numero <= 0) {
        var padreSuperior = inputNumero.closest('div');
        padreSuperior.addClass("has-error");
        return;
    } else {
        var padreSuperior = inputNumero.closest('div');
        padreSuperior.removeClass("has-error").addClass("has-success");
    }

    if (cantidad == "" || cantidad <= 0) {
        var padreSuperior = inputCantidad.closest('div');
        padreSuperior.addClass("has-error");
        return;
    } else {
        var padreSuperior = inputCantidad.closest('div');
        padreSuperior.removeClass("has-error").addClass("has-success");
    }
    if (valor == "" || valor <= 0) {
        var padreSuperior = inputValor.closest('div');
        padreSuperior.addClass("has-error");
        return;
    } else {
        var padreSuperior = inputValor.closest('div');
        padreSuperior.removeClass("has-error").addClass("has-success");
    }
    var articulo = new Object();
    articulo.CodigoArticulo = idArticulo;
    articulo.Numero = parseInt(numero);
    articulo.Cantidad = parseInt(cantidad);
    articulo.ValorUnidad = parseInt(valor);
    Pedido.DetallePedidos.push(articulo);
    generarTabla();
    clear();
}

var funcCancelar = function () {
    Pedido.DetallePedidos = new Array();
    clear();
    generarTabla();
}

var funcAceptar = function () {
    if (selectVendedor.val() == "") {
        var padreSuperior = selectVendedor.closest('div');
        padreSuperior.addClass("has-error");
        return;
    } else {
        var padreSuperior = selectVendedor.closest('div');
        padreSuperior.removeClass("has-error").addClass("has-success");
    }
    if (selectCliente.val() == "") {
        var padreSuperior = selectCliente.closest('div');
        padreSuperior.addClass("has-error");
        return;
    } else {
        var padreSuperior = selectCliente.closest('div');
        padreSuperior.removeClass("has-error").addClass("has-success");
    }
    Pedido.cliente = selectCliente.val();
    Pedido.vendedor = selectVendedor.val();
    var padreSuperior = selectVendedor.closest('div');
    padreSuperior.removeClass("has-success");
    padreSuperior = selectCliente.closest('div');
    padreSuperior.removeClass("has-success");
    $.ajax('api/pedidos', {
        'data': JSON.stringify(Pedido), //{action:'x',params:['a','b','c']}
        'type': 'PUT',
        'processData': false,
        'contentType': 'application/json' //typically 'application/x-www-form-urlencoded', but the service you are calling may expect 'text/json'... check with the service to see what they expect as content-type in the HTTP header.
    }).done(function () {
        alert("Pedido generado");
        clear();
        pedido = new Object();
        Pedido.DetallePedidos = new Array();
        generarTabla();
    });

}

var clientes = function () {
    $.get("api/personas/2", function (data) {
        var listaCliente = data;
        var text = "<option value=''>&nbsp;</option>";
        selectCliente.empty();
        for (i = 0; i < listaCliente.length; i++) {
            var c = listaCliente[i];
            text += "<option value='" + c.Id +"'>"+c.Nombre+" "+ c.Apellido +"</option>";
        }
        selectCliente.html(text);
    });
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

var articulos = function () {
    $.get("api/articulos", function (data) {
        var listaArticulos = data;
        var text = "<option value=''>&nbsp;</option>";
        selectArticulo.empty();
        for (i = 0; i < listaArticulos.length; i++) {
            var c = listaArticulos[i];
            text += "<option value='" + c.Id + "'>" + c.Id + " " + c.Nombre + "</option>";
        }
        selectArticulo.html(text);
    });
}

btnAgregar.on("click", agregarArticulo)

btnCancelar.on("click", funcCancelar)

btnAceptar.on("click", funcAceptar)

clientes();
vendedores();
articulos();